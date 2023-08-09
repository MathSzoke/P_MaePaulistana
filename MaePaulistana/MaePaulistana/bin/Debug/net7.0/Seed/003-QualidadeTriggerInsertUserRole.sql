USE GeoSaude

GO

CREATE OR ALTER TRIGGER Auth.QualidadeAuthUserRoleInsert
ON Auth.UserRole 
FOR INSERT
AS
	INSERT Qualidade.Usuario
	(
		UsuarioId,
		CriadoPor,
		CriadoEm,
		PessoaNome, 
		Ativo
	)
	SELECT U.Id,
		I.CriadoPor,
		I.CriadoEm,
		U.NormalizedUserName, 
		1
	FROM Inserted I 
	JOIN Auth.Role R ON R.Id = I.RoleId
	JOIN Auth.[User] U ON U.Id = I.UserId
	WHERE R.Name LIKE 'QUALIDADE%'
GO

