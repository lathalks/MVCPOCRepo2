USE [Sample]
GO

/****** Object:  Table [dbo].[Applicant]    Script Date: 15-04-2021 15:00:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Applicant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[BusinessEmail] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[CompanyRegNo] [varchar](10) NULL,
	[TypeID] [int] NULL,
	[Username] [varchar](20) NULL,
	[Password] [varchar](10) NULL,
	[IsTermChecked] [bit] NOT NULL,
 CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_Applicant_ApplicantType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[ApplicantType] ([ID])
GO

ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_Applicant_ApplicantType]
GO


