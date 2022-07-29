namespace apiTAE.Models
{
    public class DestinoModel
    {
        public int IdDestino { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public int Capacidad { get; set; }
        public string? IMG { get; set; }
        public int Provincia { get; set; }
        public int Clasificacion_Edad { get; set; }
        public int Facilidad { get; set; }
        public int Actividad_Principal { get; set; }
        public string? Clase { get; set; }

        public string? Latitud { get; set; }
        public string? Longitud { get; set; }

    }
}
