USE BD_Belleza
GO

CREATE PROCEDURE usp_GuardarCompra
@ProductoId INT,
@Valor MONEY,
@Nombre VARCHAR(200),
@Direccion VARCHAR(200),
@InventarioColoresId INT

AS
BEGIN
	DECLARE @ClienteId INT

	INSERT INTO [dbo].[tbl_Clientes] VALUES
	(@Nombre, NULL, @Direccion, NULL)

	SELECT @ClienteId = @@IDENTITY;

	INSERT INTO [dbo].[tbl_Compra] VALUES
	(@ProductoId, @Valor, GETDATE(), NULL, @ClienteId)

	UPDATE [dbo].[tbl_InventarioColores] 
	SET Cantidad = Cantidad - 1
	WHERE InventarioColoresId = @InventarioColoresId
END