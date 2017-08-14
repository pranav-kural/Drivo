USE [DrivoDb]
GO

/****** Object:  Table [dbo].[Instructors]    Script Date: 2017-08-12 3:12:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Instructors](
	[InstructorId] [nvarchar](128) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Gender] [nvarchar](1) NOT NULL CHECK (Gender IN('M', 'F', 'O')),
	[Driving_instructor_licence] [nvarchar](1) NOT NULL CHECK (Driving_instructor_licence IN('Y', 'N')),
	[Working_since] [date] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[About] [nvarchar](500) NOT NULL,
	[Licences_held] [nvarchar](250) NOT NULL,
	[Licences_training_for] [nvarchar](250) NOT NULL,
	[Province] [nvarchar](30) NOT NULL,
	[Cities_of_operation] [nvarchar](max) NOT NULL,
	[Vehicles_used] [nvarchar](500) NULL,
	CONSTRAINT [CHK_Province] CHECK (UPPER(RTRIM(Province)) IN('ONTARIO', 'QUEBEC', 'NOVA SCOTIA', 'NEW BRUNSWICK', 'MANITOBA', 'BRITISH COLUMBIA', 'PRINCE EDWARD ISLAND', 'SASKATCHEWAN', 'ALBERTA', 'NEWFOUNDLAND AND LABRADOR')),
	CONSTRAINT [CHK_DOB] CHECK ((DOB > CONVERT(DATE, '1937-12-12')) AND (DOB < CONVERT(DATE, '1998-12-12'))),
	CONSTRAINT [CHK_Work_Experience] CHECK ((Working_since > DATEADD(year, 18, DOB)) AND (Working_since < CONVERT(DATE, '2017-06-01'))),
	CONSTRAINT [PK_dbo.Instructors] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

