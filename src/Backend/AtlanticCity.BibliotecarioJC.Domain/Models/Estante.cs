﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Models;

public partial class Estante
{
    public int IdEstante { get; set; }

    public string Nombre { get; set; }

    public bool? EsActivo { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<PrestamoDetalle> PrestamoDetalles { get; set; } = new List<PrestamoDetalle>();
}