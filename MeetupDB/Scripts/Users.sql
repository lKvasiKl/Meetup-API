INSERT INTO [dbo].[Users] ([Email], [PasswordHash], [RoleId])
VALUES
	(N'admin@gmail.com', '$2a$11$ujJ7LLjvUPBzpePN.EKeqO1rUM1SQkJe3LKzfVAZrsGebIHLosjYK', 1),
	(N'user@example.com', '$2a$11$RDpxjVcTxlAlP6vB8XvER.CG3yOSgjhq1NYEt1Cgt8LHXOvcPaGii', 2)