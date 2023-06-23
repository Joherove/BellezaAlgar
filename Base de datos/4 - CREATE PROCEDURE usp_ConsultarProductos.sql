USE BD_Belleza
GO

CREATE PROCEDURE usp_ConsultarProductos
AS
BEGIN
	SELECT 
		P.ProductoId
		, P.Descripcion
		, P.Valor
		, I.InventarioColoresId
		, I.Descripcion AS Color
		, I.Cantidad
	FROM tbl_Productos P
	INNER JOIN tbl_InventarioColores I ON P.ProductoId = I.ProductoId
	WHERE P.Estado = 1
END