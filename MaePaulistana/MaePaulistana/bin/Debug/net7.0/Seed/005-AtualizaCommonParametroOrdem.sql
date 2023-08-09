USE GeoSaude

GO

UPDATE CP 
SET CP.ParametroOrdem = X.Linha
FROM Common.Parametro CP
JOIN 
(
	SELECT *, 
		ROW_NUMBER() OVER (PARTITION BY ParametroKey ORDER BY ParametroId) AS [Linha]
	FROM Common.Parametro
) X ON X.ParametroId = CP.ParametroId
