using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LimaLectora.Model;

namespace LimaLectora.DAL.DBContext;

public partial class LimalectoraContext : DbContext
{
    public LimalectoraContext()
    {
    }

    public LimalectoraContext(DbContextOptions<LimalectoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Areas> Areas { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Comprobantes> Comprobantes { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Generos> Generos { get; set; }

    public virtual DbSet<Libros> Libros { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Recepciones> Recepciones { get; set; }

    public virtual DbSet<Ventas> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("PK__accesos__FF937662F0767DC9");

            entity.ToTable("accesos");

            entity.Property(e => e.IdAcceso).HasColumnName("idAcceso");
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__accesos__idEmple__4316F928");
        });

        modelBuilder.Entity<Areas>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__areas__750ECEA46185B8A0");

            entity.ToTable("areas");

            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sueldo");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__885457EEE520F2CE");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Comprobantes>(entity =>
        {
            entity.HasKey(e => e.IdComprobante).HasName("PK__comproba__BF4D8CF3DB58060C");

            entity.ToTable("comprobantes");

            entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comproban__idCli__52593CB8");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comproban__idEmp__534D60F1");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comproban__idMet__5441852A");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__5295297C13D63C10");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("date")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK__empleados__idAre__3F466844");
        });

        modelBuilder.Entity<Generos>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__generos__85223DA30C751B54");

            entity.ToTable("generos");

            entity.Property(e => e.IdGenero).HasColumnName("idGenero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Libros>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__libros__5BC0F026C0F1F53D");

            entity.ToTable("libros");

            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.AnioPublicacion).HasColumnName("anioPublicacion");
            entity.Property(e => e.Autor)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Editorial)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("editorial");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.IdGenero).HasColumnName("idGenero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock)
                .HasDefaultValueSql("((0))")
                .HasColumnName("stock");
            entity.Property(e => e.Url)
                .HasMaxLength(550)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK__libros__idGenero__45F365D3");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__metodoPa__817BFC325704C0CD");

            entity.ToTable("metodoPagos");

            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__proveedo__A3FA8E6B6C277726");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Recepciones>(entity =>
        {
            entity.HasKey(e => e.IdRecepcion).HasName("PK__recepcio__82211839029AB3DD");

            entity.ToTable("recepciones");

            entity.Property(e => e.IdRecepcion).HasColumnName("idRecepcion");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("date")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recepcion__idEmp__4E88ABD4");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.IdLibro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recepcion__idLib__4D94879B");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recepcion__idPro__4F7CD00D");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__ventas__077D5614D94BFEE5");

            entity.ToTable("ventas");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");
            entity.Property(e => e.Idlibro).HasColumnName("idlibro");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdComprobante)
                .HasConstraintName("FK__ventas__idCompro__5812160E");

            entity.HasOne(d => d.IdlibroNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idlibro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ventas__idlibro__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
