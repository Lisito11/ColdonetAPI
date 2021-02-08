using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore;
#nullable disable

namespace APIColdonet.Entities
{
    public partial class ColdonetDBContext : IdentityDbContext  
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


        // public virtual DbSet<CompraProveedores> CompraProveedores { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             if (!optionsBuilder.IsConfigured) {
                 optionsBuilder.UseSqlServer("DefaultConnection", x => x.UseNetTopologySuite());
             }
         }*/

        /* modelBuilder.Entity<IdentityUser>(entity => 
 {
     entity.HasKey(e => e.Id).HasName("PK_Usuario");
 });
 modelBuilder.Entity<IdentityUserLogin<int>>(entity => {
     entity.HasKey(e => e.UserId).HasName("PK_UsuarioLogin");
     entity.ToTable("AspNetUserLogins");
 });*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idcategoria");

                entity.ToTable("categoria");


                entity.HasKey(e => e.Id)
                    .HasName("PK__Categori__A3C02A1045E3740B");

                entity.Property(e => e.CodigoCategoria).HasColumnName("codigocategoria")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCategoria).HasColumnName("descripcioncategoria")
                .HasColumnType("text");

                entity.Property(e => e.NombreCategoria).HasColumnName("nombrecategoria")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_categoria_usuario");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idcliente");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Cliente__D59466429DAF6FDD");

                entity.ToTable("cliente");

                entity.Property(e => e.Abono).HasColumnType("decimal(10, 2)").HasColumnName("abono");

                entity.Property(e => e.DeudaTotal).HasColumnType("decimal(10, 2)").HasColumnName("deudatotal");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
                
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_cliente_usuario");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idcompra");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Compra__0A5CDB5C352E4AF5");

                entity.ToTable("compra");

                entity.Property(e => e.FechaCompra).HasColumnType("date").HasColumnName("fechacompra");

                entity.Property(e => e.NombreCompra).HasColumnName("nombrecompra")
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PorPagar).HasColumnType("decimal(10, 2)").HasColumnName("porpagar");

                entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)").HasColumnName("totalcompra");

                entity.Property(e => e.EstatusCompra).HasColumnName("estatuscompra");

                entity.Property(e => e.IdProveedor).HasColumnName("idproveedor");

                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d=> d.IdProveedor)
                    .HasConstraintName("fk_compra_proveedor");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d=> d.IdUsuario)
                    .HasConstraintName("fk_compra_usuario");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("iddetallecompra");

                entity.HasKey(e => e.Id)
                    .HasName("PK__DetalleC__E046CCBB74185F11");

                entity.ToTable("detallecompra");

                entity.Property(e => e.CantidadProductoDc).HasColumnName("cantidadproductodc");

                entity.Property(e => e.CostoUnidad).HasColumnType("decimal(10, 2)").HasColumnName("costounidad");

                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");
                entity.Property(e => e.IdProducto).HasColumnName("idproducto");
                entity.Property(e => e.IdCompra).HasColumnName("idcompra");


                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d=> d.IdCompra)
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
                entity.Property(e => e.Id).HasColumnName("iddetalleventa");

                entity.ToTable("detalleventa");


                entity.HasKey(e => e.Id)
                    .HasName("PK__DetalleV__AAA5CEC284321B5D");

                entity.Property(e => e.CantidadProductoDv).HasColumnName("cantidadproductodv");

                entity.Property(e => e.CostoProductoDv)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("costoproductodv");

                entity.Property(e => e.FechaDetalleVenta).HasColumnType("datetime").HasColumnName("fechadetalleventa");
                
                entity.Property(e => e.EstatusDetalleVenta).HasColumnName("estatusdetalleventa");
                
                entity.Property(e => e.IdProducto).HasColumnName("idproducto");
                
                entity.Property(e => e.IdCliente).HasColumnName("idcliente");
                
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");

                entity.Property(e => e.IdVenta).HasColumnName("idventa");




                entity.Property(e => e.PrecioProductoDv)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioproductodv");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d=> d.IdCliente)
                    .HasConstraintName("fk_detalleventa_cliente");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d=> d.IdProducto)
                    .HasConstraintName("fk_detalleventa_producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d=>d.IdUsuario)
                    .HasConstraintName("fk_detalleventa_usuario");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d=>d.IdVenta)
                    .HasConstraintName("fk_detalleventa_venta");
            });

            modelBuilder.Entity<DeudaCliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("iddeudacliente");

                entity.HasKey(e => e.Id)
                    .HasName("PK__DeudaCli__51C9453FFDB3D8A8");

                entity.ToTable("deudacliente");

                entity.Property(e => e.ClienteDebe).HasColumnType("decimal(10, 2)").HasColumnName("clientedebe");

                entity.Property(e => e.ProductoCliente).HasColumnName("productocliente")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusDeudaCliente).HasColumnName("estatusdeudacliente");

                entity.Property(e => e.IdCliente).HasColumnName("idcliente");
                entity.Property(e => e.IdDetalleVenta).HasColumnName("iddetalleventa");
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DeudaClientes)
                    .HasForeignKey(d=>d.IdCliente)
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
                entity.Property(e => e.Id).HasColumnName("iddireccion");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Direccio__1F8E0C761AC67455");

                entity.ToTable("direccion");

                entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");


                entity.Property(e => e.Calle).HasColumnName("calle")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad).HasColumnName("ciudad")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Sector).HasColumnName("sector")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idproducto");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Producto__098892105010AF9D");

                entity.ToTable("producto");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigoproducto")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CostoProducto).HasColumnType("decimal(10, 2)").HasColumnName("costoproducto");

                entity.Property(e => e.NombreProducto).HasColumnName("nombreproducto")
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioProdcuto).HasColumnType("decimal(10, 2)").HasColumnName("precioprodcuto");
                entity.Property(e => e.EstatusProducto).HasColumnName("estatusproducto");
                entity.Property(e => e.CantidadProducto).HasColumnName("cantidadproducto");
                entity.Property(e => e.Pesado).HasColumnName("pesado");


                entity.Property(e => e.IdCategoria).HasColumnName("idcategoria");
                entity.Property(e => e.IdSubCategoria).HasColumnName("idsubcategoria");
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");




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
                entity.Property(e => e.Id).HasColumnName("idproveedor");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Proveedo__E8B631AF2197D2E2");

                entity.ToTable("proveedor");

                entity.Property(e => e.NombreProveedor).HasColumnName("nombreproveedor")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoProveedor).HasColumnName("telefonoproveedor")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdDireccion).HasColumnName("iddireccion");
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


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
                entity.Property(e => e.Id).HasColumnName("idsubcategoria");
                entity.ToTable("subcategoria");

                entity.HasKey(e => e.Id)
                    .HasName("PK__SubCateg__0A1EFFE50FCDCA62");

                entity.Property(e => e.CodigoSubCategoria).HasColumnName("codigosubcategoria")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSubCategoria).HasColumnType("text").HasColumnName("descripcionsubcategoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idcategoria");
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");

                entity.Property(e => e.NombreSubCategoria).HasColumnName("nombresubcategoria")
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
                entity.Property(e => e.Id).HasColumnName("idsubusuario");

                entity.HasKey(e => e.Id)
                    .HasName("PK__SubUsuar__268A5A4499303A5F");

                entity.ToTable("subusuario");

                entity.Property(e => e.Apellido1).HasColumnName("apellido1")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2).HasColumnName("apellido2")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Celular).HasColumnName("celular")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña).HasColumnName("contraseña")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date").HasColumnName("fechaingreso");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSubUsuario).HasColumnName("estatussubusuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SubUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_subusuario_usuario");
            });

            modelBuilder.Entity<TipoComercio>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__TipoCome__6D8B1B6EF81A8DB1");

                entity.Property(e => e.Id).HasColumnName("idtipocomercio");

                entity.ToTable("tipocomercio");

                entity.Property(e => e.Descripcion).HasColumnType("text").HasColumnName("descripcion");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idusuario");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Usuario__5B65BF97130DF27C");

                entity.ToTable("usuario");

                entity.Property(e => e.Contraseña).HasColumnName("contraseña")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasColumnName("email")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date").HasColumnName("fechaingreso");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusUsuario).HasColumnName("estatususuario");
                entity.Property(e => e.Delivery).HasColumnName("delivery");
               
                entity.Property(e => e.IdDireccion).HasColumnName("iddireccion");
                entity.Property(e => e.IdTipoComercio).HasColumnName("idtipocomercio");




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

                entity.Property(e => e.Id).HasColumnName("idventa");

                entity.HasKey(e => e.Id)
                    .HasName("PK__Venta__BC1240BDB483FFE9");
                entity.ToTable("venta");

                entity.Property(e => e.CostoVenta).HasColumnType("decimal(10, 2)").HasColumnName("costoventa");

                entity.Property(e => e.FechaVenta).HasColumnType("date").HasColumnName("fechaventa");

                entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)").HasColumnName("totalventa");

                entity.Property(e => e.EstatusVenta).HasColumnName("estatusventa");
                
                entity.Property(e => e.IdUsuario).HasColumnName("idusuario");


                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_venta_usuario");
            });
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);

           // OnModelCreatingPartial(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder) {
            var rolAdminId = "9aae0b6d-d50c-4d0a-9b90-2a6873e3845d";
            var usuarioAdminId = "5673b8cf-12de-44f6-92ad-fae4a77932ad";

            var rolAdmin = new IdentityRole() {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var username = "l.andrespg11@gmail.com";

            var usuarioAdmin = new IdentityUser() {
                Id = usuarioAdminId,
                UserName = username,
                NormalizedUserName = username,
                Email = username,
                NormalizedEmail = username,
                PasswordHash = passwordHasher.HashPassword(null, "Andres.Lisito01!")
            };
            
          /*  modelBuilder.Entity<IdentityUser>()
                .HasData(usuarioAdmin);

            modelBuilder.Entity<IdentityRole>()
                .HasData(rolAdmin);

            modelBuilder.Entity<IdentityUserClaim<string>>()
               .HasData(new IdentityUserClaim<string>()
               {
                   Id = 1,
                   ClaimType = ClaimTypes.Role,
                   UserId = usuarioAdminId,
                    ClaimValue = "Admin"
                });*/
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
