using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace APIColdonet.Migrations
{
    public partial class InitialDbChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) {

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });
        }
        /*
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true),
                    Calle = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Sector = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__1F8E0C761AC67455", x => x.IdDireccion);
                });

            migrationBuilder.CreateTable(
                name: "TipoComercio",
                columns: table => new
                {
                    IdTipoComercio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoCome__6D8B1B6EF81A8DB1", x => x.IdTipoComercio);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Contraseña = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: true),
                    Delivery = table.Column<int>(type: "int", nullable: true),
                    EstatusUsuario = table.Column<int>(type: "int", nullable: true),
                    IdTipoComercio = table.Column<int>(type: "int", nullable: true),
                    IdDireccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF97130DF27C", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "fk_usuario_direccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_usuario_tipocomercio",
                        column: x => x.IdTipoComercio,
                        principalTable: "TipoComercio",
                        principalColumn: "IdTipoComercio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCategoria = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NombreCategoria = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DescripcionCategoria = table.Column<string>(type: "text", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A3C02A1045E3740B", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "fk_categoria_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Abono = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DeudaTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__D59466429DAF6FDD", x => x.IdCliente);
                    table.ForeignKey(
                        name: "fk_cliente_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TelefonoProveedor = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    IdDireccion = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__E8B631AF2197D2E2", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "fk_proveedor_direccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_proveedor_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubUsuario",
                columns: table => new
                {
                    IdSubUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Apellido1 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Apellido2 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Celular = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: true),
                    EstatusSubUsuario = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubUsuar__268A5A4499303A5F", x => x.IdSubUsuario);
                    table.ForeignKey(
                        name: "fk_subusuario_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CostoVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "date", nullable: true),
                    EstatusVenta = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venta__BC1240BDB483FFE9", x => x.IdVenta);
                    table.ForeignKey(
                        name: "fk_venta_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    IdSubCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSubCategoria = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NombreSubCategoria = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DescripcionSubCategoria = table.Column<string>(type: "text", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubCateg__0A1EFFE50FCDCA62", x => x.IdSubCategoria);
                    table.ForeignKey(
                        name: "fk_subcategoria_categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_subcategoria_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompra = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: true),
                    TotalCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstatusCompra = table.Column<int>(type: "int", nullable: true),
                    PorPagar = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IdProveedor = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__0A5CDB5C352E4AF5", x => x.IdCompra);
                    table.ForeignKey(
                        name: "fk_compra_proveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_compra_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NombreProducto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PrecioProdcuto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CostoProducto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CantidadProducto = table.Column<int>(type: "int", nullable: true),
                    EstatusProducto = table.Column<int>(type: "int", nullable: true),
                    Pesado = table.Column<int>(type: "int", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdSubCategoria = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__098892105010AF9D", x => x.IdProducto);
                    table.ForeignKey(
                        name: "fk_categoria_producto",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_producto_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_subcategoria_producto",
                        column: x => x.IdSubCategoria,
                        principalTable: "SubCategoria",
                        principalColumn: "IdSubCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostoUnidad = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CantidadProductoDC = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    IdCompra = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleC__E046CCBB74185F11", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "fk_detallecompra_compra",
                        column: x => x.IdCompra,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detallecompra_producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detallecompra_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    IdDetalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusDetalleVenta = table.Column<int>(type: "int", nullable: true),
                    PrecioProductoDV = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CantidadProductoDV = table.Column<int>(type: "int", nullable: true),
                    CostoProductoDV = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaDetalleVenta = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdVenta = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__AAA5CEC284321B5D", x => x.IdDetalleVenta);
                    table.ForeignKey(
                        name: "fk_detalleventa_cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detalleventa_producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detalleventa_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detalleventa_venta",
                        column: x => x.IdVenta,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeudaCliente",
                columns: table => new
                {
                    IdDeudaCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteDebe = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstatusDeudaCliente = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdDetalleVenta = table.Column<int>(type: "int", nullable: true),
                    ProductoCliente = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DeudaCli__51C9453FFDB3D8A8", x => x.IdDeudaCliente);
                    table.ForeignKey(
                        name: "fk_deudacliente_cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_deudacliente_detalleventa",
                        column: x => x.IdDetalleVenta,
                        principalTable: "DetalleVenta",
                        principalColumn: "IdDetalleVenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_deudacliente_usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdUsuario",
                table: "Categoria",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdUsuario",
                table: "Cliente",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdProveedor",
                table: "Compra",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdUsuario",
                table: "Compra",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdCompra",
                table: "DetalleCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdProducto",
                table: "DetalleCompra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdUsuario",
                table: "DetalleCompra",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdCliente",
                table: "DetalleVenta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdProducto",
                table: "DetalleVenta",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdUsuario",
                table: "DetalleVenta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdVenta",
                table: "DetalleVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DeudaCliente_IdCliente",
                table: "DeudaCliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_DeudaCliente_IdDetalleVenta",
                table: "DeudaCliente",
                column: "IdDetalleVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DeudaCliente_IdUsuario",
                table: "DeudaCliente",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdSubCategoria",
                table: "Producto",
                column: "IdSubCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdUsuario",
                table: "Producto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdDireccion",
                table: "Proveedor",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdUsuario",
                table: "Proveedor",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_IdCategoria",
                table: "SubCategoria",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_IdUsuario",
                table: "SubCategoria",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_SubUsuario_IdUsuario",
                table: "SubUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdDireccion",
                table: "Usuario",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoComercio",
                table: "Usuario",
                column: "IdTipoComercio");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta",
                column: "IdUsuario");
        }*/

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DeudaCliente");

            migrationBuilder.DropTable(
                name: "SubUsuario");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "TipoComercio");
        }
    }
}
