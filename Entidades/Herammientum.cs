using System;
using System.Collections.Generic;

namespace ApiRealidadVirtual.Entidades;

public partial class Herammientum
{
    public int Herramientaid { get; set; }

    public string? Nombre { get; set; }

    public string? Precio { get; set; }

    public string? Descripcion { get; set; }

    public string? Enlace { get; set; }

    public string? Imagen { get; set; }

    public sbyte? DePaga { get; set; }
}
