namespace ApiRealidadVirtual.Entidades
{
    public class HerammientumCreate
    {
        public string? Nombre { get; set; }

        public string? Precio { get; set; }

        public string? Descripcion { get; set; }

        public string? Enlace { get; set; }

        public string? Imagen { get; set; }

        public bool DePaga { get; set; }
    }

    public partial class HerammientumConsultar
    {
        public int Herramientaid { get; set; }

        public string? Nombre { get; set; }

        public string? Precio { get; set; }

        public string? Descripcion { get; set; }

        public string? Enlace { get; set; }

        public string? Imagen { get; set; }

        public bool DePaga { get; set; }
    }
}
