/*
   21 апреля 2015 г.11:58:37
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
EXECUTE sp_rename N'dbo.Users.email', N'Tmp_UserEmail', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Users.Tmp_UserEmail', N'UserEmail', 'COLUMN' 
GO
ALTER TABLE dbo.Users SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
