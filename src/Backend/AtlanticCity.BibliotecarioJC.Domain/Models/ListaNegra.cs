﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Models;

public partial class ListaNegra
{
    public int IdLista { get; set; }

    public int? IdUsuario { get; set; }

    public string Observacion { get; set; }

    public int? IdPrestamo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}