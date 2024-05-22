﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;

public partial class BibliotecarioContext : DbContext
{
    public BibliotecarioContext(DbContextOptions<BibliotecarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Estante> Estantes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<ListaNegra> ListaNegras { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<PrestamoBitacora> PrestamoBitacoras { get; set; }

    public virtual DbSet<PrestamoDetalle> PrestamoDetalles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C54341554");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__62EA894A0095310B");

            entity.ToTable("Estado");

            entity.HasIndex(e => e.CodEstado, "UQ__Estado__B5CFB7D31F4551D3").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.CodEstado)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codEstado");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tabla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('LIBRO')")
                .HasColumnName("tabla");
        });

        modelBuilder.Entity<Estante>(entity =>
        {
            entity.HasKey(e => e.IdEstante).HasName("PK__Estante__A83CC9D9EDFC990F");

            entity.ToTable("Estante");

            entity.Property(e => e.IdEstante).HasColumnName("idEstante");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__Inventar__8F145B0D0A7E0286");

            entity.ToTable("Inventario");

            entity.HasIndex(e => new { e.IdLibro, e.IdEstante }, "UQ__Inventar__D1433CBA64538B59").IsUnique();

            entity.Property(e => e.IdInventario).HasColumnName("idInventario");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.IdEstante).HasColumnName("idEstante");
            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.StockActual).HasColumnName("stockActual");
            entity.Property(e => e.StockInicial).HasColumnName("stockInicial");

            entity.HasOne(d => d.IdEstanteNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdEstante)
                .HasConstraintName("FK__Inventari__idEst__36B12243");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Inventari__idLib__35BCFE0A");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libro__5BC0F026BEEE99F7");

            entity.ToTable("Libro");

            entity.HasIndex(e => e.CodigoBarra, "UQ__Libro__A73A87C645BE2802").IsUnique();

            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("codigoBarra");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.NombreLibro)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombreLibro");
            entity.Property(e => e.NumeroCopias)
                .HasDefaultValueSql("((1))")
                .HasColumnName("numeroCopias");
            entity.Property(e => e.Observacion)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Libro__idCategor__30F848ED");
        });

        modelBuilder.Entity<ListaNegra>(entity =>
        {
            entity.HasKey(e => e.IdLista).HasName("PK__ListaNeg__6C8A0FE57797AB9B");

            entity.ToTable("ListaNegra");

            entity.Property(e => e.IdLista).HasColumnName("idLista");
            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Observacion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ListaNegras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ListaNegr__idUsu__3E52440B");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__A4876C13B5A33D4C");

            entity.ToTable("Prestamo");

            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.FechaPrestamo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaPrestamo");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Observacion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Prestamo__idEsta__4316F928");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prestamo__idUsua__412EB0B6");
        });

        modelBuilder.Entity<PrestamoBitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__Prestamo__223FE142278E1A8F");

            entity.ToTable("PrestamoBitacora");

            entity.Property(e => e.IdBitacora).HasColumnName("idBitacora");
            entity.Property(e => e.FechaOperacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaOperacion");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Observacion)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.PrestamoBitacoras)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__PrestamoB__idEst__4D94879B");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.PrestamoBitacoras)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK__PrestamoB__idPre__4E88ABD4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PrestamoBitacoras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__PrestamoB__idUsu__5070F446");
        });

        modelBuilder.Entity<PrestamoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdPrestamoDetalle).HasName("PK__Prestamo__0F2ADF407F76F153");

            entity.ToTable("PrestamoDetalle");

            entity.Property(e => e.IdPrestamoDetalle).HasColumnName("idPrestamoDetalle");
            entity.Property(e => e.CobroPerdida)
                .HasDefaultValueSql("((1.00))")
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("cobroPerdida");
            entity.Property(e => e.CobroPrestamo)
                .HasDefaultValueSql("((1.00))")
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("cobroPrestamo");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdEstante).HasColumnName("idEstante");
            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");
            entity.Property(e => e.Observacion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.PrestamoDetalles)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__PrestamoD__idEst__47DBAE45");

            entity.HasOne(d => d.IdEstanteNavigation).WithMany(p => p.PrestamoDetalles)
                .HasForeignKey(d => d.IdEstante)
                .HasConstraintName("FK__PrestamoD__idEst__48CFD27E");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.PrestamoDetalles)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__PrestamoD__idLib__46E78A0C");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.PrestamoDetalles)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK__PrestamoD__idPre__45F365D3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6F8E52066");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__Usuario__027C5C31A458CD8D").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.DocumentoIdentidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documentoIdentidad");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ubigeo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}