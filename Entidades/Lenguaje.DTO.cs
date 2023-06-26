namespace ApiRealidadVirtual.Entidades
{
    public class LenguajeCreate
    {
        public string? Imagen { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Titulo { get; set; } = null!;

        public List<AnexoCreate> Anexos { get; set; } = new List<AnexoCreate>();
    }

    public class LenguajeConsultar
    {
        public int Lenguajeid { get; set; }

        public string? Imagen { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Titulo { get; set; } = null!;

        public List<AnexoConsultar> Anexos { get; set; } = new List<AnexoConsultar>();
    }
}
