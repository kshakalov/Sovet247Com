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
ALTER TABLE dbo.Consultations ADD
	urgency smallint NOT NULL CONSTRAINT DF_Consultations_urgency DEFAULT 0,
	detalization smallint NOT NULL CONSTRAINT DF_Consultations_detalization DEFAULT 0
GO
ALTER TABLE dbo.Consultations SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



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
ALTER TABLE dbo.Transactions ADD
	isApproved bit NOT NULL CONSTRAINT DF_Transactions_isApproved DEFAULT 0
GO
ALTER TABLE dbo.Transactions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
