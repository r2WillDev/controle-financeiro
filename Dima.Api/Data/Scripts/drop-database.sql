--caso precisar excluir o banco

USE [master];
GO

ALTER DATABASE [dima] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE [dima];
go