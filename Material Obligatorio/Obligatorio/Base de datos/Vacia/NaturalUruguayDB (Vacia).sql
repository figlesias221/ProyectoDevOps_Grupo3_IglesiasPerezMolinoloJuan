USE [NaturalUruguayDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accommodations]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accommodations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Accommodations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorizationTokens]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorizationTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[AdministratorId] [int] NOT NULL,
	[ValidSince] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AuthorizationTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuestGroups]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuestGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestGroupType] [nvarchar](max) NOT NULL,
	[AccommodationId] [int] NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_GuestGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [varchar](max) NOT NULL,
	[ResortId] [int] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [uniqueidentifier] NOT NULL,
	[ResortId] [int] NOT NULL,
	[AccommodationId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ActualStateId] [int] NOT NULL,
	[TotalPrice] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationStates]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ReservationStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resorts]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resorts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TouristPointId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stars] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PricePerNight] [int] NOT NULL,
	[Available] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[ReservationMessage] [nvarchar](max) NOT NULL,
	[Punctuation] [float] NOT NULL,
	[MemberSince] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Resorts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Stars] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[ResortId] [int] NOT NULL,
	[ReservationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristPointCategories]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristPointCategories](
	[CategoryId] [int] NOT NULL,
	[TouristPointId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TouristPointCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristPoints]    Script Date: 11/26/2020 2:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[RegionId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_TouristPoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[GuestGroups] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Reservations] ADD  DEFAULT ((0)) FOR [ActualStateId]
GO
ALTER TABLE [dbo].[Reservations] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Resorts] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Punctuation]
GO
ALTER TABLE [dbo].[Resorts] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [MemberSince]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ReservationId]
GO
ALTER TABLE [dbo].[TouristPointCategories] ADD  DEFAULT ((0)) FOR [TouristPointId]
GO
ALTER TABLE [dbo].[AuthorizationTokens]  WITH CHECK ADD  CONSTRAINT [FK_AuthorizationTokens_Administrators_AdministratorId] FOREIGN KEY([AdministratorId])
REFERENCES [dbo].[Administrators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthorizationTokens] CHECK CONSTRAINT [FK_AuthorizationTokens_Administrators_AdministratorId]
GO
ALTER TABLE [dbo].[GuestGroups]  WITH CHECK ADD  CONSTRAINT [FK_GuestGroups_Accommodations_AccommodationId] FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodations] ([Id])
GO
ALTER TABLE [dbo].[GuestGroups] CHECK CONSTRAINT [FK_GuestGroups_Accommodations_AccommodationId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Resorts_ResortId] FOREIGN KEY([ResortId])
REFERENCES [dbo].[Resorts] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Resorts_ResortId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Accommodations_AccommodationId] FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Accommodations_AccommodationId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationStates_ActualStateId] FOREIGN KEY([ActualStateId])
REFERENCES [dbo].[ReservationStates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_ReservationStates_ActualStateId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Resorts_ResortId] FOREIGN KEY([ResortId])
REFERENCES [dbo].[Resorts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Resorts_ResortId]
GO
ALTER TABLE [dbo].[Resorts]  WITH CHECK ADD  CONSTRAINT [FK_Resorts_TouristPoints_TouristPointId] FOREIGN KEY([TouristPointId])
REFERENCES [dbo].[TouristPoints] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Resorts] CHECK CONSTRAINT [FK_Resorts_TouristPoints_TouristPointId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Resorts_ResortId] FOREIGN KEY([ResortId])
REFERENCES [dbo].[Resorts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Resorts_ResortId]
GO
ALTER TABLE [dbo].[TouristPointCategories]  WITH CHECK ADD  CONSTRAINT [FK_TouristPointCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristPointCategories] CHECK CONSTRAINT [FK_TouristPointCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[TouristPointCategories]  WITH CHECK ADD  CONSTRAINT [FK_TouristPointCategories_TouristPoints_TouristPointId] FOREIGN KEY([TouristPointId])
REFERENCES [dbo].[TouristPoints] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristPointCategories] CHECK CONSTRAINT [FK_TouristPointCategories_TouristPoints_TouristPointId]
GO
ALTER TABLE [dbo].[TouristPoints]  WITH CHECK ADD  CONSTRAINT [FK_TouristPoints_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristPoints] CHECK CONSTRAINT [FK_TouristPoints_Images_ImageId]
GO
ALTER TABLE [dbo].[TouristPoints]  WITH CHECK ADD  CONSTRAINT [FK_TouristPoints_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristPoints] CHECK CONSTRAINT [FK_TouristPoints_Regions_RegionId]
GO
