using System;
using System.Collections.Generic;
using System.Text;
public class Lugar
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Direccion { get; set; }
    public string Servicio { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string NumeroWhatsApp { get; set; }
    public List<string> Imagenes { get; set; } = new List<string>();
    public string Logo { get; set; }
}


