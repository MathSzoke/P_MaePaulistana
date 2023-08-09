USE GeoSaude

GO

ALTER TABLE Common.PacienteCBO SET (SYSTEM_VERSIONING = ON)
ALTER TABLE Common.ProfissionalCBO SET (SYSTEM_VERSIONING = ON)
ALTER TABLE MaePaulistana.EntrevistaPuerperalRNParametroDoencaCongenita SET (SYSTEM_VERSIONING = ON)
ALTER TABLE Common.ProfissionalEstabelecimento SET (SYSTEM_VERSIONING = ON)
ALTER TABLE Common.Referencia SET (SYSTEM_VERSIONING = ON)

DROP TABLE IF EXISTS Common.PacienteCBOHistory 
DROP TABLE IF EXISTS Common.ProfissionalCBOHistory
DROP TABLE IF EXISTS MaePaulistana.EntrevistaPuerperalRNParametroDoencaCongenitaHistory
DROP TABLE IF EXISTS Common.ProfissionalEstabelecimentoHistory 
DROP TABLE IF EXISTS Common.ReferenciaHistory 

EXEC sp_rename 'Common.MSSQL_TemporalHistoryFor_318624178', 'PacienteCBOHistory '
EXEC sp_rename 'Common.MSSQL_TemporalHistoryFor_450100644', 'ProfissionalCBOHistory'
EXEC sp_rename 'MaePaulistana.MSSQL_TemporalHistoryFor_39671189', 'EntrevistaPuerperalRNParametroDoencaCongenitaHistory'
EXEC sp_rename 'Common.MSSQL_TemporalHistoryFor_1330103779', 'ProfissionalEstabelecimentoHistory'
EXEC sp_rename 'Common.MSSQL_TemporalHistoryFor_1394104007', 'ReferenciaHistory'

