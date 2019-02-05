USE CNV
GO

/****** Object:  StoredProcedure [dbo].[Buscar_Personal_SEL]    Script Date: 29/09/2017 01:51:37 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Buscar_Personal_SEL]
	@Buscar nvarchar(50) = ''
AS
BEGIN

	SELECT 
		Nombres, 
		Apellido, 
		Email, 
		CASE Sector 
			WHEN ' ' THEN Puesto
			ELSE puesto+' en '+sector 
			END AS sector,
		Puesto, 
		Telefono, 
		CUIL, 
		Edificio, 
		case piso
			WHEN 'PB' then piso
			ELSE 'Piso '+ Piso
		END AS piso
FROM Personal

	WHERE FechaBaja IS NULL AND 
		(Nombres LIKE '%' + @Buscar + '%') OR 
		(Apellido LIKE '%' + @Buscar + '%') OR 
		(Sector LIKE '%' + @Buscar + '%') OR 			
		( LTRIM(RTRIM(Apellido)) + ','   + LTRIM(RTRIM(Nombres)) LIKE '%' + @Buscar + '%' ) OR 
		( LTRIM(RTRIM(Apellido)) + ' , ' + LTRIM(RTRIM(Nombres)) LIKE '%' + @Buscar + '%' ) OR 
		( LTRIM(RTRIM(Apellido)) + ', '  + LTRIM(RTRIM(Nombres)) LIKE '%' + @Buscar + '%' ) OR 
		( LTRIM(RTRIM(Apellido)) + ' ,'  + LTRIM(RTRIM(Nombres)) LIKE '%' + @Buscar + '%' ) 


END

/*

USE RRHH

EXEC dbo.Buscar_Personal_SEL
      @Buscar = N'' -- nvarchar(50)

EXEC dbo.Buscar_Personal_SEL
      @Buscar = N'VERRONE , GERARDO SEBASTIAN' -- nvarchar(50)

*/


GO

