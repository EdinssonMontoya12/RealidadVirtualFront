using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiRealidadVirtual.Entidades;

public partial class RealidadVirtualContext : DbContext
{
    public RealidadVirtualContext()
    {
    }

    public RealidadVirtualContext(DbContextOptions<RealidadVirtualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anexo> Anexos { get; set; }

    public virtual DbSet<Herammientum> Herammienta { get; set; }

    public virtual DbSet<Lenguaje> Lenguajes { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Tiporecurso> Tiporecursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL($"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
            $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
            $"Database=RealidadVirtual;" +
            $"Uid={Environment.GetEnvironmentVariable("DB_USER")};" +
            $"Pwd={Environment.GetEnvironmentVariable("DB_PW")}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anexo>(entity =>
        {
            entity.HasKey(e => e.Anexoid).HasName("PRIMARY");

            entity.ToTable("anexo");

            entity.HasIndex(e => e.Lenguajeid, "FK_anexo_lenguajeid");

            entity.Property(e => e.Anexoid).HasColumnName("anexoid");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Lenguajeid).HasColumnName("lenguajeid");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.Lenguaje).WithMany(p => p.Anexos)
                .HasForeignKey(d => d.Lenguajeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_anexo_lenguajeid");
        });

        modelBuilder.Entity<Herammientum>(entity =>
        {
            entity.HasKey(e => e.Herramientaid).HasName("PRIMARY");

            entity.ToTable("herammienta");

            entity.Property(e => e.Herramientaid).HasColumnName("herramientaid");
            entity.Property(e => e.DePaga)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dePaga");
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Enlace).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasMaxLength(255);
        });

        modelBuilder.Entity<Lenguaje>(entity =>
        {
            entity.HasKey(e => e.Lenguajeid).HasName("PRIMARY");

            entity.ToTable("lenguaje");

            entity.Property(e => e.Lenguajeid).HasColumnName("lenguajeid");
            entity.Property(e => e.Descripcion)
                .HasColumnType("mediumtext")
                .HasColumnName("descripcion");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.Recursoid).HasName("PRIMARY");

            entity.ToTable("recurso");

            entity.Property(e => e.Recursoid).HasColumnName("recursoid");
            entity.Property(e => e.DePaga)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dePaga");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .HasColumnName("descripcion");
            entity.Property(e => e.Enlace)
                .HasMaxLength(255)
                .HasColumnName("enlace");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasMaxLength(255)
                .HasColumnName("precio");
            entity.Property(e => e.Tiporecid).HasColumnName("tiporecid");
        });

        modelBuilder.Entity<Tiporecurso>(entity =>
        {
            entity.HasKey(e => e.Tiporecid).HasName("PRIMARY");

            entity.ToTable("tiporecurso");

            entity.Property(e => e.Tiporecid).HasColumnName("tiporecid");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
