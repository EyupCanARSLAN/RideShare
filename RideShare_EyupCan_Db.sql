USE [master]
GO
/****** Object:  Database [RideShare]    Script Date: 25.09.2020 03:29:02 ******/
CREATE DATABASE [RideShare]
GO
ALTER DATABASE [RideShare] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RideShare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RideShare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RideShare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RideShare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RideShare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RideShare] SET ARITHABORT OFF 
GO
ALTER DATABASE [RideShare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RideShare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RideShare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RideShare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RideShare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RideShare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RideShare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RideShare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RideShare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RideShare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RideShare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RideShare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RideShare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RideShare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RideShare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RideShare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RideShare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RideShare] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RideShare] SET  MULTI_USER 
GO
ALTER DATABASE [RideShare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RideShare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RideShare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RideShare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RideShare] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RideShare] SET QUERY_STORE = OFF
GO
USE [RideShare]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [RideShare]
GO
/****** Object:  Table [dbo].[Passanger]    Script Date: 25.09.2020 03:29:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passanger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PassangerName] [nvarchar](max) NOT NULL,
	[TripDetailFk] [int] NOT NULL,
	[TokenForThisReservation] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Passanger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 25.09.2020 03:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DriverName] [nvarchar](max) NOT NULL,
	[TravelDate] [datetime] NOT NULL,
	[AllowedMaxPassagerCount] [int] NOT NULL,
	[Explanation] [nvarchar](max) NOT NULL,
	[isThisTripActive] [bit] NOT NULL,
	[CurrentPassangerCount] [int] NOT NULL,
	[Routate] [nvarchar](max) NOT NULL,
	[TripToken] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TripDetail]    Script Date: 25.09.2020 03:29:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Route] [nvarchar](max) NOT NULL,
	[Distance] [int] NOT NULL,
	[PassengerCountForThisDistance] [int] NOT NULL,
	[TripFK] [int] NOT NULL,
	[TripDetailToken] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TripDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Passanger] ON 

INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (4, N'Yakup ARSLAN', 62, N'08762864-97c4-41f1-846a-6e1e5923e27e')
INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (5, N'Niyazi ARSLAN', 62, N'f1405c9f-4db8-4202-b8dd-9a9a895fd79b')
INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (6, N'Basri ARSLAN', 62, N'1f93797c-df73-4fbd-b57e-e63395518677')
INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (7, N'yaşar ARSLAN', 62, N'2fd323c8-833f-4717-93a6-21a2cec93c6f')
INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (8, N'Yolcu1 ARSLAN', 68, N'dab03c0e-0d0f-4399-aae6-3fcbdd5dbce1')
INSERT [dbo].[Passanger] ([Id], [PassangerName], [TripDetailFk], [TokenForThisReservation]) VALUES (9, N'Yolcu1 ARSLAN', 91, N'31aed9b7-61fa-4019-9f0a-049dcb006606')
SET IDENTITY_INSERT [dbo].[Passanger] OFF
SET IDENTITY_INSERT [dbo].[Trip] ON 

INSERT [dbo].[Trip] ([Id], [DriverName], [TravelDate], [AllowedMaxPassagerCount], [Explanation], [isThisTripActive], [CurrentPassangerCount], [Routate], [TripToken]) VALUES (6, N'Eyup Arslan', CAST(N'2021-12-01T00:00:00.000' AS DateTime), 4, N'Start F5, Finish F4 cities. Only four passanger', 1, 4, N'F5,F6,G6,G5,G4,F4', N'9a811f23-5728-47e2-9883-eada704b6bab')
INSERT [dbo].[Trip] ([Id], [DriverName], [TravelDate], [AllowedMaxPassagerCount], [Explanation], [isThisTripActive], [CurrentPassangerCount], [Routate], [TripToken]) VALUES (7, N'Can Arslan', CAST(N'2021-11-01T00:00:00.000' AS DateTime), 3, N'Start D5, Finish B6 cities.', 1, 1, N'D5,D6,C6,B6', N'1a070278-d356-4048-807f-56124750ce51')
INSERT [dbo].[Trip] ([Id], [DriverName], [TravelDate], [AllowedMaxPassagerCount], [Explanation], [isThisTripActive], [CurrentPassangerCount], [Routate], [TripToken]) VALUES (8, N'Driver1 Arslan', CAST(N'2021-11-01T00:00:00.000' AS DateTime), 3, N'Start D5, Finish B6 cities.', 1, 0, N'D5,D6,C6,B6', N'8476dc47-02b1-4669-8b3f-f88349323674')
INSERT [dbo].[Trip] ([Id], [DriverName], [TravelDate], [AllowedMaxPassagerCount], [Explanation], [isThisTripActive], [CurrentPassangerCount], [Routate], [TripToken]) VALUES (9, N'Driver2 Arslan', CAST(N'2021-11-01T00:00:00.000' AS DateTime), 3, N'Start D5, Finish B6 cities.', 1, 0, N'D5,D6,C6,B6', N'b31547e5-b6e2-45c8-a86f-6816fd0aba09')
INSERT [dbo].[Trip] ([Id], [DriverName], [TravelDate], [AllowedMaxPassagerCount], [Explanation], [isThisTripActive], [CurrentPassangerCount], [Routate], [TripToken]) VALUES (10, N'Driver4 Arslan', CAST(N'2021-11-01T00:00:00.000' AS DateTime), 3, N'Start D5, Finish B6 cities.', 1, 1, N'D5,D6,C6,B6', N'ddc03932-3dde-4781-9960-513e8e4ad283')
SET IDENTITY_INSERT [dbo].[Trip] OFF
SET IDENTITY_INSERT [dbo].[TripDetail] ON 

INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (53, N'F5,F6', 50, 0, 6, N'13230e49-410e-4283-a142-2d5315312477')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (54, N'F5,G6', 100, 0, 6, N'e0e07ee4-20f2-4528-96d7-20f536c1098e')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (55, N'F5,G5', 150, 0, 6, N'e46d22d5-34a2-4bd9-976f-f48a0e08ed62')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (56, N'F5,G4', 200, 0, 6, N'460341aa-9dd9-46f1-9bf3-c2c4f106e992')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (57, N'F5,F4', 250, 0, 6, N'd1d0144a-bc6d-46b5-89b0-368c6219be6d')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (58, N'F6,G6', 50, 0, 6, N'6d84a506-7da5-4a23-833c-7a18de6fb18c')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (59, N'F6,G5', 100, 0, 6, N'6ef7cfec-dd00-4258-9d62-3fc0d00a6b2c')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (60, N'F6,G4', 150, 0, 6, N'b8d3b690-30a4-4d7b-836f-6736f23bca50')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (61, N'F6,F4', 200, 0, 6, N'9c6d4e8e-d388-49fb-adbe-c4d2f7a9d0a0')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (62, N'G6,G5', 50, 4, 6, N'd8297d5e-826d-44a0-b46e-226f7cdf049b')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (63, N'G6,G4', 100, 0, 6, N'08cd9c10-9cf4-4892-a923-a82e9507e929')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (64, N'G6,F4', 150, 0, 6, N'f341340f-a550-4b6b-be91-7289d2f0d350')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (65, N'G5,G4', 50, 0, 6, N'1de2ebc8-9134-4164-a5f2-e5ef00b7ca04')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (66, N'G5,F4', 100, 0, 6, N'243cf57e-8182-4f53-be06-323904b51450')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (67, N'G4,F4', 50, 0, 6, N'e1d4d630-0c80-4769-859c-afb3d0c11940')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (68, N'D5,D6', 50, 1, 7, N'5804301c-4ed5-4752-86c2-bcfdd07e9bc3')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (69, N'D5,C6', 100, 0, 7, N'576478ab-8d26-470d-8613-f639b5029acf')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (70, N'D5,B6', 150, 0, 7, N'cf3627c3-2b5b-4ea0-91cc-58277c84d312')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (71, N'D6,C6', 50, 0, 7, N'abb6c977-8127-4364-97dc-ed025d5fecb8')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (72, N'D6,B6', 100, 0, 7, N'62bdc91a-b0aa-4eff-a4aa-8bc40473e3ff')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (73, N'C6,B6', 50, 0, 7, N'd63da717-0534-4bff-b2d0-81cd82455962')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (74, N'D5,D6', 50, 0, 8, N'afb83b97-a24b-4b7f-a06b-211f601dc80d')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (75, N'D5,C6', 100, 0, 8, N'8dcb337d-94c2-4b5a-80d3-12a2c866f1c2')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (76, N'D5,B6', 150, 0, 8, N'beac3c47-db9c-4aa2-823d-f752a1feaa64')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (77, N'D6,C6', 50, 0, 8, N'47abe014-3571-4180-ae66-49e1d3512d04')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (78, N'D6,B6', 100, 0, 8, N'ba7d6172-06e0-4ac1-8b10-81f61b3b14ab')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (79, N'C6,B6', 50, 0, 8, N'9a9ec4c7-9e9c-4dbd-9ac5-2cbe2718473d')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (80, N'D5,D6', 50, 0, 9, N'843a6daa-d182-4dc0-a1e8-c2115e5ffca7')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (81, N'D5,C6', 100, 0, 9, N'39e4ae15-92cf-49bf-bdf6-0035bccdd8fc')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (82, N'D5,B6', 150, 0, 9, N'195c0b9e-44f5-4e55-83a1-768e3d0eab64')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (83, N'D6,C6', 50, 0, 9, N'4d34e51f-9d55-4fba-af33-5116cbb8b231')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (84, N'D6,B6', 100, 0, 9, N'af9a8c99-de5e-442a-a13f-ded618b4a263')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (85, N'C6,B6', 50, 0, 9, N'35e35291-bcc3-4fb9-99c5-f984f0b61a87')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (86, N'D5,D6', 50, 0, 10, N'a7b829e6-76e3-47c9-9dab-c365bc797a12')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (87, N'D5,C6', 100, 0, 10, N'd5163acd-0083-43df-aa89-fc1d04db3658')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (88, N'D5,B6', 150, 0, 10, N'502bd13b-fe64-464d-816a-8e5e4af307a8')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (89, N'D6,C6', 50, 0, 10, N'37d0e89d-b501-427f-86e5-eb5f27f39249')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (90, N'D6,B6', 100, 0, 10, N'327a4e15-61b2-4b64-8e8b-cced07d48539')
INSERT [dbo].[TripDetail] ([Id], [Route], [Distance], [PassengerCountForThisDistance], [TripFK], [TripDetailToken]) VALUES (91, N'C6,B6', 50, 1, 10, N'886872d2-1c95-4d6b-b4d4-12332e0562d2')
SET IDENTITY_INSERT [dbo].[TripDetail] OFF
ALTER TABLE [dbo].[Trip] ADD  CONSTRAINT [DF_Trip_isThisTripActive]  DEFAULT ((1)) FOR [isThisTripActive]
GO
ALTER TABLE [dbo].[Trip] ADD  CONSTRAINT [DF_Trip_CurrentPassangerCount]  DEFAULT ((0)) FOR [CurrentPassangerCount]
GO
ALTER TABLE [dbo].[Trip] ADD  CONSTRAINT [DF_Trip_Routate]  DEFAULT ('---') FOR [Routate]
GO
ALTER TABLE [dbo].[Trip] ADD  CONSTRAINT [DF_Trip_TripToken]  DEFAULT ('------------') FOR [TripToken]
GO
ALTER TABLE [dbo].[TripDetail] ADD  CONSTRAINT [DF_TripDetail_TripDetailToken]  DEFAULT ('--------------------') FOR [TripDetailToken]
GO
ALTER TABLE [dbo].[Passanger]  WITH CHECK ADD  CONSTRAINT [FK_Passanger_TripDetail] FOREIGN KEY([TripDetailFk])
REFERENCES [dbo].[TripDetail] ([Id])
GO
ALTER TABLE [dbo].[Passanger] CHECK CONSTRAINT [FK_Passanger_TripDetail]
GO
ALTER TABLE [dbo].[TripDetail]  WITH CHECK ADD  CONSTRAINT [FK_TripDetail_Trip] FOREIGN KEY([TripFK])
REFERENCES [dbo].[Trip] ([Id])
GO
ALTER TABLE [dbo].[TripDetail] CHECK CONSTRAINT [FK_TripDetail_Trip]
GO
USE [master]
GO
ALTER DATABASE [RideShare] SET  READ_WRITE 
GO
