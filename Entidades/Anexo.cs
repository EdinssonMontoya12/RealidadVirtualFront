using System;
using System.Collections.Generic;

namespace ApiRealidadVirtual.Entidades;

public partial class Anexo
{
    public int Anexoid { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Url { get; set; }

    public int? Lenguajeid { get; set; }

    public virtual Lenguaje? Lenguaje { get; set; }
}
