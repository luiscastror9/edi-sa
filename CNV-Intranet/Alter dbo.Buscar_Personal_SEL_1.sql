USE [D:\CNV\CNV-INTRANET\CNV-OLD INTRANET\APP_DATA\CNV.MDF]
GO

/****** Objeto: SqlProcedure [dbo].[Buscar_Personal_SEL] Fecha del script: 6/10/2017 2:45:20 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Buscar_Personal_SEL]
@Buscar nvarchar(50) = ''
AS
BEGIN
SELECT Nombres, Apellido, Email, Sector, Telefono, CUIL, Edificio, Piso
FROM Personal
WHERE FechaBaja IS NULL AND 
(Nombres LIKE '%' + @Buscar + '%' OR Apellido LIKE '%' + @Buscar + '%' OR Sector LIKE '%' + @Buscar + '%')
END
