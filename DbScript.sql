USE [master]
GO
/****** Object:  Database [Jobs]    Script Date: 10/23/2021 10:30:52 AM ******/
CREATE DATABASE [Jobs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jobs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jobs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jobs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jobs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Jobs] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jobs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jobs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jobs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jobs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jobs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jobs] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jobs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jobs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jobs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jobs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jobs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jobs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jobs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jobs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jobs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jobs] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Jobs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jobs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jobs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jobs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jobs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jobs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jobs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jobs] SET RECOVERY FULL 
GO
ALTER DATABASE [Jobs] SET  MULTI_USER 
GO
ALTER DATABASE [Jobs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jobs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jobs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jobs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Jobs] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Jobs] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Jobs', N'ON'
GO
ALTER DATABASE [Jobs] SET QUERY_STORE = OFF
GO
USE [Jobs]
GO
/****** Object:  Schema [AUTH]    Script Date: 10/23/2021 10:30:52 AM ******/
CREATE SCHEMA [AUTH]
GO
/****** Object:  Schema [Jobs]    Script Date: 10/23/2021 10:30:52 AM ******/
CREATE SCHEMA [Jobs]
GO
/****** Object:  Table [Jobs].[Departments]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Jobs].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Jobs].[Jobs]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Jobs].[Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[PostedDate] [datetime] NOT NULL,
	[ClosingDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Jobs].[Locations]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Jobs].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[Zip] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Jobs].[Departments] ON 

INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (1, N'Software developer 1')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (2, N'Project Manager')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (3, N'test department 1')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (4, N'ITDepartmentTitle')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (5, N'ITDepartmentTitleUpdate')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (6, N'ITDepartmentTitleUpdate')
INSERT [Jobs].[Departments] ([Id], [Title]) VALUES (7, N'changed Department name')
SET IDENTITY_INSERT [Jobs].[Departments] OFF
GO
SET IDENTITY_INSERT [Jobs].[Jobs] ON 

INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (5, 1, 1, N'JOB-637692', N'test job 1', N'test description', CAST(N'2021-07-10T13:10:22.000' AS DateTime), CAST(N'2021-10-10T07:36:36.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (6, 2, 2, N'JOB-20211007131422', N'changedJobTitle345', N'test', CAST(N'2021-07-10T13:14:10.000' AS DateTime), CAST(N'2021-10-22T14:35:18.447' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (7, 1, 2, N'JOB-20211007134324', N'test job', N'test job description', CAST(N'2021-07-10T13:43:24.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (8, 1, 2, N'JOB-20211007134617', N'test job', N'test job description', CAST(N'2021-07-10T13:46:16.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (9, 1, 2, N'JOB-20211007134915', N'test job', N'test job description', CAST(N'2021-07-10T13:49:15.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (10, 1, 2, N'JOB-20211007135529', N'test job', N'test job description', CAST(N'2021-07-10T13:55:29.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (11, 1, 2, N'JOB-20211007135747', N'test job', N'test job description', CAST(N'2021-07-10T13:57:47.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (12, 1, 2, N'JOB-20211007140405', N'test job', N'test job description', CAST(N'2021-07-10T14:04:04.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (13, 1, 1, N'JOB-20211007155004', N'ITJobTitle', N'ITJobDescription', CAST(N'2021-10-07T15:50:04.953' AS DateTime), CAST(N'2021-10-17T15:50:02.337' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (14, 1, 1, N'JOB-20211007161711', N'ITJobTitle', N'ITJobDescription', CAST(N'2021-10-07T16:17:11.943' AS DateTime), CAST(N'2021-10-17T16:17:11.883' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (15, 1, 1, N'JOB-20211007161819', N'ITJobTitle', N'ITJobDescription', CAST(N'2021-10-07T16:18:19.480' AS DateTime), CAST(N'2021-10-17T16:18:19.403' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (16, 1, 1, N'JOB-20211007161844', N'ITJobTitleUpdate', N'ITJobDescriptionUpdate', CAST(N'2021-10-07T16:18:44.930' AS DateTime), CAST(N'2021-10-17T16:18:45.270' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (17, 1, 1, N'JOB-20211007162122', N'ITJobTitleUpdate', N'ITJobDescriptionUpdate', CAST(N'2021-10-07T16:21:22.717' AS DateTime), CAST(N'2021-10-17T16:21:22.803' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (18, 1, 1, N'JOB-20211007162204', N'ITJobTitleUpdate', N'ITJobDescriptionUpdate', CAST(N'2021-10-07T16:22:04.480' AS DateTime), CAST(N'2021-10-17T16:22:04.560' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (20, 2, 2, N'JOB-', N'testJob 222', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (26, 2, 2, N'JOBOct 22 202', N'testJob 223232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (27, 2, 2, N'JOB-2021-10-22', N'testJob 223231232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (28, 2, 2, N'JOB-Oct 22 202', N'testJob 123232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (29, 2, 2, N'JOB-2021-10-22 18:5', N'testJob 3212232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (30, 2, 2, N'JOB-22 Oct 202', N'testJob 32122123232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (31, 2, 2, N'JOB-22 Oct 2021 18:', N'testJob 321232232', N'test', CAST(N'2021-10-10T08:11:25.000' AS DateTime), CAST(N'2021-10-10T08:11:25.000' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (32, 1, 1, N'JOB-10222021070858PM', N'testing job174564', N'test', CAST(N'2021-10-22T19:08:58.227' AS DateTime), CAST(N'2021-10-22T13:03:35.560' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (33, 1, 1, N'JOB-10222021070944PM', N'testing job174564', N'test', CAST(N'2021-10-22T19:09:44.850' AS DateTime), CAST(N'2021-10-22T13:03:35.560' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (34, 2, 3, N'JOB-10222021073653PM', N'testjob7565', N'test', CAST(N'2021-10-22T19:36:53.140' AS DateTime), CAST(N'2021-10-22T14:06:21.937' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (35, 2, 3, N'JOB-10222021073727PM', N'testjob32345', N'test', CAST(N'2021-10-22T19:37:27.910' AS DateTime), CAST(N'2021-10-22T14:06:21.937' AS DateTime))
INSERT [Jobs].[Jobs] ([Id], [LocationId], [DepartmentId], [Code], [Title], [Description], [PostedDate], [ClosingDate]) VALUES (36, 2, 3, N'JOB-10222021074858PM', N'testjob3214215', N'test', CAST(N'2021-10-22T19:48:58.960' AS DateTime), CAST(N'2021-10-22T14:06:21.937' AS DateTime))
SET IDENTITY_INSERT [Jobs].[Jobs] OFF
GO
SET IDENTITY_INSERT [Jobs].[Locations] ON 

INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (1, N'US Head Office', N'Baltimore', N'MD', N'United States', 21202)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (2, N'India Office', N'Verna', N'Goa', N'India', 403802)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (3, N'test location', N'Panaji', N'Goa', N'India', 403001)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (4, N'US Head Office 3', N'Baltimore', N'MD', N'United States', 21202)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (5, N'ITLocationTitle', N'ITLocationCity', N'ITLocationSatet', N'ITLocationCountry', 1247)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (6, N'ITLocationTitle', N'ITLocationCity', N'ITLocationSatet', N'ITLocationCountry', 1247)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (7, N'ITLocationTitleUpdate', N'ITLocationCityUpdate', N'ITLocationSatetUpdate', N'ITLocationCountryUpdate', 1247)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (8, N'ITLocationTitleUpdate', N'ITLocationCityUpdate', N'ITLocationSatetUpdate', N'ITLocationCountryUpdate', 1247)
INSERT [Jobs].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (9, N'India Main Office', N'Margao', N'Goa', N'India', 403707)
SET IDENTITY_INSERT [Jobs].[Locations] OFF
GO
ALTER TABLE [Jobs].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [Jobs].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Jobs].[Jobs] CHECK CONSTRAINT [FK_Jobs_Departments]
GO
ALTER TABLE [Jobs].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Locations] FOREIGN KEY([LocationId])
REFERENCES [Jobs].[Locations] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Jobs].[Jobs] CHECK CONSTRAINT [FK_Jobs_Locations]
GO
/****** Object:  StoredProcedure [Jobs].[DepartmentsCreate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[DepartmentsCreate]
    @title        varchar(100)

AS
BEGIN
        INSERT INTO Jobs.Departments
        VALUES(@title);
        SELECT SCOPE_IDENTITY() as CreatedEntityId;
END;
GO
/****** Object:  StoredProcedure [Jobs].[DepartmentsGet]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[DepartmentsGet]

AS
BEGIN
        SELECT  
            Id,
            Title
        FROM Jobs.Departments
END;
GO
/****** Object:  StoredProcedure [Jobs].[DepartmentsUpdate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[DepartmentsUpdate]
    @departmentsId      INT,
    @title        varchar(100)
AS
BEGIN

        IF NOT EXISTS(SELECT 1 FROM Jobs.Departments WHERE Id = @departmentsId)
            THROW 50404,'DepartmentId Invalid',1
        UPDATE Jobs.Departments
        SET 
            Title = @title
        WHERE Id = @departmentsId;
END;
GO
/****** Object:  StoredProcedure [Jobs].[JobsCreate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[JobsCreate]
    @title          VARCHAR(100),
    @description    VARCHAR(MAX),
    @locationId     INT,
    @departmentId   INT,
    @code       VARCHAR(50),
    @closingDate    DATETIME,
    @postedDate     DATETIME
AS
BEGIN

        INSERT INTO Jobs.Jobs
        VALUES(@locationId,@departmentId,@code,@title,@description,@postedDate,@closingDate)
        SELECT SCOPE_IDENTITY() As CreatedEntityId;

END;
GO
/****** Object:  StoredProcedure [Jobs].[JobsDetailGet]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[JobsDetailGet]
    @jobId      INT

AS
BEGIN

        IF NOT EXISTS(SELECT 1 FROM Jobs.Jobs WHERE Id = @jobId)
            THROW 50404,'Invalid JobId',1;
        SELECT 
            J.Id,
            J.Code,
            J.Title,
            J.[Description],
            J.PostedDate,
            J.ClosingDate,
            L.Id As LocationId,
            L.Title AS Ltitle,
            L.City,
            L.[State],
            L.Country,
            L.Zip,
            D.Id As DepartmentId,
            D.Title AS Dtitle
        FROM Jobs.Jobs J
        INNER JOIN Jobs.Locations L
        ON L.Id = J.LocationId
        INNER JOIN Jobs.Departments D
        ON D.Id = J.DepartmentId
        WHERE J.Id = @jobId;


END;
GO
/****** Object:  StoredProcedure [Jobs].[JobsGet]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[JobsGet]
    @searchText VARCHAR(100),
    @pageNo     INT =1,
    @pageSize   INT =10,
    @locationId INT =NULL,
    @departmentId   INT = NULL,
    @total  INT OUTPUT

AS
BEGIN
        DECLARE @offset INT
        SELECT @total = COUNT(*) 
        FROM Jobs.Jobs
        WHERE Title like '%'+@searchText+'%'
            AND LocationId = ISNULL(@locationId,LocationId)
            AND DepartmentId = ISNULL(@departmentId,DepartmentId);
        SET @offset = (@pageNo-1)*@pageSize;
        SELECT 
            J.Id,
            J.Code,
            J.Title,
            L.Title [Location],
            D.Title Department,
            J.PostedDate,
            J.ClosingDate
        FROM Jobs.Jobs J
        INNER JOIN Jobs.Locations L
        ON L.Id = J.LocationId
        INNER JOIN Jobs.Departments D
        ON D.Id = J.DepartmentId
        WHERE J.Title like '%'+@searchText+'%'
            AND J.LocationId = ISNULL(@locationId,J.LocationId)
            AND J.DepartmentId = ISNULL(@departmentId,J.DepartmentId)
        ORDER BY J.Id
        OFFSET @offset ROWS
        FETCH NEXT @pageSize ROWS ONLY;


END;
GO
/****** Object:  StoredProcedure [Jobs].[JobsUpdate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[JobsUpdate]
    @jobId          INT,
    @title          VARCHAR(100),
    @description    VARCHAR(MAX),
    @locationId     INT,
    @departmentId   INT,
    @closingDate    DATETIME

AS
BEGIN

        IF NOT EXISTS(SELECT 1 FROM Jobs.Jobs WHERE Id = @jobId)
            THROW 50404,'Invalid JobId',1
        UPDATE Jobs.Jobs
        SET
            LocationId =@locationId,
            DepartmentId=@departmentId,
            [Title]=@title,
            [Description]=@description,
            ClosingDate=@closingDate
        WHERE Id = @jobId;
END;
GO
/****** Object:  StoredProcedure [Jobs].[LocationsCreate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[LocationsCreate]
    @title        varchar(100),
    @city         varchar(100),
    @state        varchar(100),
    @country      varchar(100),
    @zip        INT
AS
BEGIN
        INSERT INTO Jobs.Locations
        VALUES(@title,@city,@state,@country,@zip);
        SELECT SCOPE_IDENTITY() as CreatedEntityId;
END;
GO
/****** Object:  StoredProcedure [Jobs].[LocationsGet]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[LocationsGet]

AS
BEGIN
        SELECT  Id,
                Title,
                City,
                [State],
                Country,
                Zip
        FROM Jobs.Locations;
END;
GO
/****** Object:  StoredProcedure [Jobs].[LocationsUpdate]    Script Date: 10/23/2021 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Jobs].[LocationsUpdate]
    @locationId     INT,
    @title        varchar(100),
    @city         varchar(100),
    @state        varchar(100),
    @country      varchar(100),
    @zip        INT
AS
BEGIN
        IF NOT EXISTS(SELECT 1 FROM Jobs.Locations WHERE Id = @locationId)
            THROW 50404,'LocationId Invalid',1
        UPDATE Jobs.Locations
        SET 
            Title = @title,
            City = @city,
            [State] = @state,
            Country = @country,
            Zip = @zip
        WHERE Id = @locationId;
END;
GO
USE [master]
GO
ALTER DATABASE [Jobs] SET  READ_WRITE 
GO
