USE [master]
GO
/****** Object:  Database [peips_dk_db]    Script Date: 19-05-2014 12:48:06 ******/
/* NOTE: peips_dk_db must be created manually! */
USE peips_dk_db
GO
ALTER DATABASE [peips_dk_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [peips_dk_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [peips_dk_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [peips_dk_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [peips_dk_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [peips_dk_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [peips_dk_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [peips_dk_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [peips_dk_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [peips_dk_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [peips_dk_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [peips_dk_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [peips_dk_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [peips_dk_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [peips_dk_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [peips_dk_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [peips_dk_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [peips_dk_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [peips_dk_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [peips_dk_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [peips_dk_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [peips_dk_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [peips_dk_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [peips_dk_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [peips_dk_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [peips_dk_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [peips_dk_db] SET  MULTI_USER 
GO
ALTER DATABASE [peips_dk_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [peips_dk_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [peips_dk_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [peips_dk_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [peips_dk_db]
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCustomer]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(100),
	@Note nvarchar(2000),
	@Type nvarchar(50),
	@Deleted bit,
	@Id int out,
	@LastModified datetime out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	INSERT INTO peips_dk_db.dbo.Party
		(Name, Note, LastModified, Deleted)
	VALUES
		(@Name, @Note, @LastModified, @Deleted)

	SET @Id = @@IDENTITY

	INSERT INTO peips_dk_db.dbo.Customer
		(Type, PartyId)
	VALUES
		(@Type, @Id)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertPayment]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPayment]
@DueDate datetime,
@DueAmount money,
@Paid bit,
@PaidDate datetime,
@PaidAmount money,
@Attachments nvarchar(1000),
@Archived bit,
@Commissioner nvarchar(100),
@Responsible nvarchar(100),
@Note nvarchar(2000),
@Type nvarchar(10),
@Sale nvarchar(100),
@Booking int,
@Invoice nvarchar(100),
@Deleted bit,
@LastModified datetime out,
@Id int out

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	INSERT INTO peips_dk_db.dbo.Payment(DueDate, DueAmount, Paid, PaidDate, PaidAmount,
	 Attachments, Archived, Commissioner, Responsible, Note, Type, Sale, Booking, Invoice,
	 Deleted, LastModified)
	VALUES (@DueDate, @DueAmount, @Paid, @PaidDate, @PaidAmount, @Attachments, @Archived, @Commissioner,
	 @Responsible, @Note, @Type, @Sale, @Booking, @Invoice, @Deleted, @LastModified)
	SET @Id = @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[InsertSupplier]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertSupplier] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(100),
	@Note nvarchar(2000),
	@Type nvarchar(50),
	@PaymentInfo nvarchar(250),
	@Id int out,
	@LastModified datetime out,
	@Deleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	INSERT INTO peips_dk_db.dbo.Party
		(Name, Note, LastModified, Deleted)
	VALUES
		(@Name, @Note, @LastModified, @Deleted)

	SET @Id = @@IDENTITY

	INSERT INTO peips_dk_db.dbo.Supplier
		(Type, PaymentInfo, PartyId)
	VALUES
		(@Type, @PaymentInfo, @Id)
END

GO
/****** Object:  StoredProcedure [dbo].[ReadAllCustomers]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadAllCustomers]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Customer.PartyId, Customer.Type, Party.Name, Party.Note, Party.LastModified, Party.Deleted 
	FROM peips_dk_db.dbo.Customer
	INNER JOIN peips_dk_db.dbo.Party
	ON Customer.PartyId = Party.PartyId
END

GO
/****** Object:  StoredProcedure [dbo].[ReadAllPayments]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadAllPayments]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from peips_dk_db.dbo.Payment
END

GO
/****** Object:  StoredProcedure [dbo].[ReadAllSuppliers]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadAllSuppliers]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Supplier.PartyId, Supplier.Type, Supplier.PaymentInfo, Party.Name, Party.Note, Party.LastModified, Party.Deleted 
	FROM peips_dk_db.dbo.Supplier
	INNER JOIN peips_dk_db.dbo.Party
	ON Supplier.PartyId = Party.PartyId
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCustomer]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Type nvarchar(50),
	@Name nvarchar(100),
	@Note nvarchar(2000),
	@LastModified datetime out,
	@Deleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	UPDATE peips_dk_db.dbo.Customer
	SET 
		Type = @Type
	WHERE
		PartyId = @Id
	UPDATE peips_dk_db.dbo.Party
	SET
		Name = @Name,
		Note = @Note,
		LastModified = @LastModified,
		Deleted = @Deleted
	WHERE
		PartyId = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdatePayment]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePayment]
@DueDate datetime,
@DueAmount money,
@Paid bit,
@PaidDate datetime,
@PaidAmount money,
@Attachments nvarchar(1000),
@Archived bit,
@Commissioner nvarchar(100),
@Responsible nvarchar(100),
@Note nvarchar(2000),
@Type nvarchar(10),
@Sale nvarchar(100),
@Booking int,
@Invoice nvarchar(100),
@LastModified datetime out,
@Deleted bit,
@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @LastModified = CURRENT_TIMESTAMP

    -- Insert statements for procedure here
	 UPDATE peips_dk_db.dbo.Payment
	 SET 
	 DueDate=@DueDate, 
	 DueAmount=@DueAmount, 
	 Paid=@Paid, 
	 PaidDate=@PaidDate, 
	 PaidAmount=@PaidAmount,
	 Attachments=@Attachments, 
	 Archived=@Archived, 
	 Commissioner=@Commissioner, 
	 Responsible=@Responsible,
	 Note=@Note, 
	 Type=@Type,
	 Sale=@Sale,
	 Booking=@Booking,
	 Invoice=@Invoice,
	 LastModified=@LastModified, 
	 Deleted=@Deleted
	 WHERE PaymentId=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSupplier]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSupplier]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Type nvarchar(50),
	@PaymentInfo nvarchar(250),
	@Name nvarchar(100),
	@Note nvarchar(2000),
	@LastModified datetime out,
	@Deleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	UPDATE peips_dk_db.dbo.Supplier
	SET 
		Type = @Type,
		PaymentInfo = @PaymentInfo
	WHERE
		PartyId = @Id
	UPDATE peips_dk_db.dbo.Party
	SET
		Name = @Name,
		Note = @Note,
		LastModified = @LastModified,
		Deleted = @Deleted
	WHERE
		PartyId = @Id
END

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[PartyId] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Party]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[PartyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Note] [nvarchar](2000) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[DueAmount] [money] NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
	[Paid] [bit] NOT NULL,
	[PaidDate] [datetime] NOT NULL,
	[PaidAmount] [money] NOT NULL,
	[Attachments] [nvarchar](1000) NOT NULL,
	[Archived] [bit] NOT NULL,
	[Commissioner] [nvarchar](100) NOT NULL,
	[Responsible] [nvarchar](100) NOT NULL,
	[Note] [nvarchar](2000) NOT NULL,
	[Sale] [nvarchar](100) NOT NULL,
	[Booking] [int] NOT NULL,
	[Invoice] [nvarchar](100) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 19-05-2014 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[PartyId] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[PaymentInfo] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (36, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (40, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (43, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (44, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (45, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (46, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (47, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (48, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (49, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (50, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (51, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (52, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (53, N'Bureau')
INSERT [dbo].[Customer] ([PartyId], [Type]) VALUES (55, N'Bureau')
SET IDENTITY_INSERT [dbo].[Party] ON 

INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (33, N'Hotel Continental', N'', CAST(0x0000A33000AE6D6E AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (34, N'Santa Isabella', N'', CAST(0x0000A33000AE5AB4 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (35, N'Dos Chorreras', N'Address: Km. 14 vía al Cajas, Cuenca, Ecuador
Phone:+593 7-285-3154', CAST(0x0000A33000AE162E AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (36, N'Viktors Farmor', N'', CAST(0x0000A33000ADFE8D AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (37, N'Posada Ingapirca', N'Empresa Hotelera Doncuni
0190343073001', CAST(0x0000A33000AEB4E0 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (38, N'Santa Lucia', N'', CAST(0x0000A33000AEFC80 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (39, N'Estrella del Mar', N'', CAST(0x0000A33000AF3263 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (40, N'Risskov Travel Partner', N'', CAST(0x0000A33000AF6B19 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (41, N'Posada Quinde', N'Address: Otavalo, Ecuador', CAST(0x0000A33000AF7E66 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (42, N'Dude', N'', CAST(0x0000A33000B42CE7 AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (43, N'Svanerejser', N'', CAST(0x0000A33000B13331 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (44, N'Hjemis', N'', CAST(0x0000A33000BF1B28 AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (45, N'Hansen Is', N'', CAST(0x0000A33000C3D0B2 AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (46, N'Polar Is', N'', CAST(0x0000A33000BF22C3 AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (47, N'Viktors Farmor', N'', CAST(0x0000A33000C3D0D1 AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (48, N'Svane Rejser Josefsen', N'', CAST(0x0000A33000B5AC09 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (49, N'Nyhavn Rejser', N'', CAST(0x0000A33000B5B702 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (50, N'Michael Hansen', N'Phone: +4555442311
Email: m.hansen@gmail.com', CAST(0x0000A33000B60606 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (51, N'Premium Is', N'', CAST(0x0000A33000B794E0 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (52, N'Cartedor', N'', CAST(0x0000A33000BE0F69 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (53, N'Ben and Jerrys', N'', CAST(0x0000A33000BF8267 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (54, N'Finulighed', N'', CAST(0x0000A33000BFBB00 AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (55, N'Sydney Lee', N'', CAST(0x0000A33000C4515D AS DateTime), 0)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (56, N'test', N'', CAST(0x0000A33000C7D12C AS DateTime), 1)
INSERT [dbo].[Party] ([PartyId], [Name], [Note], [LastModified], [Deleted]) VALUES (57, N'test', N'', CAST(0x0000A33000C8760C AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Party] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (10, CAST(0x0000A3E200000000 AS DateTime), 707.6000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Santa Isabella', N'Lonely Tree', N'', N'VF Jan', 28, N'', CAST(0x0000A33000C73D43 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (11, CAST(0x0000A43200000000 AS DateTime), 350.9000, N'Deposit', 1, CAST(0x0000A43000000000 AS DateTime), 350.9000, N'', 0, N'Posada Quinde', N'Lonely Tree', N'50% deposit', N'VF Jan', 54, N'', CAST(0x0000A33000C73D62 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (12, CAST(0x0000A45D00000000 AS DateTime), 350.9000, N'Balance', 1, CAST(0x0000A43E00000000 AS DateTime), 350.9000, N'C:\Users\Peter\Pictures\1890515_10203044983342844_1563815936_o.jpg', 0, N'Posada Quinde', N'Lonely Tree', N'50% balance', N'VF Jan', 54, N'', CAST(0x0000A33000C73D86 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (13, CAST(0x0000A35B00000000 AS DateTime), 110.0000, N'Credit', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Santa Isabella', N'Lonely Tree', N'', N'VF Chris', 11, N'', CAST(0x0000A33000B37856 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (14, CAST(0x0000A31E00000000 AS DateTime), 5530.0000, N'Full', 1, CAST(0x0000A31F00000000 AS DateTime), 5530.0000, N'', 0, N'Lonely Tree', N'Michael Hansen', N'', N'MH May', 23, N'', CAST(0x0000A33000C6C307 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (15, CAST(0x0000A33E00000000 AS DateTime), 7511.0000, N'Full', 1, CAST(0x0000A33E00000000 AS DateTime), 7511.0000, N'', 0, N'Lonely Tree', N'Viktors Farmor', N'', N'VF June', 30, N'VFJune30', CAST(0x0000A33000C6B22C AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (16, CAST(0x0000A4B800000000 AS DateTime), 1120.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'Nyhavn Rejser', N'', N'NR June', 55, N'', CAST(0x0000A33000C6B9EF AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (17, CAST(0x0000A2B400000000 AS DateTime), 120.0000, N'Credit', 1, CAST(0x0000A2B400000000 AS DateTime), 120.0000, N'', 0, N'Lonely Tree', N'Svane Rejser Josefsen', N'', N'SR Josef', 1, N'', CAST(0x0000A33000C72B10 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (18, CAST(0x0000A2B400000000 AS DateTime), 1625.0000, N'Balance', 1, CAST(0x0000A2BB00000000 AS DateTime), 1625.0000, N'C:\Users\Peter\Documents\PTF Presentation.pptx', 0, N'Lonely Tree', N'Svane Rejser Josefsen', N'The payment arrived one week late.', N'SR Josef', 2, N'SRJosef2', CAST(0x0000A33000C72B3B AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (19, CAST(0x0000A2CE00000000 AS DateTime), 2300.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 1, N'Lonely Tree', N'Dennis Knudsen', N'Customer cancelled the trip.', N'DK Feb', 5, N'', CAST(0x0000A33000C73169 AS DateTime), 0)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (20, CAST(0x0000A32B00000000 AS DateTime), 50.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'C:\Users\Peter\Documents\pez.docx', 0, N'Lonely Tree', N'test', N'', N'hej', 1, N'', CAST(0x0000A33000BC3B96 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (21, CAST(0x0000A32B00000000 AS DateTime), 50.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'C:\Users\Peter\Documents\pez.docx', 0, N'Lonely Tree', N'test2', N'', N'hej', 1, N'', CAST(0x0000A33000BC3D89 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (22, CAST(0x0000A33200000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'C:\Users\Peter\Documents\Project description.docx', 0, N'Lonely Tree', N'test', N'', N'hej', 1, N'', CAST(0x0000A33000BDF4BC AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (23, CAST(0x0000A33200000000 AS DateTime), 2.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'test2', N'', N'hej2', 2, N'', CAST(0x0000A33000BDF12C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (24, CAST(0x0000A33100000000 AS DateTime), 2.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'slettest', N'', N'hej', 0, N'', CAST(0x0000A33000C0BFE6 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (25, CAST(0x0000A33100000000 AS DateTime), 2.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'slettest2', N'', N'hej', 0, N'', CAST(0x0000A33000C1D9EF AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (26, CAST(0x0000A33200000000 AS DateTime), 33.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej2', N'', N's', 0, N'', CAST(0x0000A33000C1C846 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (27, CAST(0x0000A33200000000 AS DateTime), 33.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej2', N'', N's', 0, N'', CAST(0x0000A33000C1C864 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (28, CAST(0x0000A33200000000 AS DateTime), 33.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej2', N'', N's', 0, N'', CAST(0x0000A33000C1D9C9 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (29, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C259F6 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (30, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25A14 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (31, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25A39 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (32, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25A5F AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (33, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25A7F AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (34, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25A9A AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (35, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25AB8 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (36, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25ADC AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (37, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B03 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (38, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B1C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (39, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B3C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (40, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B5B AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (41, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B75 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (42, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25B8E AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (43, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25BA6 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (44, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25BCC AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (45, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25BE8 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (46, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C05 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (47, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C2C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (48, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C49 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (49, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C60 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (50, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C7A AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (51, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25C96 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (52, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25CB6 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (53, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25CD0 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (54, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25CEC AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (55, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D05 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (56, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D26 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (57, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D45 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (58, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D64 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (59, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D7F AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (60, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25D9E AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (61, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25DB6 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (62, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25DD2 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (63, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25DEF AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (64, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25E0E AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (65, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25E27 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (66, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25E45 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (67, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25E63 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (68, CAST(0x0000A33100000000 AS DateTime), 1.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej', N'', N'hej', 0, N'', CAST(0x0000A33000C25E7F AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (69, CAST(0x0000A33200000000 AS DateTime), 23.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'test', N'', N'te', 0, N'', CAST(0x0000A33000CCFC6C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (70, CAST(0x0000A32B00000000 AS DateTime), 23.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'test', N'', N't', 0, N'', CAST(0x0000A33000CD16B5 AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (71, CAST(0x0000A33200000000 AS DateTime), 20.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'test', N'', N'hej', 0, N'', CAST(0x0000A33000D14C6C AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentId], [DueDate], [DueAmount], [Type], [Paid], [PaidDate], [PaidAmount], [Attachments], [Archived], [Commissioner], [Responsible], [Note], [Sale], [Booking], [Invoice], [LastModified], [Deleted]) VALUES (72, CAST(0x0000A33200000000 AS DateTime), 23.0000, N'Full', 0, CAST(0x0000000000000000 AS DateTime), 0.0000, N'', 0, N'Lonely Tree', N'hej2', N'', N'he', 0, N'', CAST(0x0000A33000D168DA AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Payment] OFF
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (33, N'Hotel', N'Banco del Pichincha')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (34, N'Cruise', N'Banco de Pacifico')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (35, N'Hotel', N'Banco del Austro')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (37, N'Hotel', N'Banco del Austro')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (38, N'Cruise', N'Banco Internacional')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (39, N'Hotel', N'Banco Pichincha')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (41, N'Hotel', N'Banco del Austro')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (42, N'Hotel', N'')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (54, N'Hotel', N'')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (56, N'Hotel', N'')
INSERT [dbo].[Supplier] ([PartyId], [Type], [PaymentInfo]) VALUES (57, N'Hotel', N'')
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Party]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Party]
GO
USE [master]
GO
ALTER DATABASE [peips_dk_db] SET  READ_WRITE 
GO
