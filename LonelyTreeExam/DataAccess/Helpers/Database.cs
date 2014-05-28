using System;
using System.Data.SqlClient;

namespace DataAccess.Helpers
{
    internal class Database
    {
        
        internal void CreateDatabase(string connectString)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
            }
            catch (Exception)
            {
            _connectionString =  @"Server=LOCALHOST\LOCALHOST;Integrated Security=true";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = (
                @"USE [master]
GO
/****** Object:  Database [Friendly_TOM]    Script Date: 28-05-2014 11:46:17 ******/
CREATE DATABASE [Friendly_TOM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Friendly_TOM', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.LOCALHOST\MSSQL\DATA\Friendly_TOM.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Friendly_TOM_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.LOCALHOST\MSSQL\DATA\Friendly_TOM_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Friendly_TOM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Friendly_TOM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Friendly_TOM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Friendly_TOM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Friendly_TOM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Friendly_TOM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Friendly_TOM] SET ARITHABORT OFF 
GO
ALTER DATABASE [Friendly_TOM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Friendly_TOM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Friendly_TOM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Friendly_TOM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Friendly_TOM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Friendly_TOM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Friendly_TOM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Friendly_TOM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Friendly_TOM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Friendly_TOM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Friendly_TOM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Friendly_TOM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Friendly_TOM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Friendly_TOM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Friendly_TOM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Friendly_TOM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Friendly_TOM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Friendly_TOM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Friendly_TOM] SET  MULTI_USER 
GO
ALTER DATABASE [Friendly_TOM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Friendly_TOM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Friendly_TOM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Friendly_TOM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Friendly_TOM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Friendly_TOM]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[Supplier] [int] NOT NULL,
	[Customer] [int] NOT NULL,
	[Note] [nvarchar](2000) NOT NULL,
	[Sale] [nvarchar](50) NOT NULL,
	[BookingNumber] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[IVAExempt] [decimal](18, 0) NOT NULL,
	[IVASubject] [decimal](18, 0) NOT NULL,
	[Subtotal] [decimal](18, 0) NOT NULL,
	[Service] [decimal](18, 0) NOT NULL,
	[IVA] [decimal](18, 0) NOT NULL,
	[ProductRetention] [decimal](18, 0) NOT NULL,
	[SupplierRetention] [decimal](18, 0) NOT NULL,
	[TransferAmount] [decimal](18, 0) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Booking_1] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[PartyId] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[PhoneNo] [nvarchar](50) NOT NULL,
	[FaxNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Party]    Script Date: 28-05-2014 11:46:17 ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 28-05-2014 11:46:17 ******/
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
	[Payee] [int] NOT NULL,
	[Payer] [int] NOT NULL,
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
/****** Object:  Table [dbo].[PaymentRule]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentRule](
	[PaymentRuleId] [int] IDENTITY(1,1) NOT NULL,
	[Supplier] [int] NOT NULL,
	[Customer] [int] NOT NULL,
	[BookingType] [nvarchar](50) NOT NULL,
	[Percentage] [money] NOT NULL,
	[DaysOffset] [int] NOT NULL,
	[BaseDate] [nvarchar](50) NOT NULL,
	[PaymentType] [nvarchar](50) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PaymentRule] PRIMARY KEY CLUSTERED 
(
	[PaymentRuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[PartyId] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[AccountNo] [nchar](50) NOT NULL,
	[AccountName] [nchar](100) NOT NULL,
	[OwnerId] [nchar](50) NOT NULL,
	[Bank] [nchar](100) NOT NULL,
	[AccountType] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([PartyId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Supplier] FOREIGN KEY([Supplier])
REFERENCES [dbo].[Supplier] ([PartyId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Supplier]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Party]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Commissioner] FOREIGN KEY([Payee])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Commissioner]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Responsible] FOREIGN KEY([Payer])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Responsible]
GO
ALTER TABLE [dbo].[PaymentRule]  WITH CHECK ADD  CONSTRAINT [FK_PaymentRule_Customer] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([PartyId])
GO
ALTER TABLE [dbo].[PaymentRule] CHECK CONSTRAINT [FK_PaymentRule_Customer]
GO
ALTER TABLE [dbo].[PaymentRule]  WITH CHECK ADD  CONSTRAINT [FK_PaymentRule_Supplier] FOREIGN KEY([Supplier])
REFERENCES [dbo].[Supplier] ([PartyId])
GO
ALTER TABLE [dbo].[PaymentRule] CHECK CONSTRAINT [FK_PaymentRule_Supplier]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Party]
GO
/****** Object:  StoredProcedure [dbo].[InsertBooking]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBooking]
@Supplier int,
@Customer int,
@Note nvarchar(2000),
@Sale nvarchar(50),
@BookingNumber int,
@StartDate datetime,
@EndDate datetime,
@Type nvarchar(50),
@IVAExempt decimal,
@IVASubject decimal,
@Subtotal decimal,
@Service decimal,
@IVA decimal,
@ProductRetention decimal,
@SupplierRetention decimal,
@TransferAmount decimal,
@Deleted bit,
@LastModified datetime out,
@Id int out

as
BEGIN
	SET @LastModified = CURRENT_TIMESTAMP
	    -- Insert statements for procedure here
	INSERT INTO peips_dk_db.dbo.Booking(Supplier, Customer, Note, Sale, BookingNumber, StartDate, EndDate, Type,
	IVAExempt, IVASubject, Subtotal, Service, IVA, ProductRetention, SupplierRetention, TransferAmount, Deleted, LastModified)
	VALUES (@Supplier, @Customer, @Note, @Sale, @BookingNumber, @StartDate, @EndDate, @Type, @IVAExempt, @IVASubject, @Subtotal,
	@Service, @IVA, @ProductRetention, @SupplierRetention, @TransferAmount, @Deleted, @LastModified)
	SET @Id = @@IDENTITY
END



GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 28-05-2014 11:46:17 ******/
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
	@ContactPerson nvarchar(100),
	@Email nvarchar(100),
	@Address nvarchar(500),
	@PhoneNo nvarchar(50),
	@FaxNo nvarchar(50),
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
	INSERT INTO Friendly_TOM.dbo.Party
		(Name, Note, LastModified, Deleted)
	VALUES
		(@Name, @Note, @LastModified, @Deleted)

	SET @Id = @@IDENTITY

	INSERT INTO Friendly_TOM.dbo.Customer
		(Type, PartyId, ContactPerson, Email, Address, PhoneNo, FaxNo)
	VALUES
		(@Type, @Id, @ContactPerson, @Email, @Address, @PhoneNo, @FaxNo)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertPayment]    Script Date: 28-05-2014 11:46:17 ******/
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
@Payee int,
@Payer int,
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
	INSERT INTO Friendly_TOM.dbo.Payment(DueDate, DueAmount, Paid, PaidDate, PaidAmount,
	 Attachments, Archived, Payee, Payer, Note, Type, Sale, Booking, Invoice,
	 Deleted, LastModified)
	VALUES (@DueDate, @DueAmount, @Paid, @PaidDate, @PaidAmount, @Attachments, @Archived, @Payee,
	 @Payer, @Note, @Type, @Sale, @Booking, @Invoice, @Deleted, @LastModified)
	SET @Id = @@identity
END


GO
/****** Object:  StoredProcedure [dbo].[InsertPaymentRule]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPaymentRule]
	-- Add the parameters for the stored procedure here
	@Supplier int,
	@Customer int,
	@BookingType nvarchar(50),
	@Percentage money,
	@DaysOffset int,
	@BaseDate nvarchar(50),
	@PaymentType nvarchar(50),
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
	INSERT INTO dbo.PaymentRule (Supplier, Customer, BookingType, Percentage, DaysOffset, BaseDate, PaymentType, Deleted, LastModified)
	VALUES (@Supplier, @Customer, @BookingType, @Percentage, @DaysOffset, @BaseDate, @PaymentType, @Deleted, @LastModified)
	SET @Id = @@IDENTITY
END


GO
/****** Object:  StoredProcedure [dbo].[InsertSupplier]    Script Date: 28-05-2014 11:46:17 ******/
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
	@Id int out,
	@LastModified datetime out,
	@Deleted bit,
	@AccountNo nvarchar(50),
	@AccountName nvarchar(100),
	@OwnerId nvarchar(50),
	@Bank nvarchar(100),
	@AccountType nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	INSERT INTO Friendly_TOM.dbo.Party
		(Name, Note, LastModified, Deleted)
	VALUES
		(@Name, @Note, @LastModified, @Deleted)

	SET @Id = @@IDENTITY

	INSERT INTO Friendly_TOM.dbo.Supplier
		(Type, PartyId, AccountNo, AccountName, 
		OwnerId, Bank, AccountType)
	VALUES
		(@Type, @Id, @AccountNo, @AccountName, @OwnerId
		, @Bank, @AccountType)
END


GO
/****** Object:  StoredProcedure [dbo].[ReadAllBookings]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ReadAllBookings]
as
begin
select * from Friendly_TOM.dbo.Booking
end

GO
/****** Object:  StoredProcedure [dbo].[ReadAllCustomers]    Script Date: 28-05-2014 11:46:17 ******/
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
		Customer.PartyId, Customer.Type, Customer.ContactPerson, Customer.Email, Customer.Address,
		Customer.PhoneNo, Customer.FaxNo, Party.Name, Party.Note, Party.LastModified, Party.Deleted 
	FROM Friendly_TOM.dbo.Customer
	INNER JOIN Friendly_TOM.dbo.Party
	ON Customer.PartyId = Party.PartyId
END


GO
/****** Object:  StoredProcedure [dbo].[ReadAllPaymentRules]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReadAllPaymentRules]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.PaymentRule
END


GO
/****** Object:  StoredProcedure [dbo].[ReadAllPayments]    Script Date: 28-05-2014 11:46:17 ******/
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
	SELECT * from Friendly_TOM.dbo.Payment
END


GO
/****** Object:  StoredProcedure [dbo].[ReadAllSuppliers]    Script Date: 28-05-2014 11:46:17 ******/
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
		Supplier.PartyId, Supplier.Type, Supplier.AccountNo, Supplier.AccountName, Supplier.OwnerId, Supplier.Bank, Supplier.AccountType,
		Party.Name, Party.Note, Party.LastModified, Party.Deleted 
	FROM Friendly_TOM.dbo.Supplier
	INNER JOIN Friendly_TOM.dbo.Party
	ON Supplier.PartyId = Party.PartyId
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateBooking]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBooking]
@Supplier int,
@Customer int,
@Note nvarchar(2000),
@Sale nvarchar(50),
@BookingNumber int,
@StartDate datetime,
@EndDate datetime,
@Type nvarchar(50),
@IVAExempt decimal,
@IVASubject decimal,
@Subtotal decimal,
@Service decimal,
@IVA decimal,
@ProductRetention decimal,
@SupplierRetention decimal,
@TransferAmount decimal,
@Deleted bit,
@LastModified datetime out,
@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		    -- Insert statements for procedure here
	 SET @LastModified = CURRENT_TIMESTAMP
	 UPDATE Friendly_TOM.dbo.Booking
	 SET 
	 Supplier = @Supplier,
	 Customer = @Customer,
	 Note = @Note,
	 Sale = @Sale,
	 BookingNumber = @BookingNumber,
	 StartDate=@StartDate,
	 EndDate=@EndDate,
	 Type=@Type,
	 IVAExempt=@IVAExempt,
	 IVASubject = @IVASubject,
	 Subtotal=@Subtotal,
	 Service=@Service,
	 IVA=@IVA,
	 ProductRetention=@ProductRetention,
	 SupplierRetention=@SupplierRetention,
	 TransferAmount=@TransferAmount,
	 Deleted = @Deleted,
	 LastModified = @LastModified	 
	 WHERE BookingId=@Id

END


GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 28-05-2014 11:46:17 ******/
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
	@ContactPerson nvarchar(100),
	@Email nvarchar(100),
	@Address nvarchar(500),
	@PhoneNo nvarchar(50),
	@FaxNo nvarchar(50),
	@LastModified datetime out,
	@Deleted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	UPDATE Friendly_TOM.dbo.Customer
	SET 
		Type = @Type,
		ContactPerson = @ContactPerson,
		Email = @Email,
		Address = @Address,
		PhoneNo = @PhoneNo,
		FaxNo = @FaxNo
	WHERE
		PartyId = @Id
	UPDATE Friendly_TOM.dbo.Party
	SET
		Name = @Name,
		Note = @Note,
		LastModified = @LastModified,
		Deleted = @Deleted
	WHERE
		PartyId = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[UpdatePayment]    Script Date: 28-05-2014 11:46:17 ******/
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
@Payee int,
@Payer int,
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
	 UPDATE Friendly_TOM.dbo.Payment
	 SET 
	 DueDate=@DueDate, 
	 DueAmount=@DueAmount, 
	 Paid=@Paid, 
	 PaidDate=@PaidDate, 
	 PaidAmount=@PaidAmount,
	 Attachments=@Attachments, 
	 Archived=@Archived, 
	 Payee=@Payee, 
	 Payer=@Payer,
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
/****** Object:  StoredProcedure [dbo].[UpdatePaymentRule]    Script Date: 28-05-2014 11:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePaymentRule]
	-- Add the parameters for the stored procedure here
	@Supplier int,
	@Customer int,
	@BookingType nvarchar(50),
	@Percentage money,
	@DaysOffset int,
	@BaseDate nvarchar(50),
	@PaymentType nvarchar(50),
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
	UPDATE dbo.PaymentRule
	SET
	Supplier = @Supplier,
	Customer = @Customer,
	BookingType = @BookingType,
	Percentage = @Percentage,
	DaysOffset = @DaysOffset,
	BaseDate = @BaseDate,
	PaymentType = @PaymentType,
	Deleted = @Deleted,
	LastModified = @LastModified
	WHERE PaymentRuleId = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateSupplier]    Script Date: 28-05-2014 11:46:17 ******/
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
	@Name nvarchar(100),
	@Note nvarchar(2000),
	@LastModified datetime out,
	@Deleted bit,
	@AccountNo nvarchar(50),
	@AccountName nvarchar(100),
	@OwnerId nvarchar(50),
	@Bank nvarchar(100),
	@AccountType nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @LastModified = CURRENT_TIMESTAMP
	UPDATE Friendly_TOM.dbo.Supplier
	SET 
		Type = @Type,
		AccountNo = @AccountNo,
		AccountName = @AccountName,
		OwnerId = @OwnerId,
		Bank = @Bank,
		AccountType = @AccountType
	WHERE
		PartyId = @Id
	UPDATE Friendly_TOM.dbo.Party
	SET
		Name = @Name,
		Note = @Note,
		LastModified = @LastModified,
		Deleted = @Deleted
	WHERE
		PartyId = @Id
END


GO
USE [master]
GO
ALTER DATABASE [Friendly_TOM] SET  READ_WRITE 
GO
");
                con.Open();
                cmd.ExecuteNonQuery();
            }
            }
        }



        private string _connectionString;
    }
}
