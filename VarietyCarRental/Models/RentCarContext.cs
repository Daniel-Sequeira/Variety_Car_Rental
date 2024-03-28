using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VarietyCarRental.Models;

public partial class RentCarContext : DbContext
{
    public RentCarContext()
    {
    }

    public RentCarContext(DbContextOptions<RentCarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCliente> TblClientes { get; set; }

    public virtual DbSet<TblHistorial> TblHistorials { get; set; }

    public virtual DbSet<TblMantenimiento> TblMantenimientos { get; set; }

    public virtual DbSet<TblPoliza> TblPolizas { get; set; }

    public virtual DbSet<TblReserva> TblReservas { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    public virtual DbSet<TblVehiculo> TblVehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DanielsPC\\SQLEXPRESS;Initial Catalog=RentCar;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("emailCliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblHistorial>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("TblHistorial");

            entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
        });

        modelBuilder.Entity<TblMantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento);

            entity.ToTable("TblMantenimiento");

            entity.Property(e => e.IdMantenimiento)
                .ValueGeneratedNever()
                .HasColumnName("idMantenimiento");
            entity.Property(e => e.CostoMantenimiento)
                .HasColumnType("money")
                .HasColumnName("costoMantenimiento");
            entity.Property(e => e.DescripcionMantenimiento)
                .IsUnicode(false)
                .HasColumnName("descripcionMantenimiento");
            entity.Property(e => e.IdPoliza).HasColumnName("idPoliza");

            entity.HasOne(d => d.IdPolizaNavigation).WithMany(p => p.TblMantenimientos)
                .HasForeignKey(d => d.IdPoliza)
                .HasConstraintName("FK_TblMantenimiento_TblPolizas");
        });

        modelBuilder.Entity<TblPoliza>(entity =>
        {
            entity.HasKey(e => e.IdPoliza);

            entity.Property(e => e.IdPoliza)
                .ValueGeneratedNever()
                .HasColumnName("idPoliza");
            entity.Property(e => e.CostoPoliza)
                .HasColumnType("money")
                .HasColumnName("costoPoliza");
            entity.Property(e => e.DescripcionPoliza)
                .IsUnicode(false)
                .HasColumnName("descripcionPoliza");
        });

        modelBuilder.Entity<TblReserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.CostoTotal)
                .HasColumnType("money")
                .HasColumnName("costoTotal");
            entity.Property(e => e.FechaFinReserva).HasColumnName("fechaFinReserva");
            entity.Property(e => e.FechaInicioReserva).HasColumnName("fechaInicioReserva");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdPoliza).HasColumnName("idPoliza");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_TblReservas_TblClientes");

            entity.HasOne(d => d.IdPolizaNavigation).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.IdPoliza)
                .HasConstraintName("FK_TblReservas_TblPolizas");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_TblReservas_TblUsuarios");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK_TblReservas_TblVehiculo");
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("TblRol");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios);

            entity.Property(e => e.IdUsuarios)
                .ValueGeneratedNever()
                .HasColumnName("idUsuarios");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_TblUsuarios_TblRol");
        });

        modelBuilder.Entity<TblVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo);

            entity.ToTable("TblVehiculo");

            entity.Property(e => e.IdVehiculo)
                .ValueGeneratedNever()
                .HasColumnName("idVehiculo");
            entity.Property(e => e.Capacidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("capacidad");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.PrecioDia)
                .HasColumnType("money")
                .HasColumnName("precioDia");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
