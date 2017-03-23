USE [MeetingScheduler]
GO

/****** Object:  Table [dbo].[Meeting]    Script Date: 22-03-2017 20:56:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](15) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY(UserId)
) 

GO
CREATE TABLE [dbo].[Meeting](
	[MeetingId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](15) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Time] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	CONSTRAINT PK_Meeting PRIMARY KEY(MeetingId),
	CONSTRAINT FK_Meeting_User FOREIGN KEY(CreatedBy) REFERENCES [User](UserId)
) 

GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[MeetingId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	CONSTRAINT PK_Registration PRIMARY KEY(RegistrationId),
	CONSTRAINT FK_Registration_Meeting FOREIGN KEY(MeetingId) REFERENCES Meeting(MeetingId),
	CONSTRAINT FK_Registration_User FOREIGN KEY(UserId) REFERENCES [User](UserId)
)
