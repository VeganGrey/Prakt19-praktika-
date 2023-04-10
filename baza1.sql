USE [Detdom]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.04.2023 23:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toy]    Script Date: 10.04.2023 23:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Kol] [int] NULL,
	[AgeCategory] [int] NOT NULL,
	[FactoryName] [nvarchar](50) NOT NULL,
	[CityFactory] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Toy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.04.2023 23:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserSurname] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPatronymic] [nvarchar](50) NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Пользователь')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Модератор')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (4, N'Клиент')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Toy] ON 

INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (3, N'Настольная игра "Доктор"', 400, 10, 10, N'ИП "Инсульт"', N'Казань')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (5, N'Пистолет игрушечный', 2500, 10, 10, N'ООО "Ампир"', N'Казань')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (6, N'Конструктор "Машина"', 659, 10, 8, N'ООО "Питер-Эго"', N'Санкт-Петербург')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (7, N'Конструктор "Кран"', 579, 10, 12, N'ООО "Питер-Эго"', N'Санкт-Петербург')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (8, N'Конструктор "Самосвал"', 1200, 10, 12, N'ООО "Питер-Эго"', N'Санкт-Петербург')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (9, N'Савок пластмассовый', 179, 10, 3, N'ООО "Эко-Пласт"', N'Ниж.Новгород')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (10, N'Лопатка пластмассовая', 179, 10, 3, N'ООО "Эко-Пласт"', N'Ниж.Новгород')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (12, N'Пазл "Поезд"', 239, 10, 7, N'ООО "Азбука"', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (13, N'Пазл "Танк"', 239, 10, 7, N'ООО "Азбука"', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (15, N'Набор глаз для кукол', 240, 10, 4, N'ОАО "Катаракта"', N'Краснодар')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (19, N'Плюшевый медведь', 249, 10, 4, N'ООО "Мех-Завод"', N'Татарстан')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (20, N'Плюшевый заяц', 219, 10, 4, N'ООО "Мех-Завод"', N'Татарстан')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Kol], [AgeCategory], [FactoryName], [CityFactory]) VALUES (21, N'Конструктор Лего', 1999, 10, 12, N'ОАО "Лего"', N'Москва')
SET IDENTITY_INSERT [dbo].[Toy] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'Васильевич', N'Иван', N'Васильевич', N'Vasya', N'12345', 1)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (2, N'Потапович', N'Андрей', N'Александрович', N'Dushes', N'dushes_32f', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (3, N'Алебардов', N'Сергей', N'Васильевич', N'Alebarda', N'1996_Alebarda', 3)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (5, N'Потапов', N'Юрий', N'Валентинович', N'Potp', N'Potapchik_123', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (7, N'Иванов', N'Инокентий', N'Иванович', N'Ivan', N'837432vsd', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (8, N'Касимов', N'Антон', N'Изральевич', N'Izrael_CS', N'j398hf_32', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (9, N'Вульфрик', N'Антон', N'Павлович', N'Wolf_At', N'j32_fwe', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (10, N'Казань', N'Павел', N'Антонович', N'NoteDed', N'473jfdeb', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (11, N'Смоленк', N'Сергей', N'Юрьевич', N'UraSmall', N'23842fgw2', 1)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (12, N'Пушка', N'Александр', N'Александрович', N'CanonA', N'C44Non', 3)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (13, N'Самолетик', N'Арестарх', N'Сергеевич', N'Airplane_2', N'fnio3_3jf', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (14, N'Кулек', N'Петр', N'Андреевич', N'Paket_Haha', N'jdj3_4df', 2)
INSERT [dbo].[User] ([UserId], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (15, N'Стародубцев', N'Слава', N'Анатольевич', N'Wise_treee', N'2kfn4_4mfd', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
