USE [master]
GO
/****** Object:  Database [PandaShopDB]    Script Date: 6/4/2023 4:10:35 PM ******/
CREATE DATABASE [PandaShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECommerceDB', FILENAME = N'E:\Study_and_work\hk1_nam4\Hk1_nam_4\PT&TKHT\Project\DB\\PandaShopDB.mdf' , SIZE = 3264KB , MAXSIZE = 30720KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ECommerceDB_log', FILENAME = N'E:\Study_and_work\hk1_nam4\Hk1_nam_4\PT&TKHT\Project\DB\\PandaShopDB.ldf' , SIZE = 832KB , MAXSIZE = 30720KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PandaShopDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PandaShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PandaShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PandaShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PandaShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PandaShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PandaShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PandaShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PandaShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PandaShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PandaShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PandaShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PandaShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PandaShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PandaShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PandaShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PandaShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PandaShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PandaShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PandaShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PandaShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PandaShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PandaShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PandaShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PandaShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PandaShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [PandaShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PandaShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PandaShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PandaShopDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PandaShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PandaShopDB', N'ON'
GO
USE [PandaShopDB]
GO
/****** Object:  User [IIS APPPOOL\PandaShopAPI]    Script Date: 6/4/2023 4:10:36 PM ******/
CREATE USER [IIS APPPOOL\PandaShopAPI] FOR LOGIN [IIS APPPOOL\PandaShopAPI] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\PandaShopAPI]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\PandaShopAPI]
GO
/****** Object:  Schema [pandahacker_SQLLogin_1]    Script Date: 6/4/2023 4:10:36 PM ******/
CREATE SCHEMA [pandahacker_SQLLogin_1]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provinceOrCity] [nvarchar](50) NOT NULL,
	[provinceOrCityCode] [varchar](5) NOT NULL,
	[district] [nvarchar](50) NOT NULL,
	[districtCode] [varchar](5) NOT NULL,
	[communeOrWard] [nvarchar](50) NOT NULL,
	[streetAndHouseNum] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productNum] [int] NOT NULL,
	[cartId] [int] NOT NULL,
	[productId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parentId] [int] NULL,
	[name] [nvarchar](50) NOT NULL,
	[level] [int] NOT NULL DEFAULT ((1)),
	[imageId] [int] NULL,
	[templateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Delivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[startedAt] [datetime] NULL,
	[finishedAt] [datetime] NULL,
	[state] [varchar](10) NOT NULL,
	[deliveryMethodId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryMethod]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deliveryPartnerId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[pricePerKm] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryPartner]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryPartner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](500) NULL,
	[starNum] [float] NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[parentId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[productId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](100) NULL,
	[fileName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NULL,
	[note] [nvarchar](200) NULL,
	[orderId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[note] [nvarchar](200) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[addressId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[deliveryId] [int] NOT NULL,
	[paymentMethodId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NULL,
	[discountPercent] [float] NULL,
	[price] [money] NOT NULL,
	[productNum] [int] NOT NULL,
	[orderId] [int] NOT NULL,
	[productOptionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[resourceId] [int] NOT NULL,
	[canRead] [bit] NOT NULL,
	[canWrite] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[starNum] [float] NOT NULL DEFAULT ((0)),
	[description] [nvarchar](500) NOT NULL,
	[sellingNum] [int] NOT NULL DEFAULT ((0)),
	[remainingNum] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
	[shopId] [int] NOT NULL,
	[addressId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[imageId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductOption]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOption](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [money] NOT NULL,
	[name] [nvarchar](50) NULL,
	[productId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductOptionImage]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOptionImage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productOptionId] [int] NOT NULL,
	[imageId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductOptionValue]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOptionValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productOptionId] [int] NOT NULL,
	[propertyId] [int] NOT NULL,
	[value] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductPropertyValue]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPropertyValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](500) NOT NULL,
	[productId] [int] NOT NULL,
	[propertyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Property]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[secondaryId] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyTemplate]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTemplate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[templateId] [int] NOT NULL,
	[propertyId] [int] NOT NULL,
	[isRequired] [bit] NULL DEFAULT ((1)),
	[orderIndex] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTemplateValue]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTemplateValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[propertyTemplateId] [int] NOT NULL,
	[value] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resource]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shop]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Template]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [varchar](15) NOT NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](500) NOT NULL,
	[createdAt] [datetime] NULL DEFAULT (getdate()),
	[updatedAt] [datetime] NULL DEFAULT (getdate()),
	[cartId] [int] NOT NULL,
	[shopId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 6/4/2023 4:10:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [provinceOrCity], [provinceOrCityCode], [district], [districtCode], [communeOrWard], [streetAndHouseNum]) VALUES (5, N'Cần Thơ', N'92', N'Ninh Kiều', N'916', N'Cái Khế', N'ABC')
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([id]) VALUES (1)
INSERT [dbo].[Cart] ([id]) VALUES (2)
INSERT [dbo].[Cart] ([id]) VALUES (3)
SET IDENTITY_INSERT [dbo].[Cart] OFF
SET IDENTITY_INSERT [dbo].[CartDetail] ON 

INSERT [dbo].[CartDetail] ([id], [productNum], [cartId], [productId]) VALUES (5, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[CartDetail] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (2, NULL, N'Thời trang nữ', 1, 12, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (3, NULL, N'Thời trang nam', 1, 13, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (4, 3, N'Áo thun nam', 2, NULL, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (5, 3, N'Áo khoác nam', 2, NULL, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (6, 2, N'Đầm, váy', 2, NULL, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (7, 2, N'Đồ lót nữ', 2, NULL, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (8, 4, N'Áo thun ngắn tay', 3, 16, 4)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (9, 4, N'Áo thun dài tay', 3, 17, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (10, NULL, N'Thiết bị điện tử', 1, 15, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (12, 10, N'Smartphone', 2, NULL, 2)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (13, 10, N'Laptop', 2, NULL, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (14, 12, N'IPhone', 3, 18, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (15, 12, N'Samsung', 3, 19, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (16, 13, N'Dell', 3, 20, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (17, 13, N'Asus', 3, 21, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (18, NULL, N'Đồ gia dụng', 1, 14, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (19, 18, N'Xoong nồi', 2, 6, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (20, 18, N'Chảo', 2, 5, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (21, 12, N'Huawei', 3, 22, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (22, 12, N'Oppo', 3, 23, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (23, 12, N'Sony', 3, 24, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (24, 6, N'Váy trắng tay nơ', 3, 25, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (25, 3, N'Quần tây', 2, 3029, NULL)
INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (27, 3, N'Áo sơ mi', 2, 3031, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (5, NULL, N'4c9c3141-e27e-4758-b80a-ef3ee1eb3287.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (6, NULL, N'fac58171-42d9-48d6-8915-5c2e6513f45d.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (12, NULL, N'3916f275-4ea3-4805-b0f3-1a4aba7469ed.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (13, NULL, N'c805713a-02b8-4ef0-8f6c-c06240a1bc6d.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (14, NULL, N'6ab8c903-fbe2-4d1e-9dfd-a2dbae47e081.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (15, NULL, N'b56c401c-f590-4107-a418-3a696b423ec7.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (16, NULL, N'58b326a4-23ca-4b92-b83f-1ffae14f2f22.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (17, NULL, N'08dcfdd3-5687-4458-95ba-1235869b3c42.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (18, NULL, N'c9bcbd82-2764-48de-b373-73d1386c74f0.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (19, NULL, N'7d30139e-b27e-4f13-b800-8766a6ec1274.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (20, NULL, N'abf73b14-2205-48ea-886a-858292e64f6c.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (21, NULL, N'44a7fb51-07cd-48c9-bd73-7e36666e9ac6.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (22, NULL, N'3b075693-03d9-4d5d-98cd-d3e3adc59b44.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (23, NULL, N'85b9a5ff-f144-4249-b3c6-9ddab1d35b32.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (24, NULL, N'671af3b1-31a7-43cd-b37f-e0de94a49f44.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (25, NULL, N'49e93330-cca6-49a8-ad84-e38dc616dd9a.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (26, NULL, N'057f8f8c-6334-480c-a126-53c92b1d4895.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (27, NULL, N'b167e903-e418-4e20-a8ac-6641700c725c.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (28, NULL, N'b1612f41-287b-4eac-b878-28752c5676fb.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (29, NULL, N'27a327e3-afa1-442b-a877-3c6361d533fc.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (1028, NULL, N'37f4ea01-4fec-4e7d-a4fc-0eb90501ec7d.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2028, NULL, N'9e697748-1bcb-4a63-8719-7fd41295f99a.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2029, NULL, N'1766ca6a-572a-490f-9fee-b2a45307bcb3.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2030, NULL, N'cfed44b4-8337-4e6f-a176-be2bd937ea44.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2031, NULL, N'fd047561-986e-4fe9-91e8-7dbaedaa477f.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3028, NULL, N'c82d6982-a116-412b-bf27-f0922d62b65b.png')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3029, NULL, N'0245fb92-fc2c-4947-b4e9-9eb023d8e6a3.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3030, NULL, N'2c50399a-f58d-4958-b6c5-aaae44c1fcba.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3031, NULL, N'f197088b-e5a5-47bf-902a-05d78dd108fb.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3032, NULL, N'5cba8dd7-8e4f-42fe-8162-02827916b6d1.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3033, NULL, N'1dffe229-e037-4245-918d-f1f81d470963.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3034, NULL, N'3557515c-8263-42c1-80a6-a7924d1f3828.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3035, NULL, N'f17caa80-cbab-4146-8343-2400a4961cf8.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3036, NULL, N'7cdf416e-d3b0-433e-ac3c-1a9ad93c4603.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3037, NULL, N'd1aa61a7-0c2b-4501-bf90-a43872dd10b8.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3038, NULL, N'158b7d0a-420e-4bf6-a870-62c5f07c91a3.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3039, NULL, N'74b49992-de7a-400b-922e-58052284d294.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3040, NULL, N'73e8c6d8-0dbe-4892-840d-ddd96a8260b0.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3041, NULL, N'f2ad1e5e-8ea0-4079-830c-d5af11f92f67.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3042, NULL, N'2064285a-32fa-4b9b-b172-9329d2342f52.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3043, NULL, N'55b3d79b-47e3-43b4-9f05-bf5efbd1513e.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3044, NULL, N'060fb3f3-d247-43ff-8eb5-75a9ebc8a702.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3045, NULL, N'79de2185-ca12-4ac1-ba3a-61eeb7476258.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3046, NULL, N'3686ef1c-ba0b-4cab-b91e-907c041810da.jpeg')
INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3047, NULL, N'9501ad7d-fe4f-405e-9121-3988303ebacf.jpeg')
SET IDENTITY_INSERT [dbo].[Image] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (1, N'SamSung TrungDZ', 0, N'SamSung galaxy TrungDZ', 100, 5, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2, N'SamSung galaxy abc', 0, N'Smartphone', 10, 4, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (3, N'SamSung galaxy a1', 0, N'Smartphone', 10, 5, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (4, N'Samsung Galaxy Note 20', 0, N'No way', 100, 3, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (1004, N'Samsung Galaxy Note 10', 0, N'No way', 100, 2, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (1005, N'Samsung Galaxy S20', 0, N'No way', 100, 2, 15, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2006, N'IPhone 8 Plus', 0, N'string', 15, 10, 14, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2013, N'Áo thun nam đẹp, Hero', 0, N'Chất liệu áo là cotton pha, co giãn 4 chiều, áo mịn đẹp, mặc mát, không xù lông. Sản phẩm được in bằng công nghệ in chuyển nhiệt hiện đại, đảm bảo màu sắc tươi sáng, bắt mắt và bền đẹp với thời gian. Hãy đến với Xưởng In Áo Nhóm để được phục vụ tận tình và có những trải nghiệm mua sắm tốt nhất. ', 50, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2014, N'Áo thun nam PN1074', 0, N'Chất liệu thun mềm mại co giãn tốt , thoáng mát. Form rộng Nam nữ trẻ em đều mặc được. Đường may tinh tế sắc sảo.', 20, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2015, N'Áo thun nam ATND506', 0, N'Chất liệu thun mềm mại co giãn tốt , thoáng mát. Form rộng Nam nữ trẻ em đều mặc được. Đường may tinh tế sắc sảo.', 20, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2016, N'Áo thun nam Youtube', 0, N'Chất liệu thun mềm mại co giãn tốt , thoáng mát. Form rộng Nam nữ trẻ em đều mặc được. Đường may tinh tế sắc sảo.', 20, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2017, N'Áo thun nam PM1367', 0, N'Chất liệu thun mềm mại co giãn tốt , thoáng mát. Form rộng Nam nữ trẻ em đều mặc được. Đường may tinh tế sắc sảo.', 20, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2018, N'Áo thun nam in hình độc cực đẹp', 0, N'Chất liệu thun mềm mại co giãn tốt , thoáng mát. Form rộng Nam nữ trẻ em đều mặc được. Đường may tinh tế sắc sảo.', 20, 10, 8, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2019, N'Váy công sở cột nơ ', 0, N'Sét áo dài tay  chân váy bút chì sang chảnh, Chất liệu thun gân co giãn siêu cấp dày dặn ôm sát tôn đường cong 3 vòng gợi cảm', 20, 10, 24, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2020, N'Váy Đen Ôm Phối', 0, N'Sét áo dài tay  chân váy bút chì sang chảnh, Chất liệu thun gân co giãn siêu cấp dày dặn ôm sát tôn đường cong 3 vòng gợi cảm', 20, 10, 24, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2021, N'Váy đen cổ vuông tay trắng nơ', 0, N'Sét áo dài tay  chân váy bút chì sang chảnh, Chất liệu thun gân co giãn siêu cấp dày dặn ôm sát tôn đường cong 3 vòng gợi cảm', 20, 10, 24, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2022, N'Váy trắng nơ cổ tay', 0, N'Sét áo dài tay  chân váy bút chì sang chảnh, Chất liệu thun gân co giãn siêu cấp dày dặn ôm sát tôn đường cong 3 vòng gợi cảm', 20, 10, 24, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2023, N'Laptop HP Probook 4540s Core i5 3210 4G ', 0, N'Bộ Xử Lý CPU: Intel Core I5 3210M 2.5GHz, Bộ nhớ đệm 3MB Cache
• Bộ nhớ RAM: 4GB - DDR3
• Đĩa Cứng HDD: 320GB
• VGA: Intel® HD Graphics 4000
• Màn Hình: 15.6" Anti-Glare, Độ phân giải HD 1366x768
• Đĩa Quang: DVD+/-RW SuperMulti with Double Layer
• Pin/Battery: ~ 2h
• Kích Thước và Trọng Lượng: 2.5kg
• Tình trạng hàng hóa: Laptop xách tay Nhật', 20, 10, 17, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2024, N'Laptop Dell Latitude. E6510 Core i5', 0, N'Bộ Xử Lý CPU: Intel Core I5 3210M 2.5GHz, Bộ nhớ đệm 3MB Cache
• Bộ nhớ RAM: 4GB - DDR3
• Đĩa Cứng HDD: 320GB
• VGA: Intel® HD Graphics 4000
• Màn Hình: 15.6" Anti-Glare, Độ phân giải HD 1366x768
• Đĩa Quang: DVD+/-RW SuperMulti with Double Layer
• Pin/Battery: ~ 2h
• Kích Thước và Trọng Lượng: 2.5kg
• Tình trạng hàng hóa: Laptop xách tay Nhật', 20, 0, 17, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2025, N'Laptop siêu mỏng 14inch IPS 1080p Intel', 0, N'Bộ Xử Lý CPU: Intel Core I5 3210M 2.5GHz, Bộ nhớ đệm 3MB Cache
• Bộ nhớ RAM: 4GB - DDR3
• Đĩa Cứng HDD: 320GB
• VGA: Intel® HD Graphics 4000
• Màn Hình: 15.6" Anti-Glare, Độ phân giải HD 1366x768
• Đĩa Quang: DVD+/-RW SuperMulti with Double Layer
• Pin/Battery: ~ 2h
• Kích Thước và Trọng Lượng: 2.5kg
• Tình trạng hàng hóa: Laptop xách tay Nhật', 20, 0, 17, 1, 5)
INSERT [dbo].[Product] ([id], [name], [starNum], [description], [sellingNum], [remainingNum], [categoryId], [shopId], [addressId]) VALUES (2026, N'Laptop HP Probook 4540s Core i5', 0, N'Bộ Xử Lý CPU: Intel Core I5 3210M 2.5GHz, Bộ nhớ đệm 3MB Cache
• Bộ nhớ RAM: 4GB - DDR3
• Đĩa Cứng HDD: 320GB
• VGA: Intel® HD Graphics 4000
• Màn Hình: 15.6" Anti-Glare, Độ phân giải HD 1366x768
• Đĩa Quang: DVD+/-RW SuperMulti with Double Layer
• Pin/Battery: ~ 2h
• Kích Thước và Trọng Lượng: 2.5kg
• Tình trạng hàng hóa: Laptop xách tay Nhật', 20, 0, 17, 1, 5)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductImage] ON 

INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (1, 1, 26)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (2, 1, 27)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3, 2, 28)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (4, 3, 29)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (1003, 4, 1028)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (2005, 1004, 2030)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (2006, 1005, 2031)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3003, 1, 3028)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3005, 2006, 3033)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3006, 2013, 3034)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3007, 2014, 3035)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3008, 2015, 3036)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3009, 2016, 3037)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3010, 2017, 3038)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3011, 2018, 3039)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3012, 2019, 3040)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3013, 2020, 3041)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3014, 2021, 3042)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3015, 2022, 3043)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3016, 2023, 3044)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3017, 2024, 3045)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3018, 2025, 3046)
INSERT [dbo].[ProductImage] ([id], [productId], [imageId]) VALUES (3019, 2026, 3047)
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
SET IDENTITY_INSERT [dbo].[ProductOption] ON 

INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2, 20000000.0000, NULL, 2)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (3, 30000000.0000, NULL, 3)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (4, 200000000.0000, N'16gb', 4)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (1004, 200000000.0000, N'16gb', 1004)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (1005, 200000000.0000, N'16gb', 1005)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2005, 0.0000, N'64gb', 2006)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2011, 35000.0000, N'Option 1', 2013)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2012, 25000.0000, N'Option 1', 2014)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2013, 25000.0000, N'Option 1', 2015)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2014, 25000.0000, N'Option 1', 2016)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2015, 25000.0000, N'Option 1', 2017)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2016, 25000.0000, N'Option 1', 2018)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2017, 25000.0000, N'Option 1', 2019)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2018, 599000.0000, N'Option 1', 2020)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2019, 170000.0000, N'Option 1', 2021)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2020, 650000.0000, N'Option 1', 2022)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2021, 5500000.0000, N'Option 1', 2023)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2022, 3194000.0000, N'Option 1', 2024)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2023, 5980000.0000, N'Option 1', 2025)
INSERT [dbo].[ProductOption] ([id], [price], [name], [productId]) VALUES (2024, 6780000.0000, N'Option 1', 2026)
SET IDENTITY_INSERT [dbo].[ProductOption] OFF
SET IDENTITY_INSERT [dbo].[ProductOptionValue] ON 

INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (1, 2, 3, N'8gb')
INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (2, 3, 3, N'32gb')
INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (3, 4, 3, N'16gb')
INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (1003, 1004, 3, N'16gb')
INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (1004, 1005, 3, N'16gb')
INSERT [dbo].[ProductOptionValue] ([id], [productOptionId], [propertyId], [value]) VALUES (2004, 2005, 3, N'64gb')
SET IDENTITY_INSERT [dbo].[ProductOptionValue] OFF
SET IDENTITY_INSERT [dbo].[ProductPropertyValue] ON 

INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (1, N'4gb', 1, 3)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (3, N'16gb', 2, 4)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (4, N'128gb', 3, 4)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (5, N'64gb', 4, 4)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (1005, N'64gb', 1004, 4)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (1006, N'64gb', 1005, 4)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2006, N'Cotton thun', 2013, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2007, N'Qua rốn', 2013, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2008, N'Hoạt hình', 2013, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2009, N'Tròn', 2013, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2010, N'Cotton pha', 2014, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2011, N'Qua rốn', 2014, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2012, N'Hoạt tiết lạ', 2014, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2013, N'Tròn', 2014, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2014, N'Cotton pha', 2015, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2015, N'Qua rốn', 2015, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2016, N'Hoạt tiết lạ', 2015, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2017, N'Tròn', 2015, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2018, N'Cotton pha', 2016, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2019, N'Qua rốn', 2016, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2020, N'Hoạt tiết lạ', 2016, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2021, N'Tròn', 2016, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2022, N'Cotton pha', 2017, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2023, N'Qua rốn', 2017, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2024, N'Hoạt tiết lạ', 2017, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2025, N'Tròn', 2017, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2026, N'Cotton pha', 2018, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2027, N'Qua rốn', 2018, 8)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2028, N'Hoạt tiết lạ', 2018, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2029, N'Tròn', 2018, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2030, N'Cotton pha', 2019, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2031, N'Trơn', 2019, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2032, N'Tròn', 2019, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2033, N'Ôm', 2019, 11)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2034, N'Cotton pha', 2020, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2035, N'Trơn', 2020, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2036, N'Tròn', 2020, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2037, N'Ôm', 2020, 11)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2038, N'Cotton pha', 2021, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2039, N'Trơn', 2021, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2040, N'Tròn', 2021, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2041, N'Ôm', 2021, 11)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2042, N'Cotton pha', 2022, 7)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2043, N'Trơn', 2022, 9)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2044, N'Tròn', 2022, 10)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2045, N'Ôm', 2022, 11)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2046, N'HP', 2023, 12)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2047, N'Windows 10', 2023, 13)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2048, N'Từ 15'' - 16''', 2023, 14)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2049, N'SSD', 2023, 15)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2050, N'4GB', 2023, 3)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2051, N'Core i5', 2023, 16)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2052, N'HP', 2024, 12)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2053, N'Windows 10', 2024, 13)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2054, N'Từ 15'' - 16''', 2024, 14)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2055, N'SSD', 2024, 15)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2056, N'4GB', 2024, 3)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2057, N'Core i5', 2024, 16)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2058, N'HP', 2025, 12)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2059, N'Windows 10', 2025, 13)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2060, N'Từ 15'' - 16''', 2025, 14)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2061, N'SSD', 2025, 15)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2062, N'4GB', 2025, 3)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2063, N'Core i5', 2025, 16)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2064, N'HP', 2026, 12)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2065, N'Windows 10', 2026, 13)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2066, N'Từ 15'' - 16''', 2026, 14)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2067, N'SSD', 2026, 15)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2068, N'4GB', 2026, 3)
INSERT [dbo].[ProductPropertyValue] ([id], [value], [productId], [propertyId]) VALUES (2069, N'Core i5', 2026, 16)
SET IDENTITY_INSERT [dbo].[ProductPropertyValue] OFF
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (3, N'RAM', N'3')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (4, N'Bộ nhớ trong', N'4')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (5, N'Màu sắc', N'color')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (6, N'Độ phân giải', N'resoulution')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (7, N'Chất vải', N'chatvai')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (8, N'Chiều dài áo', N'chieudaiao')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (9, N'Họa tiết', N'hoatiet')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (10, N'Kiểu cổ áo', N'kieucoao')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (11, N'Dạng váy', N'dangvay')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (12, N'Hãng sản xuất', N'hangsanxuat')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (13, N'Hệ điều hành', N'hedieuhanh')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (14, N'Kích thước màn hình', N'ktmh')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (15, N'Loại ổ cứng', N'loc')
INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (16, N'Vi xử lý', N'vsl')
SET IDENTITY_INSERT [dbo].[Property] OFF
SET IDENTITY_INSERT [dbo].[PropertyTemplate] ON 

INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (5, 2, 3, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (6, 3, 7, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (7, 3, 8, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (8, 3, 9, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (9, 3, 10, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (10, 4, 7, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (11, 4, 8, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (12, 4, 9, 1, 0)
INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (13, 4, 10, 1, 0)
SET IDENTITY_INSERT [dbo].[PropertyTemplate] OFF
SET IDENTITY_INSERT [dbo].[PropertyTemplateValue] ON 

INSERT [dbo].[PropertyTemplateValue] ([id], [propertyTemplateId], [value]) VALUES (9, 5, N'2gb')
INSERT [dbo].[PropertyTemplateValue] ([id], [propertyTemplateId], [value]) VALUES (10, 5, N'4gb')
INSERT [dbo].[PropertyTemplateValue] ([id], [propertyTemplateId], [value]) VALUES (11, 5, N'8gb')
SET IDENTITY_INSERT [dbo].[PropertyTemplateValue] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'user')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'shop')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Shop] ON 

INSERT [dbo].[Shop] ([id], [name]) VALUES (1, N'PandaShop')
SET IDENTITY_INSERT [dbo].[Shop] OFF
SET IDENTITY_INSERT [dbo].[Template] ON 

INSERT [dbo].[Template] ([id]) VALUES (1)
INSERT [dbo].[Template] ([id]) VALUES (2)
INSERT [dbo].[Template] ([id]) VALUES (3)
INSERT [dbo].[Template] ([id]) VALUES (4)
SET IDENTITY_INSERT [dbo].[Template] OFF
SET IDENTITY_INSERT [dbo].[User_] ON 

INSERT [dbo].[User_] ([id], [name], [phone], [email], [password], [createdAt], [updatedAt], [cartId], [shopId]) VALUES (5, N'Đoàn Thanh Trung', N'0988202071', N'doanthanhtrung@gmail.com', N'123', CAST(N'2020-09-04 21:44:37.410' AS DateTime), CAST(N'2020-09-04 21:44:37.410' AS DateTime), 2, 1)
INSERT [dbo].[User_] ([id], [name], [phone], [email], [password], [createdAt], [updatedAt], [cartId], [shopId]) VALUES (6, N'Duy', N'0918820834', N'Duy@gmail.com', N'0123123', CAST(N'2020-09-12 06:07:36.680' AS DateTime), CAST(N'2020-09-12 06:07:36.680' AS DateTime), 3, NULL)
SET IDENTITY_INSERT [dbo].[User_] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([id], [userId], [roleId]) VALUES (1, 5, 1)
INSERT [dbo].[UserRole] ([id], [userId], [roleId]) VALUES (2, 5, 2)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Property__2D08ACCF5EA3BA00]    Script Date: 6/4/2023 4:10:36 PM ******/
ALTER TABLE [dbo].[Property] ADD UNIQUE NONCLUSTERED 
(
	[secondaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Property__2D08ACCF6D2F21AB]    Script Date: 6/4/2023 4:10:36 PM ******/
ALTER TABLE [dbo].[Property] ADD UNIQUE NONCLUSTERED 
(
	[secondaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT ((0)) FOR [starNum]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Order_] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [discountPercent]
GO
ALTER TABLE [dbo].[Permission] ADD  DEFAULT ((1)) FOR [canRead]
GO
ALTER TABLE [dbo].[Permission] ADD  DEFAULT ((0)) FOR [canWrite]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Cart] FOREIGN KEY([cartId])
REFERENCES [dbo].[Cart] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Cart]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Product]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([parentId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Image]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Template] FOREIGN KEY([templateId])
REFERENCES [dbo].[Template] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Template]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_DeliveryPartner] FOREIGN KEY([deliveryMethodId])
REFERENCES [dbo].[DeliveryMethod] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_DeliveryPartner]
GO
ALTER TABLE [dbo].[DeliveryMethod]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryMethod_DeliveryPartner] FOREIGN KEY([deliveryPartnerId])
REFERENCES [dbo].[DeliveryPartner] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliveryMethod] CHECK CONSTRAINT [FK_DeliveryMethod_DeliveryPartner]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Feedback] FOREIGN KEY([parentId])
REFERENCES [dbo].[Feedback] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Feedback]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Product]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User_] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order_] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Order]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_Address] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_Address]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_Delivery] FOREIGN KEY([deliveryId])
REFERENCES [dbo].[Delivery] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_Delivery]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_PaymentMethod] FOREIGN KEY([paymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_PaymentMethod]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User_] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order_] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_ProductOption] FOREIGN KEY([productOptionId])
REFERENCES [dbo].[ProductOption] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_ProductOption]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Resource] FOREIGN KEY([resourceId])
REFERENCES [dbo].[Resource] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Resource]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Address] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Address]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Shop] FOREIGN KEY([shopId])
REFERENCES [dbo].[Shop] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Shop]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Image] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Image]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[ProductOption]  WITH CHECK ADD  CONSTRAINT [FK_ProductOption_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOption] CHECK CONSTRAINT [FK_ProductOption_Product]
GO
ALTER TABLE [dbo].[ProductOptionImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductOptionImage_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Image] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOptionImage] CHECK CONSTRAINT [FK_ProductOptionImage_Image]
GO
ALTER TABLE [dbo].[ProductOptionImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductOptionImage_ProductOption] FOREIGN KEY([productOptionId])
REFERENCES [dbo].[ProductOption] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOptionImage] CHECK CONSTRAINT [FK_ProductOptionImage_ProductOption]
GO
ALTER TABLE [dbo].[ProductOptionValue]  WITH CHECK ADD  CONSTRAINT [FK_ProductOptionValue_ProductOption] FOREIGN KEY([productOptionId])
REFERENCES [dbo].[ProductOption] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOptionValue] CHECK CONSTRAINT [FK_ProductOptionValue_ProductOption]
GO
ALTER TABLE [dbo].[ProductOptionValue]  WITH CHECK ADD  CONSTRAINT [FK_ProductOptionValue_Property] FOREIGN KEY([propertyId])
REFERENCES [dbo].[Property] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOptionValue] CHECK CONSTRAINT [FK_ProductOptionValue_Property]
GO
ALTER TABLE [dbo].[ProductPropertyValue]  WITH CHECK ADD  CONSTRAINT [FK_ProductPropertyValue_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPropertyValue] CHECK CONSTRAINT [FK_ProductPropertyValue_Product]
GO
ALTER TABLE [dbo].[ProductPropertyValue]  WITH CHECK ADD  CONSTRAINT [FK_ProductPropertyValue_Property] FOREIGN KEY([propertyId])
REFERENCES [dbo].[Property] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPropertyValue] CHECK CONSTRAINT [FK_ProductPropertyValue_Property]
GO
ALTER TABLE [dbo].[PropertyTemplate]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTemplate_Property] FOREIGN KEY([propertyId])
REFERENCES [dbo].[Property] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyTemplate] CHECK CONSTRAINT [FK_PropertyTemplate_Property]
GO
ALTER TABLE [dbo].[PropertyTemplate]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTemplate_Template] FOREIGN KEY([templateId])
REFERENCES [dbo].[Template] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyTemplate] CHECK CONSTRAINT [FK_PropertyTemplate_Template]
GO
ALTER TABLE [dbo].[PropertyTemplateValue]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTemplateValue_PropertyTemplate] FOREIGN KEY([propertyTemplateId])
REFERENCES [dbo].[PropertyTemplate] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyTemplateValue] CHECK CONSTRAINT [FK_PropertyTemplateValue_PropertyTemplate]
GO
ALTER TABLE [dbo].[User_]  WITH CHECK ADD  CONSTRAINT [FK_User_Cart] FOREIGN KEY([cartId])
REFERENCES [dbo].[Cart] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_] CHECK CONSTRAINT [FK_User_Cart]
GO
ALTER TABLE [dbo].[User_]  WITH CHECK ADD  CONSTRAINT [FK_User_Shop] FOREIGN KEY([shopId])
REFERENCES [dbo].[Shop] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_] CHECK CONSTRAINT [FK_User_Shop]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User_] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD CHECK  (([productNum]>(0)))
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD CHECK  (([productNum]>(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([remainingNum]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([remainingNum]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([sellingNum]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([sellingNum]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([starNum]>=(0) AND [starNum]<=(5)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([starNum]>=(0) AND [starNum]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [PandaShopDB] SET  READ_WRITE 
GO
