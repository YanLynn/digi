USE [master]
GO
/****** Object:  Database [DigitalImage]    Script Date: 24/3/2023 11:13:39 am ******/
CREATE DATABASE [DigitalImage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'digital_Imaging', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\digital_Imaging.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'digital_Imaging_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\digital_Imaging_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DigitalImage] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DigitalImage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DigitalImage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DigitalImage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DigitalImage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DigitalImage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DigitalImage] SET ARITHABORT OFF 
GO
ALTER DATABASE [DigitalImage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DigitalImage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DigitalImage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DigitalImage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DigitalImage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DigitalImage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DigitalImage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DigitalImage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DigitalImage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DigitalImage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DigitalImage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DigitalImage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DigitalImage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DigitalImage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DigitalImage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DigitalImage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DigitalImage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DigitalImage] SET RECOVERY FULL 
GO
ALTER DATABASE [DigitalImage] SET  MULTI_USER 
GO
ALTER DATABASE [DigitalImage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DigitalImage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DigitalImage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DigitalImage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DigitalImage] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DigitalImage] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DigitalImage] SET QUERY_STORE = OFF
GO
USE [DigitalImage]
GO
/****** Object:  Table [dbo].[fileType]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fileType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileName] [nvarchar](50) NULL,
 CONSTRAINT [PK_file_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uenType]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uenType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uenName] [nvarchar](50) NULL,
 CONSTRAINT [PK_uen_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docType]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docName] [nvarchar](50) NULL,
 CONSTRAINT [PK_doc_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fileInfo]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fileInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileUniqueID] [nvarchar](50) NULL,
	[imageList] [nvarchar](255) NULL,
	[pro_date] [date] NULL,
	[rumNum] [nvarchar](50) NULL,
	[fileType_id] [int] NULL,
	[uenType_id] [int] NULL,
	[uenValue] [nvarchar](50) NULL,
	[docType_id] [int] NULL,
	[status] [int] NULL,
	[maker] [nvarchar](50) NULL,
	[chacker] [nvarchar](50) NULL,
	[genPDF] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_file_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_fileInfo]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_fileInfo]
AS
SELECT dbo.fileInfo.id, dbo.fileInfo.fileUniqueID, dbo.fileInfo.imageList, dbo.fileInfo.pro_date, dbo.fileInfo.rumNum, dbo.fileInfo.uenValue, dbo.fileInfo.status, dbo.fileInfo.maker, dbo.fileInfo.chacker, dbo.fileInfo.genPDF, dbo.fileInfo.created_at, dbo.fileType.fileName, dbo.uenType.uenName, dbo.docType.docName
FROM   dbo.fileInfo INNER JOIN
            dbo.fileType ON dbo.fileInfo.fileType_id = dbo.fileType.id INNER JOIN
            dbo.uenType ON dbo.fileInfo.uenType_id = dbo.uenType.id INNER JOIN
            dbo.docType ON dbo.fileInfo.docType_id = dbo.docType.id
GO
/****** Object:  Table [dbo].[user_auditTrail]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_auditTrail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileInfoID] [int] NULL,
	[username] [nvarchar](50) NULL,
	[machine_name] [nvarchar](50) NULL,
	[message] [nvarchar](50) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_user_auditTrail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 24/3/2023 11:13:39 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[machine_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[docType] ON 

INSERT [dbo].[docType] ([id], [docName]) VALUES (1, N'docType1')
INSERT [dbo].[docType] ([id], [docName]) VALUES (2, N'docType2')
INSERT [dbo].[docType] ([id], [docName]) VALUES (3, N'docType3')
SET IDENTITY_INSERT [dbo].[docType] OFF
GO
SET IDENTITY_INSERT [dbo].[fileInfo] ON 

INSERT [dbo].[fileInfo] ([id], [fileUniqueID], [imageList], [pro_date], [rumNum], [fileType_id], [uenType_id], [uenValue], [docType_id], [status], [maker], [chacker], [genPDF], [created_at]) VALUES (4, N'CTNETSOL902', N'imagelist1,imagelist2,imagelist3', CAST(N'2023-03-23' AS Date), N'file-name', 1, 1, N'test', 1, 1, N'', N'', N'e78c8bcd-6ad0-41d9-8445-1f21d9ab419a', CAST(N'2023-03-23T11:21:43.350' AS DateTime))
INSERT [dbo].[fileInfo] ([id], [fileUniqueID], [imageList], [pro_date], [rumNum], [fileType_id], [uenType_id], [uenValue], [docType_id], [status], [maker], [chacker], [genPDF], [created_at]) VALUES (5, N'f5ae80f1-2fdf-4047-9b8a-f4e7fc985f173', N'imagelist1,imagelist2,imagelist3', CAST(N'2023-03-23' AS Date), N'file-name', 1, 1, N'test', 1, 0, N'', N'', N'e78c8bcd-6ad0-41d9-8445-1f21d9ab419a', CAST(N'2023-03-23T11:21:43.350' AS DateTime))
INSERT [dbo].[fileInfo] ([id], [fileUniqueID], [imageList], [pro_date], [rumNum], [fileType_id], [uenType_id], [uenValue], [docType_id], [status], [maker], [chacker], [genPDF], [created_at]) VALUES (6, N'f5ae80f1-2fdf-4047-9b8a-f4e7fc985f17', N'imagelist1,imagelist2,imagelist3', CAST(N'2023-03-23' AS Date), N'file-name', 1, 1, N'test', 1, 1, N'', N'', N'e78c8bcd-6ad0-41d9-8445-1f21d9ab419a', CAST(N'2023-03-23T11:21:43.350' AS DateTime))
INSERT [dbo].[fileInfo] ([id], [fileUniqueID], [imageList], [pro_date], [rumNum], [fileType_id], [uenType_id], [uenValue], [docType_id], [status], [maker], [chacker], [genPDF], [created_at]) VALUES (7, N'f5ae80f1-2fdf-4047-9b8a-f4e7fc985f171', N'imagelist1,imagelist2,imagelist3', CAST(N'2023-03-23' AS Date), N'file-name', 1, 1, N'test', 1, 0, N'', N'', N'e78c8bcd-6ad0-41d9-8445-1f21d9ab419a', CAST(N'2023-03-23T11:21:43.350' AS DateTime))
SET IDENTITY_INSERT [dbo].[fileInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[fileType] ON 

INSERT [dbo].[fileType] ([id], [fileName]) VALUES (1, N'fileTyp1')
INSERT [dbo].[fileType] ([id], [fileName]) VALUES (2, N'fileTyp2')
INSERT [dbo].[fileType] ([id], [fileName]) VALUES (3, N'fileTyp3')
SET IDENTITY_INSERT [dbo].[fileType] OFF
GO
SET IDENTITY_INSERT [dbo].[uenType] ON 

INSERT [dbo].[uenType] ([id], [uenName]) VALUES (1, N'test')
INSERT [dbo].[uenType] ([id], [uenName]) VALUES (2, N'test1')
INSERT [dbo].[uenType] ([id], [uenName]) VALUES (3, N'test2')
SET IDENTITY_INSERT [dbo].[uenType] OFF
GO
ALTER TABLE [dbo].[fileInfo]  WITH CHECK ADD  CONSTRAINT [FK_file_info_doc_info] FOREIGN KEY([docType_id])
REFERENCES [dbo].[docType] ([id])
GO
ALTER TABLE [dbo].[fileInfo] CHECK CONSTRAINT [FK_file_info_doc_info]
GO
ALTER TABLE [dbo].[fileInfo]  WITH CHECK ADD  CONSTRAINT [FK_file_info_file_type] FOREIGN KEY([fileType_id])
REFERENCES [dbo].[fileType] ([id])
GO
ALTER TABLE [dbo].[fileInfo] CHECK CONSTRAINT [FK_file_info_file_type]
GO
ALTER TABLE [dbo].[fileInfo]  WITH CHECK ADD  CONSTRAINT [FK_file_info_uen_type] FOREIGN KEY([uenType_id])
REFERENCES [dbo].[uenType] ([id])
GO
ALTER TABLE [dbo].[fileInfo] CHECK CONSTRAINT [FK_file_info_uen_type]
GO
ALTER TABLE [dbo].[user_auditTrail]  WITH CHECK ADD  CONSTRAINT [FK_user_auditTrail_fileInfo] FOREIGN KEY([fileInfoID])
REFERENCES [dbo].[fileInfo] ([id])
GO
ALTER TABLE [dbo].[user_auditTrail] CHECK CONSTRAINT [FK_user_auditTrail_fileInfo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[27] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fileInfo"
            Begin Extent = 
               Top = 20
               Left = 30
               Bottom = 242
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "fileType"
            Begin Extent = 
               Top = 7
               Left = 370
               Bottom = 165
               Right = 617
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "uenType"
            Begin Extent = 
               Top = 144
               Left = 644
               Bottom = 302
               Right = 891
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "docType"
            Begin Extent = 
               Top = 253
               Left = 361
               Bottom = 411
               Right = 608
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_fileInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_fileInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_fileInfo'
GO
USE [master]
GO
ALTER DATABASE [DigitalImage] SET  READ_WRITE 
GO
