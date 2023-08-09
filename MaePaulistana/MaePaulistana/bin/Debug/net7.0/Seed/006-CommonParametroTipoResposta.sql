USE GeoSaude

GO

SET IDENTITY_INSERT Common.Parametro ON

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1079, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'TEXTO (RESPOSTA �NICA)', 1, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1080, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'DATA (RESPOSTA �NICA)', 2, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1081, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'E-MAIL (RESPOSTA �NICA)', 3, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1082, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'N�MERO (RESPOSTA �NICA)', 4, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1083, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'TELEFONE (RESPOSTA �NICA)', 5, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1084, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'CHECKBOX (M�LTIPLAS RESPOSTAS)', 6, NULL)

INSERT INTO Common.Parametro(ParametroId, CriadoPor, CriadoEm, AlteradoPor, AlteradoEm, ExcluidoPor, ExcluidoEm, ParametroKey, ParametroValue, ParametroOrdem, ParametroValueSIGAWS)
VALUES(1085, 'SYSTEM', '2020-01-01 00:00:00.000', NULL, NULL, NULL, NULL, 'ParametroTipoResposta', 'RADIOBUTTON (RESPOSTA �NICA)', 7, NULL)

SET IDENTITY_INSERT Common.Parametro OFF
