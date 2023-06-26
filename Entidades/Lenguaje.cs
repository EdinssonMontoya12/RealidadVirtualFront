using System;
using System.Collections.Generic;

namespace ApiRealidadVirtual.Entidades;

public partial class Lenguaje
{
    public int Lenguajeid { get; set; }

    public string? Imagen { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Anexo> Anexos { get; set; } = new List<Anexo>();
}
