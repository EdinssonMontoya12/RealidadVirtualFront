namespace ApiRealidadVirtual.Entidades
{
    public class AnexoCreate
    {
        public string Descripcion { get; set; } = null!;

        public string? Url { get; set; }
    }

    public class AnexoConsultar
    {
        public int Anexoid { get; set; }

        public string Descripcion { get; set; } = null!;

        public string? Url { get; set; }
    }    
}
