/*
   16 апреля 2015 г.17:17:12
   Пользователь: 
   Сервер: SAMS\SQLEXPRESS
   База данных: consultations_new
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Menu
	(
	MenuId int NOT NULL IDENTITY (11, 1),
	title nvarchar(512) NULL,
	url nvarchar(1024) NULL,
	roles nvarchar(50) NULL,
	parent_id int NULL,
	sort_order int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Menu SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Menu ON
GO
IF EXISTS(SELECT * FROM dbo.Menu)
	 EXEC('INSERT INTO dbo.Tmp_Menu (MenuId, title, url, roles, parent_id, sort_order)
		SELECT MenuId, title, url, roles, parent_id, sort_order FROM dbo.Menu WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Menu OFF
GO
ALTER TABLE dbo.Menu
	DROP CONSTRAINT FK_Menu_Menu
GO
DROP TABLE dbo.Menu
GO
EXECUTE sp_rename N'dbo.Tmp_Menu', N'Menu', 'OBJECT' 
GO
ALTER TABLE dbo.Menu ADD CONSTRAINT
	PK_Menu PRIMARY KEY CLUSTERED 
	(
	MenuId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Menu ADD CONSTRAINT
	FK_Menu_Menu FOREIGN KEY
	(
	parent_id
	) REFERENCES dbo.Menu
	(
	MenuId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
