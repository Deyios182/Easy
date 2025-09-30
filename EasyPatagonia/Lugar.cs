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
    public string NumeroWhatsApp { get; set; }  // Nueva propiedad para el número de WhatsApp
    public List<string> Imagenes { get; set; }  // Lista para las imágenes
    public string Logo { get; set; }
}


