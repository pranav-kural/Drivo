USE [DrivoDb]
GO

/****** Object:  Table [dbo].[Instructors]    Script Date: 2017-08-13 6:40:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[DrivingSchool_Instructors](
	[InstructorsDrivingSchoolId] [nvarchar](128) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[InstructorId] [nvarchar](128) NOT NULL,
	[DrivingSchoolId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.DrivingSchool_Instructors] PRIMARY KEY CLUSTERED 
(
	[InstructorsDrivingSchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



ALTER TABLE [dbo].[DrivingSchool_Instructors] ADD  CONSTRAINT [DF_dbo.DrivingSchool_Instructors_InstructorsDrivingSchoolId]  DEFAULT (newid()) FOR [InstructorsDrivingSchoolId]
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors] ADD  CONSTRAINT [DF_dbo.DrivingSchool_Instructors_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors] ADD  CONSTRAINT [DF_dbo.DrivingSchool_Instructors_EditDate]  DEFAULT (getutcdate()) FOR [EditDate]
GO


ALTER TABLE [dbo].[DrivingSchools] ADD  CONSTRAINT [DF_dbo.DrivingSchools_DrivingSchoolId]  DEFAULT (newid()) FOR [DrivingSchoolId]
GO

ALTER TABLE [dbo].[Instructors] ADD  CONSTRAINT [DF_dbo.Instructors_InstructorsId]  DEFAULT (newid()) FOR [InstructorId]
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DrivingSchool_Instructors_InstructorId] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructors] ([InstructorId])
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors] CHECK CONSTRAINT [FK_dbo.DrivingSchool_Instructors_InstructorId]
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DrivingSchool_Instructors_DrivingSchoolId] FOREIGN KEY([DrivingSchoolId])
REFERENCES [dbo].[DrivingSchools] ([DrivingSchoolId])
GO

ALTER TABLE [dbo].[DrivingSchool_Instructors] CHECK CONSTRAINT [FK_dbo.DrivingSchool_Instructors_DrivingSchoolId]
GO