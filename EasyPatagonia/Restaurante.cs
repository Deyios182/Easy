using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPatagonia.Models
{
    public class Restaurante
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
    }
}