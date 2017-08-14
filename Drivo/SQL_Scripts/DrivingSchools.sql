USE [DrivoDb]
GO

/****** Object:  Table [dbo].[DrivingSchools]    Script Date: 2017-08-12 5:40:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DrivingSchools](
	[DrivingSchoolId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Working_since] [date] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[About] [nvarchar](max) NOT NULL,
	[Licences_training_for] [nvarchar](max) NOT NULL,
	[Province] [nvarchar](30) NOT NULL,
	[Cities_of_operation] [nvarchar](max) NOT NULL,
	[Vehicles_used] [nvarchar](1000) NULL,
	CONSTRAINT [CHK_Province_for_Driving_Schools] CHECK (UPPER(RTRIM(Province)) IN('ONTARIO', 'QUEBEC', 'NOVA SCOTIA', 'NEW BRUNSWICK', 'MANITOBA', 'BRITISH COLUMBIA', 'PRINCE EDWARD ISLAND', 'SASKATCHEWAN', 'ALBERTA', 'NEWFOUNDLAND AND LABRADOR')),
	CONSTRAINT [PK_dbo.DrivingSchools] PRIMARY KEY CLUSTERED 
(
	[DrivingSchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

