using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EasyPatagonia.Models
{
    // 1. Enum para diferenciar tipos de negocios
    public enum TipoEmpresa
    {
        Actividad,    
        Hospedaje,    
        Restaurante,  
        Otro
    }

    public class Empresa
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }  

        [JsonProperty("description")]
        public string Descripcion { get; set; }

        [JsonProperty("address")]
        public string Direccion { get; set; }

        [JsonProperty("whatsapp")]
        public string NumeroWhatsApp { get; set; }

        [JsonProperty("logo_url")]
        public string Logo { get; set; } // URL del logo

        // Coordenadas para el Mapa
        [JsonProperty("latitude")]
        public double Latitud { get; set; } 

        [JsonProperty("longitude")]
        public double Longitud { get; set; }

        // Categoría para filtrar
        [JsonProperty("category")]
        public TipoEmpresa Categoria { get; set; }

        // Lista de Servicios, Tours o Platos (Se cargarán por separado)
        [JsonIgnore]
        public List<Actividad> Actividades { get; set; } = new List<Actividad>();       

        // Galería de fotos general
        [JsonProperty("gallery_urls")]
        public List<string> Imagenes { get; set; } = new List<string>();
    }
}
