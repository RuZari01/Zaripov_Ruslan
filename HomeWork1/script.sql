USE [TestMagazine]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientSale]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientSale](
	[ClientID] [int] NOT NULL,
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ClientSale] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleTovar]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleTovar](
	[SaleID] [int] NOT NULL,
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SaleTovar] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC,
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tovar]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tovar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[KolVo] [int] NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Tovar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28.04.2021 13:01:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tovar] ON 

INSERT [dbo].[Tovar] ([id], [Name], [KolVo], [Price]) VALUES (1, N'Tea', 30, 13.3700)
INSERT [dbo].[Tovar] ([id], [Name], [KolVo], [Price]) VALUES (2, N'Choocolate', 50, 420.6900)
INSERT [dbo].[Tovar] ([id], [Name], [KolVo], [Price]) VALUES (3, N'Apple', 45, 14.8800)
SET IDENTITY_INSERT [dbo].[Tovar] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (1, N'Генадий', N'Горин', N'gena1', N'ggena')
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (2, N'Екатерина', N'Татина', N'katya1', N'kkatay')
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Login], [Password]) VALUES (3, N'Дмитрий', N'Нагорний', N'dima1', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[ClientSale]  WITH CHECK ADD  CONSTRAINT [FK_ClientSale_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[ClientSale] CHECK CONSTRAINT [FK_ClientSale_Client]
GO
ALTER TABLE [dbo].[ClientSale]  WITH CHECK ADD  CONSTRAINT [FK_ClientSale_Sale] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Sale] ([id])
GO
ALTER TABLE [dbo].[ClientSale] CHECK CONSTRAINT [FK_ClientSale_Sale]
GO
ALTER TABLE [dbo].[SaleTovar]  WITH CHECK ADD  CONSTRAINT [FK_SaleTovar_Sale] FOREIGN KEY([SaleID])
REFERENCES [dbo].[Sale] ([id])
GO
ALTER TABLE [dbo].[SaleTovar] CHECK CONSTRAINT [FK_SaleTovar_Sale]
GO
ALTER TABLE [dbo].[SaleTovar]  WITH CHECK ADD  CONSTRAINT [FK_SaleTovar_Tovar] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Tovar] ([id])
GO
ALTER TABLE [dbo].[SaleTovar] CHECK CONSTRAINT [FK_SaleTovar_Tovar]
GO
