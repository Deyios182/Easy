using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using EasyPatagonia.Models;



namespace EasyPatagonia.Services

{

    public static class DatosService

    {

        public static List<Empresa> TodasLasEmpresas { get; private set; }

        private static readonly SupabaseService _supabaseService = new SupabaseService();

        public static async Task InicializarAsync()
        {
            try
            {
                var empresasRemote = await _supabaseService.ListarEmpresasAsync();
                if (empresasRemote != null && empresasRemote.Count > 0)
                {
                    var serviciosRemote = await _supabaseService.ListarTodasActividadesAsync();
                    foreach (var empresa in empresasRemote)
                    {
                        empresa.Actividades = serviciosRemote.FindAll(s => s.CompanyId == empresa.Id);
                    }
                    TodasLasEmpresas = empresasRemote;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al sincronizar con Supabase: {ex.Message}");
            }
        }



        static DatosService()

        {

            // --- LOGOS DE RELLENO (Usados si la empresa no tiene su logo propio) ---

            string LOGO_RESTAURANTE_GENERICO = "https://cdn-icons-png.flaticon.com/512/1046/1046788.png";

            string LOGO_HOSPEDAJE_GENERICO = "https://cdn-icons-png.flaticon.com/512/2933/2933921.png";

            string LOGO_ACTIVIDAD_GENERICO = "https://cdn-icons-png.flaticon.com/512/3094/3094846.png";



            // --- IMÁGENES GENÉRICAS ---

            string IMAGEN_GENERICA_TOUR = "https://images.unsplash.com/photo-1519781615555-d4e5f419c968";

            string IMAGEN_GENERICA_COMIDA = "https://images.unsplash.com/photo-1555939594-58d7cb561ad1";

            string IMAGEN_GENERICA_ALOJAMIENTO = "https://images.unsplash.com/photo-1582719508461-905c673771fd";



            TodasLasEmpresas = new List<Empresa>();



            // ============================================================

            // 1. ACTIVIDADES (TOURS Y EXCURSIONES) - GPS Y SERVICIOS COMPLETOS

            // ============================================================



            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Explorando Viajes",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -45.5752, // Coyhaique (Punto de encuentro)

                Longitud = -72.0662,

                Descripcion = "Agencia de Turismo y Transporte de Pasajeros. Tours desde Coyhaique a Capillas de Mármol, Queulat y Ruta del Agua. Vehículos seguros y conductores profesionales.",

                Direccion = "Coyhaique (Punto de encuentro)",

                Logo = "https://i.imgur.com/vS8UUl9.png", // Usamos genérico por ahora

                NumeroWhatsApp = "+56956926717",

                Imagenes = new List<string> { "https://images.unsplash.com/photo-1501785888041-af3ef285b470" }, // Imagen referencial transporte/tour

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Full Day Capillas de Mármol", Precio = "CLP 70.000", Descripcion = "Desde Coyhaique. Incluye transporte, navegación, alimentación, guía y paradas fotográficas.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Full Day Parque Nacional Queulat", Precio = "CLP 75.000", Descripcion = "Incluye transporte, guiado, snack y paradas fotográficas.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Ruta del Agua", Precio = "CLP 55.000", Descripcion = "Coyhaique - Puerto Aysén - Chacabuco - Bahía Acantilada. Incluye snack.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Traslado Aeropuerto Balmaceda", Precio = "Consultar", Descripcion = "Servicio especial de traslado de pasajeros.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } }

                }

            });







            // AONI EXPEDICIONES

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Aoni Expediciones",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62251669246896,

                Longitud = -72.67438799005373,

                Descripcion = "Vive la magia de la Patagonia. Navegaciones a Catedral y Capilla de Mármol. Guías bilingües, seguridad y naturaleza.",

                Direccion = "Puerto Río Tranquilo, Aysén",

                Logo = "https://i.imgur.com/gGo8HiH.png",

                NumeroWhatsApp = "+56942581508",

                Imagenes = new List<string> { "https://i.imgur.com/marmol-full.jpg", "https://i.imgur.com/marmol-simple.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Tour Full Mármol", Precio = "CLP 30.000", Descripcion = "2.5 hrs: Islas Panichini, cavernas y Santuario.", Imagenes = new List<string> { "https://i.imgur.com/marmol-full.jpg" } },

                    new Actividad { Nombre = "Tour Simple", Precio = "CLP 20.000", Descripcion = "1.5 hrs: Santuario Capillas.", Imagenes = new List<string> { "https://i.imgur.com/marmol-simple.jpg" } },

                    new Actividad { Nombre = "Simple Privado 1-5 px", Precio = "CLP 160.000", Descripcion = "Tour Simple exclusivo para tu grupo. Embarcación privada.", Imagenes = new List<string> { "https://i.imgur.com/simple-privado.jpg" } },

                    new Actividad { Nombre = "Full Privado 1-5 px", Precio = "CLP 240.000", Descripcion = "Experiencia premium privada.", Imagenes = new List<string> { "https://i.imgur.com/full-privado.jpg" } }

                }

            });



            // MARBLE PATAGONIA

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Marble Patagonia",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62244563776807,

                Longitud = -72.6742886940119,
                
                Descripcion = "Operador local líder. Navegaciones seguras al Santuario.",

                Direccion = "Calle Principal S/N",

                Logo = "https://i.imgur.com/8lFhzH9.png",

                NumeroWhatsApp = "+56979784600",

                Imagenes = new List<string> { "https://megaconstrucciones.net/images/naturales/foto2/marmol-catedral.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Navegación Clásica", Precio = "CLP 20.000", Descripcion = "Visita a las cavernas y catedral.", Imagenes = new List<string> { "https://megaconstrucciones.net/images/naturales/foto2/marmol-catedral.jpg" } },

                    new Actividad { Nombre = "Tour Full Mármol", Precio = "CLP 30.000", Descripcion = "2.5 hrs: Figuras, túnel, catedral. Max 11 pax.", Imagenes = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/7/79/Cabeza_de_perro%2C_capilla_de_M%C3%A1rmol.JPG" } },

                    new Actividad { Nombre = "Privado Full", Precio = "CLP 180.000", Descripcion = "3 hrs privado hasta 5 pax.", Imagenes = new List<string> { "https://www.interpatagonia.com/paseos/glaciar-exploradores/el-glaciar-exploradores-5.jpg" } }

                }

            });



            // NUNATAK CHILE

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Nunatak Chile",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62355154557713,
                
                Longitud = -72.67666132233433,

                Descripcion = "Expertos en Kayak y aventura. Kayak a Capilla de Mármol con guías Sernatur.",

                Direccion = "Plaza de Armas, Local 2",

                Logo = "https://i.imgur.com/59QncS3.png",

                NumeroWhatsApp = "+56951448060",

                Imagenes = new List<string> { "https://www.nunatak-patagonia.com/wp-content/uploads/2020/07/kayak-capillas-marmol.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Kayak Capilla de Mármol", Precio = "CLP 55.000", Descripcion = "Kayak guiado personalizado con equipo completo.", Imagenes = new List<string> { "https://www.nunatak-patagonia.com/wp-content/uploads/2020/07/kayak-capillas-marmol.jpg" } }

                }

            });



            // EXCURSIONES TRICAHUE SPA

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Excursiones Tricahue Spa",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62279906418468,
                
                Longitud = -72.67476564509779,

                Descripcion = "Navegaciones al Santuario Capilla de Mármol.",

                Direccion = "Calle Pedro Lagos",

                Logo = "https://i.imgur.com/dZJw3tn.png",

                NumeroWhatsApp = "+56957135755",

                Imagenes = new List<string> { "https://www.cascada.travel/sites/default/files/styles/hero/public/2021-06/Marble-Caves-Chile.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Tour Capilla", Precio = "CLP 20.000", Descripcion = "1.5 hrs: Cavernas y figuras.", Imagenes = new List<string> { "https://www.swoop-patagonia.com/sites/default/files/styles/hero/public/2022-07/marble-caves.jpg" } },

                    new Actividad { Nombre = "Tour Full Mármol", Precio = "CLP 30.000", Descripcion = "2.5 hrs: Incluye Puerto Sánchez.", Imagenes = new List<string> { "https://www.cascada.travel/sites/default/files/styles/hero/public/2021-06/Marble-Caves-Chile.jpg" } },

                    new Actividad { Nombre = "Tour Pesca Lago", Precio = "CLP 50.000/hr", Descripcion = "Mín 2 hrs: Equipo completo.", Imagenes = new List<string> { "https://www.explorepatagonia.com/wp-content/uploads/2021/05/fishing-general-carrera.jpg" } }

                }

            });



            // ADVENTURE TRAVEL (Tours)

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Adventure Travel (Tours)",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.622405297500855,
                
                Longitud = -72.6741936619077,

                Descripcion = "Tours a Capilla, Glaciar Exploradores y Laguna San Rafael.",

                Direccion = "Carretera Austral",

                Logo = "https://i.imgur.com/VlaRbYT.png",

                NumeroWhatsApp = "++56964563818",

                Imagenes = new List<string> { "https://i.imgur.com/glaciar1.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Glaciar Exploradores", Precio = "CLP 150.000", Descripcion = "Trekking full day sobre hielo.", Imagenes = new List<string> { "https://i.imgur.com/glaciar1.jpg" } },

                    new Actividad { Nombre = "Laguna San Rafael", Precio = "CLP 180.000", Descripcion = "Catamarán full day.", Imagenes = new List<string> { "https://i.imgur.com/sanrafael.jpg" } },

                    new Actividad { Nombre = "Capilla de Mármol", Precio = "CLP 25.000", Descripcion = "Navegación 1.5 hrs.", Imagenes = new List<string> { "https://i.imgur.com/capilla1.jpg" } }

                }

            });



            // KINTUN KO EXPEDICIONES

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Kintun Ko Expediciones",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62279403515797,

                Longitud = -72.6745434962049,

                Descripcion = "Tours personalizados en kayak.",

                Direccion = "Puerto Río Tranquilo",

                Logo = "https://i.imgur.com/NRpODzI.png",

                NumeroWhatsApp = "+56957553333",

                Imagenes = new List<string> { "https://www.kintun.com/images/kayak-capillas.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Kayak a Capillas", Precio = "CLP 50.000", Descripcion = "3.5 hrs total. Incluye equipo.", Imagenes = new List<string> { "https://www.kintun.com/images/kayak-capillas.jpg" } }

                }

            });



            // RIO LEÓN EXCURSIONES

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Rio León Excursiones",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62268284994776,
                
                Longitud = -72.67465842676273,

                Descripcion = "Agencia local. Tours en grupo y privado.",

                Direccion = "Puerto Río Tranquilo, Aysén",

                Logo = "https://i.imgur.com/8aGI9cD.png",

                NumeroWhatsApp = "+56944340109",

                Imagenes = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/7/79/Cabeza_de_perro%2C_capilla_de_M%C3%A1rmol.JPG" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Full Mármol", Precio = "CLP 30.000", Descripcion = "2.5 hrs: Barcos históricos y cavernas.", Imagenes = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/7/79/Cabeza_de_perro%2C_capilla_de_M%C3%A1rmol.JPG" } },

                    new Actividad { Nombre = "Tour Privado Full", Precio = "CLP 180.000", Descripcion = "2.5 hrs privado hasta 5 pax.", Imagenes = new List<string> { "https://www.interpatagonia.com/paseos/glaciar-exploradores/el-glaciar-exploradores-5.jpg" } }

                }

            });



            // PANCHITO FULL MÁRMOL

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Panchito Full Mármol",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.622578718840366,

                Longitud = -72.6742291349873,

                Descripcion = "Tours a Santuario todo el año.",

                Direccion = "Puerto Río Tranquilo, Aysén",

                Logo = "https://i.imgur.com/aGUeMxL.png",

                NumeroWhatsApp = "+56999678945",

                Imagenes = new List<string> { "https://panchitofullmarmol.cl/images/full-marmol.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Full Mármol", Precio = "CLP 30.000", Descripcion = "Navegación completa.", Imagenes = new List<string> { "https://panchitofullmarmol.cl/images/full-marmol.jpg" } },

                    new Actividad { Nombre = "Simple Mármol", Precio = "CLP 20.000", Descripcion = "Navegación simple.", Imagenes = new List<string> { "https://panchitofullmarmol.cl/images/simple-marmol.jpg" } },

                    new Actividad { Nombre = "Full Privado", Precio = "CLP 250.000", Descripcion = "Navegación privada completa.", Imagenes = new List<string> { "https://panchitofullmarmol.cl/images/full-privado.jpg" } }

                }

            });



            // JOURNEY OF LIFE

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Journey of Life",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62549659787286,

                Longitud = -72.67591093493536,

                Descripcion = "Empresa dedicada a complementar actividades turísticas. Goza de tus tiempos libres.",

                Direccion = "Carretera Austral km 210",

                Logo = "https://i.imgur.com/RAzYA9Q.png",

                NumeroWhatsApp = "+56934248269",

                Imagenes = new List<string> { "https://i.imgur.com/8aVoEpn.jpeg", "https://i.imgur.com/yGXZEY3.jpeg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Tours Personalizados", Precio = "Consultar", Descripcion = "Trekking, cabalgata, navegación. Enfoque en bienestar.", Imagenes = new List<string> { "https://i.imgur.com/8aVoEpn.jpeg" } }

                }

            });



            // ====== EXCURSIONES HUENTE-CÓ – NUEVA EMPRESA 2025 ======

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Excursiones Huente-Có",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.622571824804254,
                
                Longitud = -72.67447510752851,

                Descripcion = "Empresa local con tours propios: Glaciar Exploradores, Kayak en Cavernas de Mármol y Rafting en Río Baker. Guías certificados y atención personalizada.",

                Direccion = "Puerto Río Tranquilo",

                Logo = "https://i.imgur.com/l30CHPZ.png", // ← Pon aquí el logo real cuando lo tengas

                NumeroWhatsApp = "+56982718866",

                Imagenes = new List<string>

    {

        "https://i.imgur.com/huenteco-glaciar.jpg",

        "https://i.imgur.com/huenteco-kayak.jpg",

        "https://i.imgur.com/huenteco-rafting.jpg"

    },

                Actividades = new List<Actividad>

    {

        new Actividad

        {

            Nombre = "Glaciar Exploradores",

            Precio = "CLP 150.000",

            Descripcion = "Trekking full day sobre el glaciar. Incluye traslado, equipo técnico, guía y almuerzo.",

            Imagenes = new List<string> { "https://i.imgur.com/huenteco-glaciar.jpg" }

        },

        new Actividad

        {

            Nombre = "Kayak en Cavernas de Mármol",

            Precio = "CLP 50.000",

            Descripcion = "3 hrs de kayak guiado por las cavernas y capilla de mármol. Equipo completo y traslado incluido.",

            Imagenes = new List<string> { "https://i.imgur.com/huenteco-kayak.jpg" }

        },

        new Actividad

        {

            Nombre = "Rafting Río Baker",

            Precio = "Consultar",

            Descripcion = "Descenso en rafting por el río Baker (nivel III-IV). Incluye equipo, guía y seguridad.",

            Imagenes = new List<string> { "https://i.imgur.com/huenteco-rafting.jpg" }

        },

        new Actividad

        {

            Nombre = "Laguna San Rafael (en alianza)",

            Precio = "CLP 190.000",

            Descripcion = "Full day en catamarán al glaciar San Rafael + whisky con hielo milenario.",

            Imagenes = new List<string> { "https://i.imgur.com/sanrafael-huenteco.jpg" }

        }

    }

            });



            // ====== GUANACO LOCO – EXPLORADORES 4x4 ======

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Guanaco Loco – Exploradores 4x4",

                Categoria = TipoEmpresa.Actividad,

                Latitud = -46.62237859485508,
                
                Longitud = -72.67412996156757,

                Descripcion = "Experiencias auténticas en la Patagonia. Conectar al visitante con el ecosistema prístino. Guías certificados, vehículo 4x4, pick up desde alojamiento.",

                Direccion = "Puerto Río Tranquilo, Carretera Austral",

                Logo = "https://i.imgur.com/2GSH3ev.png", // Logo oficial

                NumeroWhatsApp = "+56976824240", // ← PIDE NÚMERO

                Imagenes = new List<string>

                {

                    "https://i.imgur.com/guanaco1.jpg",

                    "https://i.imgur.com/guanaco2.jpg",

                    "https://i.imgur.com/guanaco3.jpg"

                },

                Actividades = new List<Actividad>

                {

                new Actividad

                {

                    Nombre = "Valle, Bosque y Glaciares – Ruta Exploradores 4x4",

                    Precio = "CLP 60.000 (Privado CLP 170.000)",

                    Descripcion = "Miradores, cascadas, bosques siempreverdes y caminata al mirador del Glaciar Exploradores. Atardecer sobre Campo de Hielo Norte. Incluye transporte 4x4, guía, snack.",

                    Imagenes = new List<string> { "https://i.imgur.com/ruta-exploradores.jpg" }

                },

                new Actividad

                {

                    Nombre = "Parque Patagonia + Confluencia Río Baker & Nef",

                    Precio = "CLP 80.000 (Privado CLP 230.000)",

                    Descripcion = "Ruta sur por Carretera Austral. Miradores Lago General Carrera, Puerto Bertrand, Confluencia Baker–Nef, Parque Patagonia con museo y senderos. Incluye transporte 4x4, guía, snack.",

                    Imagenes = new List<string> { "https://i.imgur.com/parque-patagonia.jpg" }

                },

                new Actividad

                {

                    Nombre = "Confluencia Río Baker & Nef – Ruta Turquesa Indómita (Medio día)",

                    Precio = "CLP 60.000 (Privado CLP 170.000)",

                    Descripcion = "Miradores Lago General Carrera, Puerto Bertrand, río Baker y la mítica Confluencia Baker–Nef. Incluye transporte 4x4, guía, snack.",

                    Imagenes = new List<string> { "https://i.imgur.com/confluencia.jpg" }

                }

            }

            });



            // --- NUEVO: TURISMO CONTRAMAREA ---

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Turismo Contramarea",

                Categoria = TipoEmpresa.Actividad,

                // Ubicación cerca de Adventure Travel (según descripción)

                Latitud = -46.6239,

                Longitud = -72.6739,

                Descripcion = "Agencia emergente. Tours en bote, kayak, pesca y trekking. Pareja profesional con licencias y primeros auxilios. Atención de calidad.",

                Direccion = "Sector Caseta Adventure Travel, Puerto Río Tranquilo",

                Logo = "https://i.imgur.com/mbEV5qo.png", // Usamos genérico por ahora

                NumeroWhatsApp = "+56987986753",

                Imagenes = new List<string> { "https://images.unsplash.com/photo-1544551763-46a013bb70d5" }, // Kayak referencial

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Tour en Bote Simple", Precio = "CLP 20.000", Descripcion = "Navegación clásica a Capillas de Mármol.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Tour en Bote Full", Precio = "CLP 30.000", Descripcion = "Navegación completa al Santuario.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Tour en Kayak", Precio = "CLP 50.000", Descripcion = "Experiencia de remo en el lago.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Tour Laguna San Rafael", Precio = "CLP 180.000", Descripcion = "Full day al glaciar.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Tour de Pesca", Precio = "CLP 40.000/hr", Descripcion = "Por el lago General Carrera (mínimo 2 horas).", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Canyoning", Precio = "CLP 55.000", Descripcion = "Aventura y adrenalina.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } },

                    new Actividad { Nombre = "Trekking Cerro Cototo", Precio = "CLP 20.000", Descripcion = "Caminata con vistas panorámicas.", Imagenes = new List<string> { IMAGEN_GENERICA_TOUR } }

                }

            });



            // ============================================================

            // 2. RESTAURANTES

            // ============================================================



            // ====== RUEDAS Y RÍOS – MENÚ ACTUALIZADO 2025 ======

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Ruedas y Ríos",

                Categoria = TipoEmpresa.Restaurante,

                Latitud = -46.622502283801346,
               
                Longitud = -72.67559828248558,

                Descripcion = "Bar de hamburguesas y comida contundente. Happy Hour 17-20 hrs. Pet Friendly.",

                Direccion = "Carretera Austral #121",

                Logo = "https://i.imgur.com/oqPFmRj.png",

                NumeroWhatsApp = "+56962329042",

                Imagenes = new List<string>

                {

                    "https://i.imgur.com/ruedasyrios1.jpg",

                    "https://i.imgur.com/ruedasyrios2.jpg"

                },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Milanesa Pollo a lo Pobre", Precio = "CLP 15.000", Descripcion = "Milanesa cubierta de salsa de tomate y queso, acompañada de papas fritas, 2 huevos y cebolla caramelizada.", Imagenes = new List<string> { "https://i.imgur.com/milanesa-pollo.jpg" } },

                    new Actividad { Nombre = "Salmón a lo Pobre o Ensalada", Precio = "CLP 15.000", Descripcion = "Salmón regional con ensalada mixta o a lo pobre con 2 huevos y cebolla caramelizada.", Imagenes = new List<string> { "https://i.imgur.com/salmon.jpg" } },

                    new Actividad { Nombre = "Chicken and Chips", Precio = "CLP 12.000", Descripcion = "Papas fritas salteadas a la mantequilla provenzal + chicken fingers + salsa tártara estilo RyR.", Imagenes = new List<string> { "https://i.imgur.com/chicken-chips.jpg" } },

                    new Actividad { Nombre = "Chili and Nachos", Precio = "CLP 12.000", Descripcion = "Guiso de porotos negros con carne y jalapeños + nachos con queso.", Imagenes = new List<string> { "https://i.imgur.com/chili-nachos.jpg" } },

                    new Actividad { Nombre = "Con Tutti", Precio = "CLP 15.000", Descripcion = "Vacuno, longaniza, pollo, papas fritas con piel y 4 sopaipillas con pebre.", Imagenes = new List<string> { "https://i.imgur.com/con-tutti.jpg" } },

                    new Actividad { Nombre = "Bife a lo Pobre / Ensalada o Papas Salteadas", Precio = "CLP 17.000", Descripcion = "Bife de 350grs aprox. de vacuno regional + ensalada mixta o papas salteadas.", Imagenes = new List<string> { "https://i.imgur.com/bife.jpg" } },

                    new Actividad { Nombre = "Ensalada Tataki", Precio = "CLP 15.000", Descripcion = "Mix verde, palta, tomate, nueces, cranberries, semillas de zapallo y manzana + tataki de salmón marinado en salsa ponzu.", Imagenes = new List<string> { "https://i.imgur.com/tataki.jpg" } },

                    new Actividad { Nombre = "Under The Bridge", Precio = "CLP 22.500", Descripcion = "400grs de costillar de cerdo braseado en salsa bbq, cerveza y miel + coleslaw estilo 'ofqui' + papas al ajillo.", Imagenes = new List<string> { "https://i.imgur.com/under-bridge.jpg" } },

                    new Actividad { Nombre = "Rest in Peace", Precio = "CLP 18.500", Descripcion = "200grs de lomo y filete relleno de queso mantecoso + doble cheddar, tocino, aros de cebolla y salsa bbq, bañada con salsa cheddar y tocino.", Imagenes = new List<string> { "https://i.imgur.com/rest-in-peace.jpg" } },

                    new Actividad { Nombre = "Fresca y Grasosa", Precio = "CLP 15.000", Descripcion = "200grs de lomo y filete relleno de queso mantecoso + doble cheddar, tocino, mix verde y queso Azul, con una salsa especial RyR.", Imagenes = new List<string> { "https://i.imgur.com/fresca-grasosa.jpg" } }

                }

            });



            // TÍOS FELICES

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Restaurante Tíos Felices",

                Categoria = TipoEmpresa.Restaurante,

                Latitud = -46.62285388553846,

                Longitud = -72.67511215246913,

                Descripcion = "Comida casera, papas fritas naturales y cervezas. Pet Friendly. Transmisión de deportes.",

                Direccion = "Carretera Austral con Pedro Lagos N°18",

                Logo = "https://i.imgur.com/upNs8Qs.png",

                NumeroWhatsApp = "+56965172500",

                Imagenes = new List<string> { "https://images.unsplash.com/photo-1543353071-873f17a7a088", "https://images.unsplash.com/photo-1604908176997-125f25cc6f3d" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Papas Fritas Naturales", Precio = "Consultar", Descripcion = "Papas caseras recién hechas.", Imagenes = new List<string> { "https://images.unsplash.com/photo-1630384060421-cb20d0e0649d" } },

                    new Actividad { Nombre = "Comida Casera", Precio = "Variado", Descripcion = "Platos contundentes y sabrosos.", Imagenes = new List<string> { "https://images.unsplash.com/photo-1504674900247-0877df9cc836" } }

                }

            });



            // RESTAURANTE ADVENTURE TRAVEL

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Restaurante Adventure Travel",

                Categoria = TipoEmpresa.Restaurante,

                Latitud = -46.62385779567158,

                Longitud = -72.67384567344457,

                Descripcion = "Cocina gourmet patagónica, cordero al palo.",

                Direccion = "Carretera Austral",

                Logo = "https://i.imgur.com/VlaRbYT.png",

                NumeroWhatsApp = "+56964563818",

                Imagenes = new List<string> { "https://i.imgur.com/resto1.jpg", "https://i.imgur.com/cordero.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Cordero al Palo", Precio = "CLP 25.000", Descripcion = "Especialidad.", Imagenes = new List<string> { "https://i.imgur.com/cordero.jpg" } },

                    new Actividad { Nombre = "Menú Ejecutivo", Precio = "CLP 12.000", Descripcion = "Variedad de platos.", Imagenes = new List<string> { "https://i.imgur.com/resto1.jpg" } }

                }

            });



            // PIA

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Restaurante Turístico Pia",

                Categoria = TipoEmpresa.Restaurante,

                Latitud = -46.62325952198853,

                Longitud = -72.67421044190817,

                Descripcion = "Cocina tradicional y gourmet.",

                Direccion = "Carretera Austral #257",

                Logo = "https://i.imgur.com/pckIgGe.png",

                NumeroWhatsApp = "+56966127716",

                Imagenes = new List<string> { "https://i.imgur.com/pia-interior.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Platos Principales", Precio = "Desde CLP 8.000", Descripcion = "Variedad casera.", Imagenes = new List<string> { "https://i.imgur.com/pia-interior.jpg" } }

                }

            });



            // CAFÉ CHIRIFO

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Café Chirifo",

                Categoria = TipoEmpresa.Restaurante,

                Latitud = -46.62484024285427,

                Longitud = -72.67268272958664,

                Descripcion = "Cafetería, desayunos y banquetería.",

                Direccion = "Los Chochos s/n",

                Logo = "https://i.imgur.com/ItkrIeg.png",

                NumeroWhatsApp = "+56944100132",

                Imagenes = new List<string> { "https://i.imgur.com/chirifo1.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Menú del día", Precio = "CLP 15.000", Descripcion = "Opciones vegetarianas.", Imagenes = new List<string> { "https://i.imgur.com/chirifo1.jpg" } }

                }

            });



            // ============================================================

            // 3. HOSPEDAJE

            // ============================================================



            // ====== HOTEL EL PUESTO – HOSPEDAJE (ACTUALIZADO 2025-2026) ======

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Hotel El Puesto",

                Categoria = TipoEmpresa.Hospedaje,

                Latitud = -46.62509853797489,

                Longitud = -72.6773400129909,

                Descripcion = "Desconexión y naturaleza. 10 habitaciones (22 pasajeros). Desayuno continental vegetariano con productos locales. Sin TV. Estación de té/café permanente. Sello de Calidad Turística.",

                Direccion = "Puerto Río Tranquilo",

                Logo = "https://i.imgur.com/9fh1wLz.png",

                NumeroWhatsApp = "+56962073794",

                Imagenes = new List<string>

                {

                    "https://i.imgur.com/elpuesto1.jpg",

                    "https://i.imgur.com/elpuesto2.jpg",

                    "https://i.imgur.com/elpuesto-desayuno.jpg"

                },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Single Room", Precio = "1-2 noches: USD 143 | 3 noches: USD 126 | 4+ noches: USD 104", Descripcion = "Habitación individual.", Imagenes = new List<string> { "https://i.imgur.com/single.jpg" } },

                    new Actividad { Nombre = "Double Room", Precio = "1-2 noches: USD 216 | 3 noches: USD 192 | 4+ noches: USD 158", Descripcion = "Habitación doble twin o matrimonial.", Imagenes = new List<string> { "https://i.imgur.com/double.jpg" } },

                    new Actividad { Nombre = "Triple Room", Precio = "1-2 noches: USD 282 | 3 noches: USD 250 | 4+ noches: USD 205", Descripcion = "1 cama matrimonial + 1 plaza y media.", Imagenes = new List<string> { "https://i.imgur.com/triple.jpg" } },

                    new Actividad { Nombre = "Cuádruple Room", Precio = "1-2 noches: USD 336 | 3 noches: USD 298 | 4+ noches: USD 246", Descripcion = "2 camas plaza y media + 1 matrimonial.", Imagenes = new List<string> { "https://i.imgur.com/cuadruple.jpg" } },

                    new Actividad { Nombre = "Cama Adicional", Precio = "USD 72", Descripcion = "Cama extra en habitación.", Imagenes = new List<string> { "https://i.imgur.com/extra.jpg" } },

                    new Actividad { Nombre = "Cena Vegetariana (opcional)", Precio = "Reserva previa", Descripcion = "Cena casera y saludable.", Imagenes = new List<string> { "https://i.imgur.com/cena.jpg" } }

                }

            });



            // POSADA AVES AUSTRALES

            TodasLasEmpresas.Add(new Empresa

            {

                Nombre = "Posada Aves Australes",

                Categoria = TipoEmpresa.Hospedaje,

                Latitud = -46.62385779567158,
                
                Longitud = -72.67384567344457,

                Descripcion = "Habitaciones estilo tiny minimalista frente al lago.",

                Direccion = "Carretera Austral",

                Logo = "https://i.imgur.com/VlaRbYT.png",

                NumeroWhatsApp = "+56964563818",

                Imagenes = new List<string> { "https://i.imgur.com/posada1.jpg", "https://i.imgur.com/posada2.jpg" },

                Actividades = new List<Actividad>

                {

                    new Actividad { Nombre = "Habitación Baño Privado", Precio = "CLP 70.000", Descripcion = "Incluye desayuno buffet.", Imagenes = new List<string> { "https://i.imgur.com/posada1.jpg" } }

                }

            });

        }



        // --- MÉTODOS DE CONSULTA ---

        public static List<Empresa> ObtenerTodo() => TodasLasEmpresas;



        // Adaptados al modelo simple (Categoria)

        public static List<Empresa> ObtenerSoloActividades() =>

            TodasLasEmpresas.Where(e => e.Categoria == TipoEmpresa.Actividad).ToList();



        public static List<Empresa> ObtenerSoloRestaurantes() =>

            TodasLasEmpresas.Where(e => e.Categoria == TipoEmpresa.Restaurante).ToList();



        public static List<Empresa> ObtenerSoloHospedaje() =>

            TodasLasEmpresas.Where(e => e.Categoria == TipoEmpresa.Hospedaje).ToList();

    }

}