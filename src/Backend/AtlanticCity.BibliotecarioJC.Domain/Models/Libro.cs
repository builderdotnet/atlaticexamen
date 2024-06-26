﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string NombreLibro { get; set; }

    public string CodigoBarra { get; set; }

    public int? NumeroCopias { get; set; }

    public int? IdCategoria { get; set; }

    public bool? EsActivo { get; set; }

    public string Observacion { get; set; }

    public virtual Categorium IdCategoriaNavigation { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<PrestamoDetalle> PrestamoDetalles { get; set; } = new List<PrestamoDetalle>();
}