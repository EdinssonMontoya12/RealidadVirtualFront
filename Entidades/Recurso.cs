using System;
using System.Collections.Generic;

namespace ApiRealidadVirtual.Entidades;

public partial class Recurso
{
    public int Recursoid { get; set; }

    public string? Nombre { get; set; }

    public string? Precio { get; set; }

    public string? Descripcion { get; set; }

    public string? Enlace { get; set; }

    public int? Tiporecid { get; set; }

    public sbyte? DePaga { get; set; }
}
