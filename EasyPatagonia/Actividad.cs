using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EasyPatagonia.Models
{
    public class Actividad
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }  

        [JsonProperty("description")]
        public string Descripcion { get; set; }

        [JsonProperty("price")]
        public string Precio { get; set; }  

        [JsonProperty("image_url")]
        public string Imagen { get; set; }

        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }

        [JsonIgnore]
        public List<string> Imagenes { get; set; } = new List<string>(); 
    }
}
