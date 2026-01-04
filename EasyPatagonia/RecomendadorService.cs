using System;
using System.Collections.Generic;
using System.Linq;
using EasyPatagonia.Models;

namespace EasyPatagonia.Services
{
    public class ItinerarioSugerido
    {
        public List<DiaItinerario> Dias { get; set; } = new List<DiaItinerario>();
        public decimal CostoTotal { get; set; }
        public string MensajeIA { get; set; }
    }

    public class DiaItinerario
    {
        public int DiaNumero { get; set; }
        public Empresa Actividad { get; set; }
        public Empresa Comida { get; set; }
        public Empresa Alojamiento { get; set; } // Nuevo: Alojamiento
        public decimal CostoDia { get; set; }
    }

    public static class RecomendadorService
    {
        public static ItinerarioSugerido GenerarItinerario(decimal presupuesto, int dias, int personas, bool incluirActividades, bool incluirComidas, bool incluirAlojamiento)
        {
            var itinerario = new ItinerarioSugerido();
            var random = new Random();

            // 1. Obtener datos reales
            var actividades = incluirActividades ? DatosService.ObtenerSoloActividades() : new List<Empresa>();
            var restaurantes = incluirComidas ? DatosService.ObtenerSoloRestaurantes() : new List<Empresa>();
            var alojamientos = incluirAlojamiento ? DatosService.ObtenerSoloHospedaje() : new List<Empresa>();

            // Barajamos las listas
            actividades = actividades.OrderBy(x => random.Next()).ToList();
            restaurantes = restaurantes.OrderBy(x => random.Next()).ToList();
            alojamientos = alojamientos.OrderBy(x => random.Next()).ToList();

            decimal costoAcumulado = 0;
            int actividadIndex = 0;
            int restauranteIndex = 0;
            int alojamientoIndex = 0;

            // 2. Armar el plan día por día
            for (int i = 1; i <= dias; i++)
            {
                var dia = new DiaItinerario { DiaNumero = i };
                decimal costoDia = 0;

                // A. Alojamiento (Prioridad alta para asegurar lugar donde dormir)
                if (incluirAlojamiento && alojamientos.Count > 0)
                {
                    // Intentamos mantener el mismo alojamiento si es posible, o rotar si se prefiere
                    // Aquí rotamos para dar variedad en la sugerencia
                    var aloj = alojamientos[alojamientoIndex % alojamientos.Count];

                    // Precio estimado promedio por noche si no hay dato exacto
                    decimal precioAloj = 40000; // CLP por noche base doble aprox.

                    // Intentamos buscar precio real si existe en actividades
                    if (aloj.Actividades.Any())
                        precioAloj = ExtraerPrecio(aloj.Actividades.FirstOrDefault()?.Precio);

                    if ((costoAcumulado + costoDia + precioAloj) <= presupuesto)
                    {
                        dia.Alojamiento = aloj;
                        costoDia += precioAloj; // Asumimos precio por habitación/noche, o ajustar por persona
                    }
                }

                // B. Actividad
                if (incluirActividades && actividadIndex < actividades.Count)
                {
                    var act = actividades[actividadIndex];
                    decimal precioAct = ExtraerPrecio(act.Actividades.FirstOrDefault()?.Precio);

                    if ((costoAcumulado + costoDia + (precioAct * personas)) <= presupuesto)
                    {
                        dia.Actividad = act;
                        costoDia += precioAct * personas;
                        actividadIndex++;
                    }
                }

                // C. Comida
                if (incluirComidas && restauranteIndex < restaurantes.Count)
                {
                    var rest = restaurantes[restauranteIndex];
                    decimal precioComida = 15000;

                    if ((costoAcumulado + costoDia + (precioComida * personas)) <= presupuesto)
                    {
                        dia.Comida = rest;
                        costoDia += precioComida * personas;
                        restauranteIndex++;
                    }
                }

                // Si no logramos agendar nada por falta de dinero, paramos
                if (dia.Actividad == null && dia.Comida == null && dia.Alojamiento == null && i > 1) break;

                dia.CostoDia = costoDia;
                costoAcumulado += costoDia;
                itinerario.Dias.Add(dia);

                // Avanzar índice de alojamiento solo si queremos cambiar cada día (opcional)
                // alojamientoIndex++; 
            }

            itinerario.CostoTotal = costoAcumulado;

            if (costoAcumulado == 0)
                itinerario.MensajeIA = "El presupuesto es muy bajo para las opciones seleccionadas.";
            else
                itinerario.MensajeIA = $"¡Plan listo! Basado en {personas} personas durante {dias} días.";

            return itinerario;
        }

        private static decimal ExtraerPrecio(string precioTexto)
        {
            if (string.IsNullOrEmpty(precioTexto)) return 0;
            string numero = new string(precioTexto.Where(char.IsDigit).ToArray());
            if (decimal.TryParse(numero, out decimal precio)) return precio;
            return 0;
        }
    }
}