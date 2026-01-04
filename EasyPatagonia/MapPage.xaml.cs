using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using System;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using EasyPatagonia.Models;
using EasyPatagonia.Services;
using Plugin.ImageEdit;

namespace EasyPatagonia
{
    // Clase auxiliar para guardar el pin y su nivel de prioridad
    public class PinMapData
    {
        public Pin Pin { get; set; }
        public int NivelPrioridad { get; set; }
    }

    public partial class MapPage : ContentPage
    {
        private double latitude = -46.6225;
        private double longitude = -72.6745;

        // --- LISTAS DE PRIORIDAD ---
        // Nivel 1: Zoom lejano
        private List<string> Nivel1_Nombres = new List<string> {
            "hostal el puesto", "restaurante tios felices", "ruedas y rios",
            "aoni expediciones", "marble patagonia", "panchito full marmol", "guanaco loco"
        };

        // Nivel 2: Zoom medio
        private List<string> Nivel2_Nombres = new List<string> {
            "explorando viajes", "nunatank", "adventure travel", "journey of life",
            "excursiones huente-co", "cafe chirifo", "restaurante turistico pia",
            "restaurante adventure travel", "posada aves australes"
        };

        // Nivel 3: Zoom cercano (todos los demás)
        private List<string> Nivel3_Nombres = new List<string> {
            "tuismo contramarea", "rio leon excursiones", "kintun ko expediciones",
            "excursiones triahue", "nunatank chile"
        };

        private List<PinMapData> _allPinData = new List<PinMapData>();
        private int _ultimoNivelMostrado = -1;

        public MapPage()
        {
            InitializeComponent();
            var position = new Position(latitude, longitude);

            // Eventos
            map.InfoWindowClicked += OnMapInfoWindowClicked;
            map.CameraIdled += OnMapCameraIdled;

            // Carga inicial de estilo y datos
            AplicarEstiloPersonalizado();
            Task.Run(async () => await CargarPinesDesdeServicio());

            // Zoom inicial
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1.5)));
        }

        // --- LÓGICA DE ZOOM CON "OCULTAR TODO" ---
        private void OnMapCameraIdled(object sender, CameraIdledEventArgs e)
        {
            var zoom = e.Position.Zoom;
            int nivelDeseado = 0;

            if (zoom < 13.0)
            {
                nivelDeseado = 0; // Muy lejos -> Ocultar todo
            }
            else if (zoom >= 13.0 && zoom < 15.0)
            {
                nivelDeseado = 1; // Lejos -> Solo Nivel 1
            }
            else if (zoom >= 15.0 && zoom < 16.5)
            {
                nivelDeseado = 2; // Medio -> Nivel 1 + 2
            }
            else
            {
                nivelDeseado = 3; // Cerca -> Todos (1 + 2 + 3)
            }

            if (_ultimoNivelMostrado != nivelDeseado)
            {
                ActualizarPinesEnMapa(nivelDeseado);
                _ultimoNivelMostrado = nivelDeseado;
            }
        }

        private void ActualizarPinesEnMapa(int nivelMaximo)
        {
            map.Pins.Clear();

            // Si el nivel es 0, dejamos el mapa limpio
            if (nivelMaximo == 0) return;

            var pinesAMostrar = _allPinData
                .Where(x => x.NivelPrioridad <= nivelMaximo)
                .Select(x => x.Pin)
                .ToList();

            foreach (var pin in pinesAMostrar)
            {
                map.Pins.Add(pin);
            }
        }

        // --- ARREGLO DEL MODO SATÉLITE ---
        private void OnCambiarMapaClicked(object sender, EventArgs e)
        {
            if (map.MapType == MapType.Street)
            {
                // Cambiar a Satélite -> Quitamos estilo para evitar conflicto de colores
                map.MapType = MapType.Hybrid;
                map.MapStyle = null;
            }
            else
            {
                // Volver a Normal -> Reaplicamos estilo personalizado
                map.MapType = MapType.Street;
                AplicarEstiloPersonalizado();
            }
        }

        private void AplicarEstiloPersonalizado()
        {
            try
            {
                var assembly = typeof(MapPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("EasyPatagonia.map_style.json");
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        map.MapStyle = MapStyle.FromJson(reader.ReadToEnd());
                    }
                }
            }
            catch { }
        }

        // --- CARGA DE PINES Y ASIGNACIÓN DE NIVEL ---
        private async Task CargarPinesDesdeServicio()
        {
            var listaEmpresas = DatosService.ObtenerTodo();

            Device.BeginInvokeOnMainThread(() => map.Pins.Clear());
            _allPinData.Clear();

            using (var client = new HttpClient())
            {
                foreach (var emp in listaEmpresas)
                {
                    BitmapDescriptor iconoPin = null;
                    try
                    {
                        if (!string.IsNullOrEmpty(emp.Logo))
                        {
                            var bytes = await client.GetByteArrayAsync(emp.Logo);
                            using (var originalStream = new MemoryStream(bytes))
                            {
                                var resizedStream = await ResizeImageAsync(originalStream, 100, 100);
                                iconoPin = BitmapDescriptorFactory.FromStream(resizedStream);
                            }
                        }
                    }
                    catch { }

                    if (iconoPin == null)
                    {
                        Color color = Color.Red;
                        if (emp.Categoria == TipoEmpresa.Restaurante) color = Color.Orange;
                        else if (emp.Categoria == TipoEmpresa.Hospedaje) color = Color.Blue;
                        iconoPin = BitmapDescriptorFactory.DefaultMarker(color);
                    }

                    var pin = new Pin
                    {
                        Label = emp.Nombre,
                        Address = "Toca para ver ficha",
                        Type = PinType.Place,
                        Position = new Position(emp.Latitud, emp.Longitud),
                        Icon = iconoPin,
                        Tag = emp
                    };

                    // Lógica de Prioridad
                    int prioridad = 3;
                    string nombreLimpio = emp.Nombre.ToLower();

                    if (ExisteEnLista(nombreLimpio, Nivel1_Nombres)) prioridad = 1;
                    else if (ExisteEnLista(nombreLimpio, Nivel2_Nombres)) prioridad = 2;
                    else if (ExisteEnLista(nombreLimpio, Nivel3_Nombres)) prioridad = 3;

                    _allPinData.Add(new PinMapData { Pin = pin, NivelPrioridad = prioridad });
                }
            }

            // Actualización inicial
            Device.BeginInvokeOnMainThread(() => {
                ActualizarPinesEnMapa(1);
                _ultimoNivelMostrado = 1;
            });
        }

        private bool ExisteEnLista(string nombreEmpresa, List<string> listaNombres)
        {
            return listaNombres.Any(n => nombreEmpresa.Contains(n));
        }

        // --- MÉTODOS EXISTENTES ---

        public void SetLocation(double latitud, double longitud, string nombreLugar = "Destino")
        {
            this.latitude = latitud;
            this.longitude = longitud;
            var position = new Position(latitud, longitud);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.2)));
            map.Pins.Clear();
            var pin = new Pin
            {
                Label = nombreLugar,
                Address = "Ubicación Seleccionada",
                Position = position,
                Type = PinType.Place,
                Icon = BitmapDescriptorFactory.DefaultMarker(Color.Red)
            };
            map.Pins.Add(pin);
        }

        private async Task<MemoryStream> ResizeImageAsync(Stream inputStream, int width, int height)
        {
            byte[] imageBytes;
            using (var ms = new MemoryStream()) { await inputStream.CopyToAsync(ms); imageBytes = ms.ToArray(); }
            var image = CrossImageEdit.Current.CreateImage(imageBytes);
            var resizedImage = image.Resize(width, height);
            var pngBytes = resizedImage.ToPng();
            var stream = new MemoryStream(pngBytes);
            stream.Position = 0;
            return stream;
        }

        private async void OnMapInfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            if (e.Pin != null && e.Pin.Tag is Empresa empresaSeleccionada)
                await Navigation.PushAsync(new EmpresaDetallePage(empresaSeleccionada));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            map.IsVisible = true;
            await HabilitarUbicacionUsuario();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            map.IsVisible = false;
        }

        private async Task HabilitarUbicacionUsuario()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted) status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Granted)
                {
                    map.MyLocationEnabled = true;
                    map.UiSettings.MyLocationButtonEnabled = true;
                }
                else map.MyLocationEnabled = false;
            }
            catch { map.MyLocationEnabled = false; }
        }

        private async void OnComoLlegarClicked(object sender, EventArgs e) =>
            await Xamarin.Essentials.Map.OpenAsync(latitude, longitude, new MapLaunchOptions { NavigationMode = NavigationMode.Driving });

        private async void OnSoporteClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new AsistentePage());
    }
}