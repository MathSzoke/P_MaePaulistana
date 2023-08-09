USE GeoSaude
GO

ALTER TABLE dbo.FileTableSolicitacaoAmputacao
SET 
(
	FILETABLE_DIRECTORY = 'FileTableSolicitacaoAmputacao'
)
GO

ALTER TABLE dbo.FileTableSolicitacaoTraumaRaquimedular
SET 
(
	FILETABLE_DIRECTORY = 'FileTableSolicitacaoTraumaRaquimedular'
)
GO
