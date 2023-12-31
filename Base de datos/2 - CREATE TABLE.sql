USE BD_Belleza
GO

CREATE TABLE dbo.tbl_Productos
(ProductoId int IDENTITY(1,1) PRIMARY KEY,
Descripcion varchar(100) NOT NULL,
Valor money NOT NULL,
Estado bit NOT NULL,
FechaRegistro datetime NULL,
FechaActualizacion datetime NULL)

CREATE TABLE dbo.tbl_InventarioColores
(InventarioColoresId int IDENTITY(1,1) PRIMARY KEY,
Descripcion varchar(100) NOT NULL,
Cantidad int NOT NULL,
ProductoId int NOT NULL,
FOREIGN KEY (ProductoId) REFERENCES dbo.tbl_Productos (ProductoId))

CREATE TABLE dbo.tbl_Departamentos
(DepartamentoId int IDENTITY(1,1) PRIMARY KEY,
Descripcion varchar(200) NULL,
Estado bit NULL)

CREATE TABLE dbo.tbl_DepartamentoProductos
(DepartamentoProductoId int IDENTITY(1,1) PRIMARY KEY,
ProductoId int NOT NULL,
DepartamentoId int NOT NULL,
FOREIGN KEY (ProductoId) REFERENCES dbo.tbl_Productos (ProductoId),
FOREIGN KEY (DepartamentoId) REFERENCES dbo.tbl_Departamentos (DepartamentoId))

CREATE TABLE dbo.tbl_Promociones
(PromocionId int IDENTITY(1,1) PRIMARY KEY,
Descripcion varchar(200) NULL,
Porcentaje int NULL,
ValorPromocion money NULL)

CREATE TABLE dbo.tbl_Separados
(SeparadoId int IDENTITY(1,1) PRIMARY KEY,
ProductoId int NOT NULL,
PromocionId int NOT NULL,
ValorSeparado money NOT NULL,
FOREIGN KEY (ProductoId) REFERENCES dbo.tbl_Productos (ProductoId),
FOREIGN KEY (PromocionId) REFERENCES dbo.tbl_Promociones (PromocionId))

CREATE TABLE dbo.tbl_Clientes
(ClienteId int IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(200) NULL,
Celular varchar(10) NULL,
Direccion varchar(200) NULL,
Email varchar(100) NULL)

CREATE TABLE dbo.tbl_Compra
(CompraId int IDENTITY(1,1) PRIMARY KEY,
ProductoId int NOT NULL,
ValorCompra money NOT NULL,
FechaRegistro datetime NOT NULL,
FechaActualizacion datetime NULL,
ClienteId int NOT NULL,
FOREIGN KEY (ClienteId) REFERENCES dbo.tbl_Clientes (ClienteId))