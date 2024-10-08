CREATE DATABASE TechnicalTestDb;
GO

USE [TechnicalTestDb]
CREATE TABLE [dbo].[DisabilityType](
	[DisabilityTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DisabilityName] [nvarchar](100) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[DisabilityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FormSubmissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[AdditionalAccessibilityRequirements] [nvarchar](max) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[LevelOfStudy] [nvarchar](50) NULL,
	[PreferredPronoun] [varchar](50) NULL,
	[International] [bit] NOT NULL,
	[Consent] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormSubmissions] ADD  DEFAULT ((0)) FOR [International]
GO

ALTER TABLE [dbo].[FormSubmissions] ADD  DEFAULT ((0)) FOR [Consent]
GO

CREATE TABLE [dbo].[SubmissionDisability](
	[FormSubmissionId] [int] NOT NULL,
	[DisabilityTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FormSubmissionId] ASC,
	[DisabilityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubmissionDisability]  WITH CHECK ADD FOREIGN KEY([DisabilityTypeId])
REFERENCES [dbo].[DisabilityType] ([DisabilityTypeId])
GO

ALTER TABLE [dbo].[SubmissionDisability]  WITH CHECK ADD FOREIGN KEY([FormSubmissionId])
REFERENCES [dbo].[FormSubmissions] ([Id])
GO

INSERT INTO DisabilityType (DisabilityName)
VALUES ('ADHD'), ('Autism'), ('Chronic illness'), 
       ('Deaf or hard of hearing'), ('Learning disability'),
       ('Mental health'), ('Neurological'), ('Physical or mobility'),
       ('Vision'), ('Other');

INSERT INTO FormSubmissions(Email, AdditionalAccessibilityRequirements, FirstName, LastName, LevelOfStudy, PreferredPronoun, International, Consent)
VALUES
('john.doe@example.com', 'Needs accessible seating', 'John', 'Doe', 'Undergraduate', 'He/Him', 1, 1),
('jane.smith@example.com', NULL, 'Jane', 'Smith', 'Graduate', 'She/Her', 0, 1),
('alex.brown@example.com', 'Requires interpreter services', 'Alex', 'Brown', 'HighSchoolGraduate', 'They/Them', 1, 1),
('sam.taylor@example.com', 'Requires large print materials', 'Sam', 'Taylor', 'Undergraduate', 'He/Him', 0, 1),
('chris.johnson@example.com', NULL, 'Chris', 'Johnson', 'Graduate', 'She/Her', 0, 1);

INSERT INTO SubmissionDisability(FormSubmissionId,DisabilityTypeId)
VALUES
(1,1),
(2,1),
(2,2),
(2,3),
(2,4),
(3,1),
(4,1),
(4,2),
(5,2),
(5,3),
(5,9);

