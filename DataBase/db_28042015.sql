/****** Object:  UserDefinedFunction [dbo].[GetConsultantRating]    Script Date: 28.04.2015 17:28:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetConsultantRating] 
(
	@consultantId int
)
RETURNS numeric
AS
BEGIN
	-- Declare the return variable here
	DECLARE @res numeric(18,2)

	-- Add the T-SQL statements to compute the return value here
	SELECT @res=AVG(customer_rating) from consultations where ConsultantId=@consultantId
	-- Return the result of the function
	RETURN @res

END






GO
/****** Object:  Table [dbo].[AdminMessages]    Script Date: 28.04.2015 17:28:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMessages](
	[adminMessageId] [int] IDENTITY(1,1) NOT NULL,
	[parentMessageId] [int] NOT NULL,
	[fromUserId] [int] NOT NULL,
	[toUserId] [int] NOT NULL,
	[subject] [nvarchar](500) NULL,
	[message] [nvarchar](max) NULL,
	[dateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminMessages] PRIMARY KEY CLUSTERED 
(
	[adminMessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consultants]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultants](
	[ConsultantId] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionId] [int] NOT NULL,
	[SpecialtyId] [int] NULL,
	[specialization] [nvarchar](512) NULL,
	[UserId] [int] NOT NULL,
	[education] [nvarchar](1024) NULL,
	[workplace] [nvarchar](2048) NULL,
	[active] [bit] NOT NULL CONSTRAINT [DF_Consultants_active]  DEFAULT ((0)),
	[short_resume] [nvarchar](2000) NULL,
	[comission_percent] [numeric](18, 2) NULL,
	[photo_url] [nvarchar](512) NULL,
 CONSTRAINT [PK_ConsultantsSet] PRIMARY KEY CLUSTERED 
(
	[ConsultantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consultation_Statuses]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation_Statuses](
	[ConsultationStatusId] [int] IDENTITY(1,1) NOT NULL,
	[status_title] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_consultation_statuses] PRIMARY KEY CLUSTERED 
(
	[ConsultationStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consultation_Time]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation_Time](
	[consultationTimeId] [int] IDENTITY(1,1) NOT NULL,
	[ConsultationId] [int] NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[skypeContact] [nvarchar](512) NULL,
	[phoneContact] [nvarchar](512) NULL,
 CONSTRAINT [PK_Consultation_Time] PRIMARY KEY CLUSTERED 
(
	[consultationTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consultation_Types]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation_Types](
	[ConsultationTypeId] [int] IDENTITY(1,1) NOT NULL,
	[consultation_type] [nvarchar](512) NOT NULL,
	[active] [tinyint] NOT NULL CONSTRAINT [DF_consultation_types_active]  DEFAULT ((1)),
 CONSTRAINT [PK_consultation_types] PRIMARY KEY CLUSTERED 
(
	[ConsultationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consultations]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultations](
	[ConsultationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ConsultantId] [int] NULL,
	[subject] [nvarchar](max) NULL,
	[consultation_type] [int] NOT NULL,
	[ProfessionId] [int] NOT NULL,
	[SpecialtyId] [int] NULL,
	[consultation_status] [int] NOT NULL CONSTRAINT [DF_consultations_consultation_status]  DEFAULT ((0)),
	[create_date] [datetime] NOT NULL CONSTRAINT [DF_consultations_create_date]  DEFAULT (getdate()),
	[update_date] [datetime] NOT NULL CONSTRAINT [DF_consultations_update_date]  DEFAULT (getdate()),
	[customer_rating] [decimal](18, 1) NULL,
	[customer_comments] [nvarchar](4000) NULL,
	[consultation_price] [numeric](18, 2) NOT NULL CONSTRAINT [DF_consultations_consultation_price]  DEFAULT ((0)),
 CONSTRAINT [PK_consultations] PRIMARY KEY CLUSTERED 
(
	[ConsultationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[country_code] [nvarchar](50) NULL,
	[country_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuId] [int] IDENTITY(11,1) NOT NULL,
	[title] [nvarchar](512) NULL,
	[url] [nvarchar](1024) NULL,
	[roles] [nvarchar](50) NULL,
	[parent_id] [int] NULL,
	[sort_order] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[ConsultationId] [int] NULL,
	[message] [nvarchar](max) NULL,
	[added_date] [smalldatetime] NULL,
	[attachment] [nvarchar](1024) NULL,
	[UserId] [int] NULL,
	[published] [tinyint] NOT NULL CONSTRAINT [DF_messages_published]  DEFAULT ((0)),
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professions]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professions](
	[ProfessionId] [int] IDENTITY(1,1) NOT NULL,
	[Profession_Title] [nvarchar](512) NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_Professions_Active]  DEFAULT ((1)),
 CONSTRAINT [PK_Professions] PRIMARY KEY CLUSTERED 
(
	[ProfessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[role_title] [nvarchar](512) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[SpecialtyId] [int] IDENTITY(1,1) NOT NULL,
	[Specialty_title] [nvarchar](512) NULL,
	[ProfessionId] [int] NOT NULL,
	[active] [bit] NOT NULL CONSTRAINT [DF_Specialties_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED 
(
	[SpecialtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[amount] [numeric](18, 2) NOT NULL,
	[transactionDate] [datetime] NOT NULL CONSTRAINT [DF_transactions_transactionDate]  DEFAULT (getdate()),
	[description] [nvarchar](4000) NULL,
	[ConsultationId] [int] NULL,
 CONSTRAINT [PK_transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.04.2015 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[nickname] [nvarchar](50) NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](256) NOT NULL,
	[firstname] [nvarchar](128) NOT NULL,
	[lastname] [nvarchar](128) NOT NULL,
	[middlename] [nvarchar](128) NULL,
	[street_address] [nvarchar](1024) NULL,
	[city] [nvarchar](512) NULL,
	[CountryId] [int] NULL,
	[zip] [nvarchar](50) NULL,
	[state] [nvarchar](256) NULL,
	[phone] [nvarchar](50) NULL,
	[wants_newsletter] [smallint] NOT NULL CONSTRAINT [DF_Users_wants_newsletter]  DEFAULT ((0)),
	[alternate_contacts] [nvarchar](1024) NULL,
	[comments] [nvarchar](1024) NULL,
	[can_publish_questions] [smallint] NOT NULL CONSTRAINT [DF_Users_can_publish_questions]  DEFAULT ((0)),
	[RoleId] [int] NOT NULL CONSTRAINT [DF_Users_role_id]  DEFAULT ((3)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Consultants] ON 

INSERT [dbo].[Consultants] ([ConsultantId], [ProfessionId], [SpecialtyId], [specialization], [UserId], [education], [workplace], [active], [short_resume], [comission_percent], [photo_url]) VALUES (2, 1, 3, N'sadfsdg', 20, N'', N'', 1, N'rgtr', NULL, N'/uploads/Penguins.jpg')
INSERT [dbo].[Consultants] ([ConsultantId], [ProfessionId], [SpecialtyId], [specialization], [UserId], [education], [workplace], [active], [short_resume], [comission_percent], [photo_url]) VALUES (3, 1, 1, N'невропотолог', 23, N'аваыв', N'ываыва', 1, N'цкцуКраткое резюме для клиентов: ', NULL, N'')
SET IDENTITY_INSERT [dbo].[Consultants] OFF
SET IDENTITY_INSERT [dbo].[Consultation_Statuses] ON 

INSERT [dbo].[Consultation_Statuses] ([ConsultationStatusId], [status_title]) VALUES (1, N'Новый')
INSERT [dbo].[Consultation_Statuses] ([ConsultationStatusId], [status_title]) VALUES (2, N'Принят консультантом')
INSERT [dbo].[Consultation_Statuses] ([ConsultationStatusId], [status_title]) VALUES (3, N'Завершен')
INSERT [dbo].[Consultation_Statuses] ([ConsultationStatusId], [status_title]) VALUES (4, N'Оплачен')
SET IDENTITY_INSERT [dbo].[Consultation_Statuses] OFF
SET IDENTITY_INSERT [dbo].[Consultation_Time] ON 

INSERT [dbo].[Consultation_Time] ([consultationTimeId], [ConsultationId], [startTime], [endTime], [skypeContact], [phoneContact]) VALUES (3, 22, CAST(N'2015-02-15 20:57:00.000' AS DateTime), CAST(N'2015-02-15 21:57:00.000' AS DateTime), N'123', N'123')
INSERT [dbo].[Consultation_Time] ([consultationTimeId], [ConsultationId], [startTime], [endTime], [skypeContact], [phoneContact]) VALUES (4, 22, CAST(N'2015-02-17 20:57:00.000' AS DateTime), CAST(N'2015-02-17 21:57:00.000' AS DateTime), N'123', N'123')
INSERT [dbo].[Consultation_Time] ([consultationTimeId], [ConsultationId], [startTime], [endTime], [skypeContact], [phoneContact]) VALUES (1002, 1022, CAST(N'2015-02-24 20:57:00.000' AS DateTime), CAST(N'2015-02-24 21:57:00.000' AS DateTime), N'123', N'123')
INSERT [dbo].[Consultation_Time] ([consultationTimeId], [ConsultationId], [startTime], [endTime], [skypeContact], [phoneContact]) VALUES (2002, 2024, CAST(N'2015-03-15 14:50:00.000' AS DateTime), CAST(N'2015-03-15 18:50:00.000' AS DateTime), N'ASDS', N'ASDF')
INSERT [dbo].[Consultation_Time] ([consultationTimeId], [ConsultationId], [startTime], [endTime], [skypeContact], [phoneContact]) VALUES (2003, 2026, CAST(N'2015-03-27 20:28:00.000' AS DateTime), CAST(N'2015-03-27 20:28:00.000' AS DateTime), N'123', N'123')
SET IDENTITY_INSERT [dbo].[Consultation_Time] OFF
SET IDENTITY_INSERT [dbo].[Consultation_Types] ON 

INSERT [dbo].[Consultation_Types] ([ConsultationTypeId], [consultation_type], [active]) VALUES (1, N'Стандартная консультация', 1)
INSERT [dbo].[Consultation_Types] ([ConsultationTypeId], [consultation_type], [active]) VALUES (2, N'Телефонная консультация', 1)
INSERT [dbo].[Consultation_Types] ([ConsultationTypeId], [consultation_type], [active]) VALUES (3, N'Персональная консультация', 0)
SET IDENTITY_INSERT [dbo].[Consultation_Types] OFF
SET IDENTITY_INSERT [dbo].[Consultations] ON 

INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (6, 13, 2, N'Вопрос терапевту', 1, 1, 1, 3, CAST(N'2014-05-22 01:08:35.257' AS DateTime), CAST(N'2014-09-04 14:39:40.587' AS DateTime), CAST(7.0 AS Decimal(18, 1)), N'Мой первый комментарий', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (7, 13, NULL, N'Вопрос адвокату', 1, 2, 2, 4, CAST(N'2014-05-22 01:11:05.620' AS DateTime), CAST(N'2014-05-22 01:11:05.620' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (8, 13, NULL, N'ждэжwrtre[gpof[sd', 1, 2, 2, 4, CAST(N'2014-06-17 23:33:18.613' AS DateTime), CAST(N'2014-06-17 23:33:18.613' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (9, 13, 2, N'хочу заказать телефонную консультацию', 2, 1, 1, 2, CAST(N'2014-06-17 23:39:12.337' AS DateTime), CAST(N'2014-10-08 23:50:48.293' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (10, 13, NULL, N'как сделать проверкукак сделать проверкуаыва', 1, 3, 4, 4, CAST(N'2014-09-07 10:55:41.667' AS DateTime), CAST(N'2014-09-07 10:55:41.667' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (11, 13, 2, N'', 1, 1, 1, 2, CAST(N'2014-09-07 10:59:32.530' AS DateTime), CAST(N'2014-10-08 23:50:46.593' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (12, 13, 2, N'проверка от 8 сентября 2014', 1, 1, 1, 3, CAST(N'2014-09-08 23:32:08.960' AS DateTime), CAST(N'2014-09-09 21:28:11.780' AS DateTime), CAST(6.0 AS Decimal(18, 1)), N'проверка предаврительная произведена. коментарий оставлен', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (13, 13, 2, N'проверка консультаци по телефону 10-09-2014', 2, 1, 1, 2, CAST(N'2014-09-10 22:11:48.813' AS DateTime), CAST(N'2014-10-08 23:50:31.203' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (14, 13, 2, N'проверка 8 октября', 1, 1, 1, 2, CAST(N'2014-10-08 23:47:52.593' AS DateTime), CAST(N'2014-10-08 23:52:40.843' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (15, 13, NULL, N'fdfsd', 1, 1, 1, 4, CAST(N'2014-10-15 23:43:27.420' AS DateTime), CAST(N'2014-10-15 23:43:27.420' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (16, 13, 2, N'sd', 1, 1, 1, 2, CAST(N'2014-10-17 19:17:34.910' AS DateTime), CAST(N'2015-02-15 20:15:36.320' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (17, 13, 2, N'sd', 1, 1, 1, 2, CAST(N'2014-10-17 19:17:44.360' AS DateTime), CAST(N'2015-02-15 20:15:29.913' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (18, 13, 2, N'sdfsd', 1, 1, 1, 2, CAST(N'2014-10-20 23:34:39.517' AS DateTime), CAST(N'2015-02-15 20:15:33.910' AS DateTime), NULL, NULL, CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (19, 13, 2, N'проверка 2 
от 20 Октября 2014', 1, 1, 1, 3, CAST(N'2014-10-20 23:36:30.553' AS DateTime), CAST(N'2014-10-20 23:41:54.873' AS DateTime), CAST(6.5 AS Decimal(18, 1)), N'', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (22, 13, 2, N'lf;kjgdst''g
rlgjdkgjsf;gjds;gkjs
a', 2, 1, 1, 3, CAST(N'2015-02-15 20:57:52.277' AS DateTime), CAST(N'2015-02-15 21:07:18.010' AS DateTime), CAST(10.0 AS Decimal(18, 1)), N'Super!', CAST(20.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (1021, 13, 2, N'проверка телефонной консультации', 2, 1, 3, 4, CAST(N'2015-02-24 20:30:03.707' AS DateTime), CAST(N'2015-02-24 20:30:03.707' AS DateTime), NULL, NULL, CAST(40.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (1022, 13, 2, N'Проверка 2 телефонной консультации', 2, 1, 3, 4, CAST(N'2015-02-24 20:58:02.830' AS DateTime), CAST(N'2015-02-24 20:58:02.830' AS DateTime), NULL, NULL, CAST(40.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (2021, 13, 2, N'asdfgyuij', 1, 1, 3, 4, CAST(N'2015-03-09 17:02:08.440' AS DateTime), CAST(N'2015-03-09 17:02:08.440' AS DateTime), NULL, NULL, CAST(20.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (2022, 13, 2, N'asadfsgdh', 1, 1, 3, 4, CAST(N'2015-03-15 14:35:38.530' AS DateTime), CAST(N'2015-03-15 14:35:38.530' AS DateTime), NULL, NULL, CAST(20.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (2023, 13, 2, N'WFEGRHYU', 3, 1, 3, 4, CAST(N'2015-03-15 14:39:41.810' AS DateTime), CAST(N'2015-03-15 14:39:41.810' AS DateTime), NULL, NULL, CAST(20.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (2024, 13, 2, N'SDFGH', 2, 1, 3, 4, CAST(N'2015-03-15 14:50:46.573' AS DateTime), CAST(N'2015-03-15 14:50:46.573' AS DateTime), NULL, NULL, CAST(20.00 AS Numeric(18, 2)))
INSERT [dbo].[Consultations] ([ConsultationId], [UserId], [ConsultantId], [subject], [consultation_type], [ProfessionId], [SpecialtyId], [consultation_status], [create_date], [update_date], [customer_rating], [customer_comments], [consultation_price]) VALUES (2026, 13, NULL, N'dsfgdhfgjhkl', 2, 2, 2, 4, CAST(N'2015-03-27 20:33:58.020' AS DateTime), CAST(N'2015-03-27 20:33:58.020' AS DateTime), NULL, NULL, CAST(20.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Consultations] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (1, N'', N'Австралия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (2, N'', N'Австрия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (3, N'', N'Азербайджан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (4, N'', N'Албания')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (5, N'', N'Алжир')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (6, N'', N'Ангола')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (7, N'AND', N'Андорра')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (8, N'', N'Аргентина')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (9, N'', N'Армения')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (10, N'', N'Афганистан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (11, N'', N'Белоруссия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (12, N'', N'Бельгия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (13, N'', N'Болгария')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (14, N'', N'Боливия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (15, N'', N'Босния и Герцеговина')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (16, N'', N'Бразилия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (17, N'', N'Великобритания')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (18, N'', N'Венгрия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (19, N'', N'Венесуэла')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (20, N'', N'Восточный Тимор')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (21, N'', N'Вьетнам')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (22, N'', N'Гаити')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (23, N'', N'Германия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (24, N'', N'Гондурас')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (25, N'', N'Греция')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (26, N'', N'Грузия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (27, N'', N'Дания')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (28, N'', N'Египет')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (29, N'', N'Израиль')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (30, N'', N'Индия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (31, N'', N'Индонезия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (32, N'', N'Иордания')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (33, N'', N'Ирак')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (34, N'', N'Иран')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (35, N'', N'Ирландия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (36, N'', N'Исландия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (37, N'', N'Испания')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (38, N'', N'Италия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (39, N'', N'Казахстан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (40, N'', N'Канада')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (41, N'', N'Катар')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (42, N'', N'Кипр')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (43, N'', N'Киргизия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (44, N'', N'Китай')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (45, N'', N'КНДР')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (46, N'', N'Колумбия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (47, N'', N'Коста-Рика')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (48, N'', N'Кот-дИвуар')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (49, N'', N'Куба')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (50, N'', N'Латвия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (51, N'', N'Литва')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (52, N'', N'Лихтенштейн')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (53, N'', N'Люксембург')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (54, N'', N'Македония')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (55, N'', N'Малайзия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (56, N'', N'Мальдивские Острова')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (57, N'', N'Мальта')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (58, N'', N'Мексика')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (59, N'', N'Молдавия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (60, N'', N'Монако')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (61, N'', N'Монголия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (62, N'', N'Нидерланды')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (63, N'', N'Новая Зеландия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (64, N'', N'Норвегия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (65, N'', N'ОАЭ')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (66, N'', N'Пакистан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (67, N'', N'Панама')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (68, N'', N'Парагвай')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (69, N'', N'Перу')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (70, N'', N'Польша')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (71, N'', N'Португалия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (72, N'', N'Республика Корея')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (73, N'', N'Россия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (74, N'', N'Румыния')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (75, N'', N'Саудовская Аравия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (76, N'', N'Сейшельские Острова')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (77, N'', N'Сербия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (78, N'', N'Сингапур')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (79, N'', N'Словакия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (80, N'', N'Словения')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (81, N'', N'США')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (82, N'', N'Таджикистан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (83, N'', N'Таиланд')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (84, N'', N'Туркмения')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (85, N'', N'Турция')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (86, N'', N'Узбекистан')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (87, N'', N'Украина')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (88, N'', N'Уругвай')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (89, N'', N'Фиджи')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (90, N'', N'Филиппины')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (91, N'', N'Финляндия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (92, N'', N'Франция')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (93, N'', N'Хорватия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (94, N'', N'Черногория')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (95, N'', N'Чехия')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (96, N'', N'Чили')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (97, N'', N'Швейцария')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (98, N'', N'Швеция')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (99, N'', N'Эквадор')
GO
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (100, N'', N'Эстония')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (101, N'', N'ЮАР')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (102, N'', N'Ямайка')
INSERT [dbo].[Countries] ([CountryId], [country_code], [country_name]) VALUES (103, N'', N'Япония')
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (1, N'Личные данные ', N'/Account/PersonalInformation.aspx', N'2,3', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (2, N'История счета', N'/Account/Transactions.aspx', N'2,3', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (3, N'Мои консультации', N'/Account/Consultations.aspx', N'3', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (4, N'Пополнить баланс', N'/Account/MakePayment.aspx', N'3', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (5, N'Сменить пароль', N'/Account/ChangePassword.aspx', N'2,3', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (6, N'Свободные консультации', N'/Consultant/FreeConsultations.aspx', N'2', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (7, N'Мои консультации', N'/Consultant/MyConsultations.aspx', N'2', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (8, N'Справочники', N'Dictionaries', N'1', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (9, N'Профессии', N'Professions', N'1', 8, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (10, N'Специальности', N'Specialties', N'1', 8, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (11, N'Консультации', N'Consultations', N'1', NULL, NULL)
INSERT [dbo].[Menu] ([MenuId], [title], [url], [roles], [parent_id], [sort_order]) VALUES (12, N'Страны', N'Countries', N'1', 8, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (1, 6, N'????? ?????????', CAST(N'2014-08-28 14:38:00' AS SmallDateTime), N'', 20, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (2, 6, N'?????????', CAST(N'2014-08-28 14:39:00' AS SmallDateTime), N'', 20, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (6, 12, N'это перевый ответ на запрос от  8-09-2014', CAST(N'2014-09-08 23:51:00' AS SmallDateTime), N'', 20, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (7, 12, N'ответ на  на письмо от эксперат с поясниениями', CAST(N'2014-09-09 21:18:00' AS SmallDateTime), N'', 13, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (8, 12, N'', CAST(N'2014-09-09 21:18:00' AS SmallDateTime), N'', 13, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (9, 12, N'дополнения клиента на ответ от эксперта', CAST(N'2014-09-09 21:19:00' AS SmallDateTime), N'', 13, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (10, 12, N'ответ со стороны клиента на сообщение эксперата', CAST(N'2014-09-09 21:27:00' AS SmallDateTime), N'', 20, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (12, 14, N'ответ  на скосультацию', CAST(N'2014-10-08 23:52:00' AS SmallDateTime), N'', 20, 0)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (13, 19, N'ответит для клиента на консультацию', CAST(N'2014-10-20 23:38:00' AS SmallDateTime), N'|||/uploads/   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.Directory.InternalCreateDirectory(String fullPath, String path, Object dirSecurityObj, Boolean checkHost)
   at System.IO.Directory.InternalCreateDirectoryHelper(String path, Boolean checkHost)
   at System.IO.Directory.CreateDirectory(String path)
   at service.FileUpload.ProcessRequest(HttpContext context) in d:\inetpub\vhosts\bioline247.com\sovet247.com\ajax\Handler.ashx:line 31Access to the path ''D:\InetPub\vhosts\bioline247.com\sovet247.com\uploads\2014/10/20/'' is denied.', 20, 1)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (14, 19, N'', CAST(N'2014-10-20 23:39:00' AS SmallDateTime), N'', 20, 1)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (15, 19, N'продлолжение переписки на консультацию "проверка 2 от 20 Октября 2014"', CAST(N'2014-10-20 23:40:00' AS SmallDateTime), N'', 13, 1)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (16, 19, N'', CAST(N'2014-10-20 23:40:00' AS SmallDateTime), N'', 13, 1)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (17, 19, N'это отвтет конусультанта на второй вопрос клиента', CAST(N'2014-10-20 23:41:00' AS SmallDateTime), N'', 20, 1)
INSERT [dbo].[Messages] ([MessageId], [ConsultationId], [message], [added_date], [attachment], [UserId], [published]) VALUES (18, 22, N'eafafa', CAST(N'2015-02-15 21:01:00' AS SmallDateTime), N'', 13, 1)
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[Professions] ON 

INSERT [dbo].[Professions] ([ProfessionId], [Profession_Title], [Active]) VALUES (1, N'Доктор', 1)
INSERT [dbo].[Professions] ([ProfessionId], [Profession_Title], [Active]) VALUES (2, N'Юрист', 1)
INSERT [dbo].[Professions] ([ProfessionId], [Profession_Title], [Active]) VALUES (3, N'Механик', 1)
SET IDENTITY_INSERT [dbo].[Professions] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [role_title]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([RoleId], [role_title]) VALUES (2, N'Консультант')
INSERT [dbo].[Roles] ([RoleId], [role_title]) VALUES (3, N'Клиент')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Specialties] ON 

INSERT [dbo].[Specialties] ([SpecialtyId], [Specialty_title], [ProfessionId], [active]) VALUES (1, N'Терапевт', 1, 1)
INSERT [dbo].[Specialties] ([SpecialtyId], [Specialty_title], [ProfessionId], [active]) VALUES (2, N'Адвокат', 2, 1)
INSERT [dbo].[Specialties] ([SpecialtyId], [Specialty_title], [ProfessionId], [active]) VALUES (3, N'Косметолог', 1, 1)
INSERT [dbo].[Specialties] ([SpecialtyId], [Specialty_title], [ProfessionId], [active]) VALUES (4, N'Механик', 3, 1)
INSERT [dbo].[Specialties] ([SpecialtyId], [Specialty_title], [ProfessionId], [active]) VALUES (5, N'Автоэлектрик', 3, 1)
SET IDENTITY_INSERT [dbo].[Specialties] OFF
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (1, 13, CAST(50.00 AS Numeric(18, 2)), CAST(N'2014-04-18 20:21:13.397' AS DateTime), N'444', NULL)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2, 13, CAST(-5.00 AS Numeric(18, 2)), CAST(N'2014-04-18 20:21:13.397' AS DateTime), N'555', NULL)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (8, 13, CAST(-10.00 AS Numeric(18, 2)), CAST(N'2014-05-22 01:11:05.620' AS DateTime), N'Оплата консультации №7', 7)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (10, 13, CAST(-10.00 AS Numeric(18, 2)), CAST(N'2014-06-17 23:33:18.653' AS DateTime), N'Оплата консультации №8', 8)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (11, 13, CAST(-10.00 AS Numeric(18, 2)), CAST(N'2014-06-17 23:39:12.337' AS DateTime), N'Оплата консультации №9', 9)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (12, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-09-07 10:55:41.690' AS DateTime), N'Оплата консультации №10', 10)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (13, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-09-07 10:59:32.530' AS DateTime), N'Оплата консультации №11', 11)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (14, 13, CAST(5000.00 AS Numeric(18, 2)), CAST(N'2014-09-07 12:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (15, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-09-08 23:32:09.000' AS DateTime), N'Оплата консультации №12', 12)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (16, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-09-10 22:11:48.920' AS DateTime), N'Оплата консультации №13', 13)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (17, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-08 23:47:52.623' AS DateTime), N'Оплата консультации №14', 14)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (18, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-15 23:43:27.423' AS DateTime), N'Оплата консультации №15', 15)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (19, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-17 19:17:34.933' AS DateTime), N'Оплата консультации №16', 16)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (20, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-17 19:17:44.360' AS DateTime), N'Оплата консультации №17', 17)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (21, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-20 23:34:39.530' AS DateTime), N'Оплата консультации №18', 18)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (22, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2014-10-20 23:36:30.553' AS DateTime), N'Оплата консультации №19', 19)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (23, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-02-15 20:57:52.280' AS DateTime), N'Оплата консультации №22', 22)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (24, 20, CAST(15.00 AS Numeric(18, 2)), CAST(N'2015-02-15 21:07:18.020' AS DateTime), N'Оплата за консультацию №22', 22)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (1023, 13, CAST(-40.00 AS Numeric(18, 2)), CAST(N'2015-02-24 20:30:03.713' AS DateTime), N'Оплата консультации №1021', 1021)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (1024, 13, CAST(-40.00 AS Numeric(18, 2)), CAST(N'2015-02-24 20:58:02.860' AS DateTime), N'Оплата консультации №1022', 1022)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2023, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-03-09 17:02:08.457' AS DateTime), N'Оплата консультации №2021', 2021)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2024, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-03-15 14:35:38.533' AS DateTime), N'Оплата консультации №2022', 2022)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2025, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-03-15 14:39:41.813' AS DateTime), N'Оплата консультации №2023', 2023)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2026, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-03-15 14:50:46.600' AS DateTime), N'Оплата консультации №2024', 2024)
INSERT [dbo].[Transactions] ([TransactionId], [UserId], [amount], [transactionDate], [description], [ConsultationId]) VALUES (2027, 13, CAST(-20.00 AS Numeric(18, 2)), CAST(N'2015-03-27 20:34:21.313' AS DateTime), N'Оплата консультации №2026', 2026)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (13, N'', N'202cb962ac59075b964b07152d234b70', N'kshakalov@gmail.com', N'Konstantin', N'Shakalov', N'', N'', N'', 1, N'', N'', N'', 0, N'', N'', 0, 3)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (20, N'', N'202cb962ac59075b964b07152d234b70', N'jarosoft@mail.ru', N'afgrehtw', N'erthyt', N'tdhfrhw', N'asdfsd', N'sadfs', 17, N'', N'', N'', 0, N'', N'', 0, 2)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (21, NULL, N'202cb962ac59075b964b07152d234b70', N'shakalov.k@gmail.com', N'Admin', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (22, N'sergkgplus', N'827ccb0eea8a706c4c34a16891f84e7b', N'sergkgplus@yandex.ru', N'Name', N'LastName', N'', N'test street', N'test', 1, N'324', N'sdf', N'4646 46464', 1, N'проверка 04-09-2014
дполнниетельных контаквтов', N'проверка 04-09-2014
коментарии', 0, 3)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (23, N'', N'827ccb0eea8a706c4c34a16891f84e7b', N'sergkg@gmail.com', N'sergey', N'test', N'', N'улица ', N'грод  н', 1, N'23423423', N'уц', N'23423423', 1, N'ыаыва', N'ываыва', 0, 2)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (24, N'fred', N'570a90bfbf8c7eab5dc5d4e26832d5b1', N'fred@fred.com', N'asdfds', N'asdf', N'', N'reew', N'wer', 1, N'wer', N'wer', N'42332432', 0, N'adfasd', N'asfd', 0, 3)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (25, N'master', N'202cb962ac59075b964b07152d234b70', N'serkgplus@yandex.ru', N'сергей', N'к', N'', N'улиу для 12', N'Горол счастья', 1, N'23423423', N'индекс dfg11', N'1231231234123', 1, N'кАльтернативные контакты: нет', N'Комментарии ывпаыва', 0, 3)
INSERT [dbo].[Users] ([UserId], [nickname], [password], [email], [firstname], [lastname], [middlename], [street_address], [city], [CountryId], [zip], [state], [phone], [wants_newsletter], [alternate_contacts], [comments], [can_publish_questions], [RoleId]) VALUES (28, N'', N'202cb962ac59075b964b07152d234b70', N'123@123.com', N'Ogeruc', N'Pomidor', N'', N'', N'', 1, N'', N'', N'', 0, N'', N'', 0, 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[AdminMessages] ADD  CONSTRAINT [DF_AdminMessages_parentMessageId]  DEFAULT ((0)) FOR [parentMessageId]
GO
ALTER TABLE [dbo].[AdminMessages] ADD  CONSTRAINT [DF_AdminMessages_toUserId]  DEFAULT ((0)) FOR [toUserId]
GO
ALTER TABLE [dbo].[AdminMessages] ADD  CONSTRAINT [DF_AdminMessages_dateCreated]  DEFAULT (getdate()) FOR [dateCreated]
GO
ALTER TABLE [dbo].[AdminMessages]  WITH CHECK ADD  CONSTRAINT [FK_AdminMessages_AdminMessages] FOREIGN KEY([parentMessageId])
REFERENCES [dbo].[AdminMessages] ([adminMessageId])
GO
ALTER TABLE [dbo].[AdminMessages] CHECK CONSTRAINT [FK_AdminMessages_AdminMessages]
GO
ALTER TABLE [dbo].[Consultants]  WITH CHECK ADD  CONSTRAINT [FK_Consultants_Professions] FOREIGN KEY([ProfessionId])
REFERENCES [dbo].[Professions] ([ProfessionId])
GO
ALTER TABLE [dbo].[Consultants] CHECK CONSTRAINT [FK_Consultants_Professions]
GO
ALTER TABLE [dbo].[Consultants]  WITH CHECK ADD  CONSTRAINT [FK_Consultants_Specialties] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([SpecialtyId])
GO
ALTER TABLE [dbo].[Consultants] CHECK CONSTRAINT [FK_Consultants_Specialties]
GO
ALTER TABLE [dbo].[Consultants]  WITH CHECK ADD  CONSTRAINT [FK_Consultants_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Consultants] CHECK CONSTRAINT [FK_Consultants_Users]
GO
ALTER TABLE [dbo].[Consultation_Time]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Time_Consultations] FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[Consultations] ([ConsultationId])
GO
ALTER TABLE [dbo].[Consultation_Time] CHECK CONSTRAINT [FK_Consultation_Time_Consultations]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Consultants] FOREIGN KEY([ConsultantId])
REFERENCES [dbo].[Consultants] ([ConsultantId])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Consultants]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Consultation_Statuses] FOREIGN KEY([consultation_status])
REFERENCES [dbo].[Consultation_Statuses] ([ConsultationStatusId])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Consultation_Statuses]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Consultation_Types] FOREIGN KEY([consultation_type])
REFERENCES [dbo].[Consultation_Types] ([ConsultationTypeId])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Consultation_Types]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Professions] FOREIGN KEY([ProfessionId])
REFERENCES [dbo].[Professions] ([ProfessionId])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Professions]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Specialties] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([SpecialtyId])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Specialties]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Menu] ([MenuId])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Consultations] FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[Consultations] ([ConsultationId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Consultations]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[Specialties]  WITH CHECK ADD  CONSTRAINT [FK_Specialties_Professions] FOREIGN KEY([ProfessionId])
REFERENCES [dbo].[Professions] ([ProfessionId])
GO
ALTER TABLE [dbo].[Specialties] CHECK CONSTRAINT [FK_Specialties_Professions]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Consultations] FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[Consultations] ([ConsultationId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Consultations]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Countries]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
