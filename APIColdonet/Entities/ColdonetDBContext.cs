using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class ColdonetDBContext : DbContext  
    {
        public ColdonetDBContext()
        {
        }

        public ColdonetDBContext(DbContextOptions<ColdonetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<DeudaCliente> DeudaClientes { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<SubCategorium> SubCategoria { get; set; }
        public virtual DbSet<SubUsuario> SubUsuarios { get; set; }
        public virtual DbSet<TipoComercio> TipoComercios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             if (!optionsBuilder.IsConfigured) {
                 optionsBuilder.UseSqlServer("DefaultConnection", x => x.UseNetTopologySuite());
             }
         }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdCategoria");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Categori__A3C02A1045E3740B");

                entity.Property(e => e.CodigoCategoria)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCategoria)
                .HasColumnType("text");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_categoria_usuario");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdCliente");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Cliente__D59466429DAF6FDD");

                entity.ToTable("Cliente");

                entity.Property(e => e.Abono).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DeudaTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_cliente_usuario");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdCompra");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Compra__0A5CDB5C352E4AF5");

                entity.ToTable("Compra");

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.NombreCompra)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PorPagar).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("fk_compra_proveedor");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_compra_usuario");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdDetalleCompra");

                entity.HasKey(e => e.Id)
                    .HasName("PK__DetalleC__E046CCBB74185F11");

                entity.ToTable("DetalleCompra");

                entity.Property(e => e.CantidadProductoDc).HasColumnName("CantidadProductoDC");

                entity.Property(e => e.CostoUnidad).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("fk_detallecompra_compra");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("fk_detallecompra_producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_detallecompra_usuario");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdDetalleVenta");

                entity.HasKey(e => e.Id)
                    .HasName("PK__DetalleV__AAA5CEC284321B5D");

                entity.Property(e => e.CantidadProductoDv).HasColumnName("CantidadProductoDV");

                entity.Property(e => e.CostoProductoDv)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("CostoProductoDV");

                entity.Property(e => e.FechaDetalleVenta).HasColumnType("datetime");

                entity.Property(e => e.PrecioProductoDv)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PrecioProductoDV");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_detalleventa_cliente");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("fk_detalleventa_producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_detalleventa_usuario");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("fk_detalleventa_venta");
            });

            modelBuilder.Entity<DeudaCliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdDeudaCliente");

                entity.HasKey(e => e.Id)
                    .HasName("PK__DeudaCli__51C9453FFDB3D8A8");

                entity.ToTable("DeudaCliente");

                entity.Property(e => e.ClienteDebe).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoCliente)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DeudaClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_deudacliente_cliente");

                entity.HasOne(d => d.IdDetalleVentaNavigation)
                    .WithMany(p => p.DeudaClientes)
                    .HasForeignKey(d => d.IdDetalleVenta)
                    .HasConstraintName("fk_deudacliente_detalleventa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DeudaClientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_deudacliente_usuario");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdDireccion");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Direccio__1F8E0C761AC67455");

                entity.ToTable("Direccion");

                entity.Property(e => e.Calle)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdProducto");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Producto__098892105010AF9D");

                entity.ToTable("Producto");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CostoProducto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioProdcuto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fk_categoria_producto");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSubCategoria)
                    .HasConstraintName("fk_subcategoria_producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_producto_usuario");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdProveedor");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Proveedo__E8B631AF2197D2E2");

                entity.ToTable("Proveedor");

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoProveedor)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("fk_proveedor_direccion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_proveedor_usuario");
            });

            modelBuilder.Entity<SubCategorium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdSubCategoria");

                entity.HasKey(e => e.Id)
                    .HasName("PK__SubCateg__0A1EFFE50FCDCA62");

                entity.Property(e => e.CodigoSubCategoria)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSubCategoria).HasColumnType("text");

                entity.Property(e => e.NombreSubCategoria)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fk_subcategoria_categoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_subcategoria_usuario");
            });

            modelBuilder.Entity<SubUsuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdSubUsuario");

                entity.HasKey(e => e.Id)
                    .HasName("PK__SubUsuar__268A5A4499303A5F");

                entity.ToTable("SubUsuario");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SubUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_subusuario_usuario");
            });

            modelBuilder.Entity<TipoComercio>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__TipoCome__6D8B1B6EF81A8DB1");

                entity.Property(e => e.Id).HasColumnName("IdTipoComercio");

                entity.ToTable("TipoComercio");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("IdUsuario");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Usuario__5B65BF97130DF27C");

                entity.ToTable("Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("fk_usuario_direccion");

                entity.HasOne(d => d.IdTipoComercioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoComercio)
                    .HasConstraintName("fk_usuario_tipocomercio");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {

                entity.Property(e => e.Id).HasColumnName("IdVenta");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Venta__BC1240BDB483FFE9");

                entity.Property(e => e.CostoVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FechaVenta).HasColumnType("date");

                entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_venta_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
