USE [ShopBridge]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 5/17/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](200) NOT NULL,
	[ProductCode] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[UnitOfMeasureId] [bigint] NOT NULL,
	[DefaultBuyingPrice] [bigint] NOT NULL,
	[DefaultSellingPrice] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 5/17/2021 11:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([ProductId], [ProductName], [ProductCode], [Description], [UnitOfMeasureId], [DefaultBuyingPrice], [DefaultSellingPrice]) VALUES (1, N'Rice1', N'SMRICE', N'Sona Masoori Long grain', 1, 35, 50)
INSERT [dbo].[Inventory] ([ProductId], [ProductName], [ProductCode], [Description], [UnitOfMeasureId], [DefaultBuyingPrice], [DefaultSellingPrice]) VALUES (3, N'Sugar', N'SR', N'Regular Sugar', 1, 50, 60)
INSERT [dbo].[Inventory] ([ProductId], [ProductName], [ProductCode], [Description], [UnitOfMeasureId], [DefaultBuyingPrice], [DefaultSellingPrice]) VALUES (4, N'Apple', N'FR', N'Washington Apple', 1, 150, 180)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserId], [FirstName], [LastName], [UserName], [Email], [Password], [CreatedDate]) VALUES (1, N'Inventory', N'Admin', N'InventoryAdmin', N'InventoryAdmin@abc.com', N'$admin@2021', CAST(N'2021-05-16T17:30:17.920' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
ALTER TABLE [dbo].[UserInfo] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
