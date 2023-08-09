USE GeoSaude

GO

SET IDENTITY_INSERT Common.Parametro ON

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1079, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'TEXTO (RESPOSTA ÚNICA)', 1, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1080, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'DATA (RESPOSTA ÚNICA)', 2, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1081, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'E-MAIL (RESPOSTA ÚNICA)', 3, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1082, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'NÚMERO (RESPOSTA ÚNICA)', 4, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1083, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'TELEFONE (RESPOSTA ÚNICA)', 5, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1084, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'CHECKBOX (MÚLTIPLAS RESPOSTAS)', 6, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1085, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'RADIOBUTTON (RESPOSTA ÚNICA)', 7, NULL)

SET IDENTITY_INSERT Common.Parametro OFF
