USE [master]
GO
/****** Object:  Database [FastCreditDb]    Script Date: 10/25/2023 1:18:12 PM ******/
CREATE DATABASE [FastCreditDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FastCreditDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FastCreditDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FastCreditDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FastCreditDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FastCreditDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FastCreditDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FastCreditDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FastCreditDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FastCreditDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FastCreditDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FastCreditDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [FastCreditDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FastCreditDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FastCreditDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FastCreditDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FastCreditDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FastCreditDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FastCreditDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FastCreditDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FastCreditDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FastCreditDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FastCreditDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FastCreditDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FastCreditDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FastCreditDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FastCreditDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FastCreditDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FastCreditDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FastCreditDb] SET RECOVERY FULL 
GO
ALTER DATABASE [FastCreditDb] SET  MULTI_USER 
GO
ALTER DATABASE [FastCreditDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FastCreditDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FastCreditDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FastCreditDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FastCreditDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FastCreditDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FastCreditDb', N'ON'
GO
ALTER DATABASE [FastCreditDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [FastCreditDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FastCreditDb]
GO
/****** Object:  Table [dbo].[National]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[National](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_National] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NULL,
	[EmailAddress] [nvarchar](250) NULL,
	[UserName] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[UserStatusId] [smallint] NOT NULL,
	[Gender] [nvarchar](250) NULL,
	[DateOfBirth] [datetime] NULL,
	[PasswordExpiryDate] [datetime] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[DateModified] [datetime] NULL,
	[ModifiedByUserId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedByUserId] [int] NULL,
	[LockedOutDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNational]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNational](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[NationalId] [smallint] NOT NULL,
 CONSTRAINT [PK_UserNational] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [smallint] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 10/25/2023 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatus](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[National] ON 

INSERT [dbo].[National] ([Id], [Name]) VALUES (1, N'American')
INSERT [dbo].[National] ([Id], [Name]) VALUES (2, N'Canadian')
INSERT [dbo].[National] ([Id], [Name]) VALUES (3, N'Australian')
INSERT [dbo].[National] ([Id], [Name]) VALUES (4, N'Nigerian')
SET IDENTITY_INSERT [dbo].[National] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Student')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Password], [EmailAddress], [UserName], [PhoneNumber], [UserStatusId], [Gender], [DateOfBirth], [PasswordExpiryDate], [DateCreated], [CreatedByUserId], [DateModified], [ModifiedByUserId], [IsDeleted], [DateDeleted], [DeletedByUserId], [LockedOutDate]) VALUES (4, N'testingjoe', N'testtest', N'AcvVyUJJKLTtrD31rM2D6Q==', N'testingjr@gmail.com', NULL, N'08065432226', 1, N'Male', CAST(N'1980-12-08T00:00:00.000' AS DateTime), NULL, CAST(N'2023-10-23T18:15:08.180' AS DateTime), NULL, NULL, NULL, 1, CAST(N'2023-10-25T08:31:18.880' AS DateTime), 0, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Password], [EmailAddress], [UserName], [PhoneNumber], [UserStatusId], [Gender], [DateOfBirth], [PasswordExpiryDate], [DateCreated], [CreatedByUserId], [DateModified], [ModifiedByUserId], [IsDeleted], [DateDeleted], [DeletedByUserId], [LockedOutDate]) VALUES (5, N'testingjoe', N'testtest', N'AcvVyUJJKLTtrD31rM2D6Q==', N'testingjoe@gmail.com', NULL, N'08065432226', 1, N'Male', CAST(N'1980-12-08T00:00:00.000' AS DateTime), NULL, CAST(N'2023-10-23T18:44:40.680' AS DateTime), NULL, NULL, NULL, 1, CAST(N'2023-10-25T12:01:13.570' AS DateTime), 0, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Password], [EmailAddress], [UserName], [PhoneNumber], [UserStatusId], [Gender], [DateOfBirth], [PasswordExpiryDate], [DateCreated], [CreatedByUserId], [DateModified], [ModifiedByUserId], [IsDeleted], [DateDeleted], [DeletedByUserId], [LockedOutDate]) VALUES (7, N'Okobi', N'Mike', N'AcvVyUJJKLTtrD31rM2D6Q==', N'test23@gmail.com', NULL, N'08028879998', 1, N'Male', CAST(N'1987-02-03T00:00:00.000' AS DateTime), NULL, CAST(N'2023-10-24T16:37:19.643' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Password], [EmailAddress], [UserName], [PhoneNumber], [UserStatusId], [Gender], [DateOfBirth], [PasswordExpiryDate], [DateCreated], [CreatedByUserId], [DateModified], [ModifiedByUserId], [IsDeleted], [DateDeleted], [DeletedByUserId], [LockedOutDate]) VALUES (8, N'Peter', N'luke', N'AcvVyUJJKLTtrD31rM2D6Q==', N'brekit@hotmail.com', NULL, N'08323456676', 1, N'Female', CAST(N'1994-03-15T00:00:00.000' AS DateTime), NULL, CAST(N'2023-10-25T08:33:29.957' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Password], [EmailAddress], [UserName], [PhoneNumber], [UserStatusId], [Gender], [DateOfBirth], [PasswordExpiryDate], [DateCreated], [CreatedByUserId], [DateModified], [ModifiedByUserId], [IsDeleted], [DateDeleted], [DeletedByUserId], [LockedOutDate]) VALUES (9, N'Fred', N'ade', N'AcvVyUJJKLTtrD31rM2D6Q==', N'ade30@gmail.com', NULL, N'08028873333', 1, N'Male', CAST(N'2000-07-12T00:00:00.000' AS DateTime), NULL, CAST(N'2023-10-25T12:02:22.997' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserNational] ON 

INSERT [dbo].[UserNational] ([Id], [UserId], [NationalId]) VALUES (5, 5, 2)
INSERT [dbo].[UserNational] ([Id], [UserId], [NationalId]) VALUES (6, 4, 2)
INSERT [dbo].[UserNational] ([Id], [UserId], [NationalId]) VALUES (8, 7, 3)
INSERT [dbo].[UserNational] ([Id], [UserId], [NationalId]) VALUES (9, 8, 3)
INSERT [dbo].[UserNational] ([Id], [UserId], [NationalId]) VALUES (10, 9, 2)
SET IDENTITY_INSERT [dbo].[UserNational] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId]) VALUES (1, 1, 4)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId]) VALUES (2, 1, 5)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId]) VALUES (4, 1, 7)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId]) VALUES (5, 1, 8)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId]) VALUES (6, 1, 9)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[UserStatus] ON 

INSERT [dbo].[UserStatus] ([Id], [Name]) VALUES (1, N'Active')
INSERT [dbo].[UserStatus] ([Id], [Name]) VALUES (2, N'Inactive')
INSERT [dbo].[UserStatus] ([Id], [Name]) VALUES (3, N'Expired')
INSERT [dbo].[UserStatus] ([Id], [Name]) VALUES (4, N'Locked')
SET IDENTITY_INSERT [dbo].[UserStatus] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserStatus] FOREIGN KEY([UserStatusId])
REFERENCES [dbo].[UserStatus] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserStatus]
GO
ALTER TABLE [dbo].[UserNational]  WITH CHECK ADD  CONSTRAINT [FK_UserNational_National] FOREIGN KEY([NationalId])
REFERENCES [dbo].[National] ([Id])
GO
ALTER TABLE [dbo].[UserNational] CHECK CONSTRAINT [FK_UserNational_National]
GO
ALTER TABLE [dbo].[UserNational]  WITH CHECK ADD  CONSTRAINT [FK_UserNational_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserNational] CHECK CONSTRAINT [FK_UserNational_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_UserRole]
GO
USE [master]
GO
ALTER DATABASE [FastCreditDb] SET  READ_WRITE 
GO
