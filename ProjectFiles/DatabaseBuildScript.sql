USE [master]
GO
/****** Object:  Database [Simuu]    Script Date: 9/9/2019 5:06:40 AM ******/
CREATE DATABASE [Simuu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Simuu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Simuu.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Simuu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Simuu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Simuu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Simuu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Simuu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Simuu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Simuu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Simuu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Simuu] SET ARITHABORT OFF 
GO
ALTER DATABASE [Simuu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Simuu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Simuu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Simuu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Simuu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Simuu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Simuu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Simuu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Simuu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Simuu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Simuu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Simuu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Simuu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Simuu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Simuu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Simuu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Simuu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Simuu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Simuu] SET  MULTI_USER 
GO
ALTER DATABASE [Simuu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Simuu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Simuu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Simuu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Simuu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Simuu] SET QUERY_STORE = OFF
GO
USE [Simuu]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemEnergyModifier] [int] NOT NULL,
	[ItemThirstModifier] [int] NOT NULL,
	[ItemHungerModifier] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](250) NOT NULL,
	[StackTrace] [nvarchar](max) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RolePermissions] [nvarchar](4) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Simuus]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Simuus](
	[SimuuID] [int] IDENTITY(1,1) NOT NULL,
	[SimuuName] [nvarchar](50) NOT NULL,
	[SimuuAge] [int] NOT NULL,
	[SimuuBirth] [datetime2](7) NOT NULL,
	[SimuuDeath] [datetime2](7) NULL,
	[SimuuXCoordinate] [int] NOT NULL,
	[SimuuYCoordinate] [int] NOT NULL,
	[ImpulseToRest] [int] NULL,
	[ImpulseToDrink] [int] NOT NULL,
	[ImpulseToEat] [int] NOT NULL,
	[StatEnergy] [int] NOT NULL,
	[StatThirst] [int] NOT NULL,
	[StatHunger] [int] NOT NULL,
	[StatMovementSpeed] [int] NOT NULL,
	[StatSenseRadius] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Simuus_1] PRIMARY KEY CLUSTERED 
(
	[SimuuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](25) NOT NULL,
	[UserEmail] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](250) NOT NULL,
	[PasswordSalt] [nvarchar](250) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles]    Script Date: 9/9/2019 5:06:40 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRoles] ON [dbo].[Roles]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Users]
GO
ALTER TABLE [dbo].[Simuus]  WITH CHECK ADD  CONSTRAINT [FK_Simuus_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Simuus] CHECK CONSTRAINT [FK_Simuus_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Item_Create]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Create an Item
-- =============================================
CREATE PROCEDURE [dbo].[Item_Create]
	@ItemID INT OUTPUT
	,@ItemName NVARCHAR(50)
	,@ItemEnergyModifier INT
	,@ItemThirstModifier INT
	,@ItemHungerModifier INT
	,@UserID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Items 
		(ItemName
		,ItemEnergyModifier
		,ItemThirstModifier
		,ItemHungerModifier
		,UserID)
	VALUES 
		(@ItemName
		,@ItemEnergyModifier
		,@ItemThirstModifier
		,@ItemHungerModifier
		,@UserID)
	SELECT @ItemID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[Item_Delete]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Delete an Item
-- =============================================
CREATE PROCEDURE [dbo].[Item_Delete]
	@ItemID INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Items
	WHERE ItemID = @ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[Item_FindByItemID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single Item record by ItemID
-- =============================================
CREATE PROCEDURE [dbo].[Item_FindByItemID]
	@ItemID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		ItemID
		,ItemName
		,ItemEnergyModifier
		,ItemThirstModifier
		,ItemHungerModifier
		,Items.UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,RoleID
	FROM Items
	INNER JOIN Users ON Items.UserID = Users.UserID
	WHERE ItemID = @ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[Item_JustUpdate]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Updates a Item's ItemName, ItemEnergyModifier, ItemThirstModifier and ItemHungerModifier
-- =============================================
CREATE PROCEDURE [dbo].[Item_JustUpdate]
	@ItemID INT
	,@ItemName NVARCHAR(50)
	,@ItemEnergyModifier INT
	,@ItemThirstModifier INT
	,@ItemHungerModifier INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Items
	SET 
		ItemName = @ItemName
		,ItemEnergyModifier = @ItemEnergyModifier
		,ItemThirstModifier = @ItemThirstModifier
		,ItemHungerModifier = @ItemHungerModifier
	WHERE 
		ItemID = @ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[Items_Get]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets all Item records
-- =============================================
CREATE PROCEDURE [dbo].[Items_Get]
	@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		ItemID
		,ItemName
		,ItemEnergyModifier
		,ItemThirstModifier
		,ItemHungerModifier
		,Items.UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,RoleID
	FROM Items
	INNER JOIN Users ON Items.UserID = Users.UserID
	ORDER BY ItemID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Items_GetRelatedToUserID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Items with same UserID
-- =============================================
CREATE PROCEDURE [dbo].[Items_GetRelatedToUserID]
	-- Add the parameters for the stored procedure here
	@UserID INT
	,@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		ItemID
		,ItemName
		,ItemEnergyModifier
		,ItemThirstModifier
		,ItemHungerModifier
		,UserID
	FROM Items
	WHERE UserID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[Items_ObtainCount]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Items
-- =============================================
CREATE PROCEDURE [dbo].[Items_ObtainCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Items
END
GO
/****** Object:  StoredProcedure [dbo].[Items_ObtainCountRelatedToUserID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Items with same UserID
-- =============================================
CREATE PROCEDURE [dbo].[Items_ObtainCountRelatedToUserID]
	-- Add the parameters for the stored procedure here
	@UserID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Items
	WHERE UserID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[Log_Insert]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/19/2019
-- Description:	Inserts any errors or alerts in Logs
-- =============================================
CREATE PROCEDURE [dbo].[Log_Insert]
	-- Add the parameters for the stored procedure here
	@Message NVARCHAR(250)
	,@StackTrace NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Logs 
		([Message]
		,StackTrace
		,[TimeStamp])
	VALUES
		(@Message
		,@StackTrace
		,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[Reload]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reload]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @NormalID INT
	DECLARE @PowerID INT
	DECLARE @AdminID INT
	
	DECLARE @FirstUserID INT
	DECLARE @SecondUserID INT
	DECLARE @ThirdUserID INT

	DECLARE @SimuuID INT

	DECLARE @ItemID INT

	EXEC Role_Create @AdminID OUTPUT,'Administrator', 'CRUD'
	EXEC Role_Create @PowerID OUTPUT,'PowerUser', 'CRUD'
	EXEC Role_Create @NormalID OUTPUT,'NormalUser', 'R'

	EXEC User_Create @FirstUserID OUTPUT, 'DrMan', 'DrMan@Email.com', 'Wow@12', 1010, @AdminID
	EXEC User_Create @SecondUserID OUTPUT, 'MrPlank', 'MrPlank@Email.com', 'Wow@12', 1111, @PowerID
	EXEC User_Create @ThirdUserID OUTPUT, 'CharlesOkay', 'Charles@Email.com', 'Wow@12', 1100, @NormalID

	EXEC Simuu_Create @SimuuID, 'Teddy', 22, '2019/01/21', '2019/01/21', 250, 250, 25, 25, 25, 100, 100, 100, 15, 20, @FirstUserID
	EXEC Simuu_Create @SimuuID, 'Alphy', 19, '2019/01/21', '2019/01/21', 322, 321, 25, 25, 25, 100, 100, 100, 8, 15, @FirstUserID
	EXEC Simuu_Create @SimuuID, 'Jinso', 33, '2019/01/21', '2019/01/21', 121, 111, 25, 25, 25, 100, 100, 100, 5, 17, @FirstUserID
	EXEC Simuu_Create @SimuuID, 'Dobbie', 41, '2019/01/21', '2019/01/21', 99, 333, 25, 25, 25, 100, 100, 100, 11, 13, @SecondUserID
	EXEC Simuu_Create @SimuuID, 'Melrose', 13, '2019/01/21', '2019/01/21', 54, 400, 25, 25, 25, 100, 100, 100, 6, 19, @SecondUserID
	EXEC Simuu_Create @SimuuID, 'Vander', 54, '2019/01/21', '2019/01/21', 299, 55, 25, 25, 25, 100, 100, 100, 9, 16, @ThirdUserID

	EXEC Item_Create @ItemID, 'Pizza', 10, 0, 20, @FirstUserID
	EXEC Item_Create @ItemID, 'Cherry', 5, 10, 10, @FirstUserID
	EXEC Item_Create @ItemID, 'Soda', 10, 10, 0, @SecondUserID
	EXEC Item_Create @ItemID, 'Water', 0, 20, 0, @SecondUserID
	EXEC Item_Create @ItemID, 'Donut', 10, 0, 20, @ThirdUserID
END
GO
/****** Object:  StoredProcedure [dbo].[Reset]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/19/2019
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reset]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Items;
	DELETE FROM Simuus;
	DELETE FROM Users;
	DELETE FROM Roles;
	
	DBCC checkident('Items',reseed,0);
	DBCC checkident('Simuus',reseed,0);
	DBCC checkident('Users',reseed,0);
	DBCC checkident('Roles',reseed,0);
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Create]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Create a UserRole
-- =============================================
CREATE PROCEDURE [dbo].[Role_Create]
	@RoleID INT OUTPUT
	,@RoleName NVARCHAR(80)
	,@RolePermissions NVARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Roles
		(RoleName
		,RolePermissions)
	VALUES 
		(@RoleName
		,@RolePermissions)
	SELECT @RoleID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Delete a User Role and all Users in deleted role
-- =============================================
CREATE PROCEDURE [dbo].[Role_Delete]
	@RoleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Items
	WHERE UserID IN (SELECT UserID FROM Users WHERE RoleID = @RoleID)
	DELETE FROM Simuus
	WHERE UserID IN (SELECT UserID FROM Users WHERE RoleID = @RoleID)
	DELETE FROM Users
	WHERE RoleID = @RoleID
	DELETE FROM Roles
	WHERE RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[Role_FindByRoleID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single Role record by RoleID
-- =============================================
CREATE PROCEDURE [dbo].[Role_FindByRoleID]
	@RoleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		RoleID
		,RoleName
		,RolePermissions
	FROM Roles
	WHERE RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[Role_JustUpdate]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Updates a UserRole's RoleName and RolePermissions
-- =============================================
CREATE PROCEDURE [dbo].[Role_JustUpdate]
	@RoleID INT
	,@RoleName NVARCHAR(50)
	,@RolePermissions NVARCHAR(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Roles
	SET 
		RoleName = @RoleName
		,RolePermissions = @RolePermissions
	WHERE 
		RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Get]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/19/2019
-- Description:	Gets all roles
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Get]
	@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		RoleID
		,RoleName
		,RolePermissions
	FROM Roles
	ORDER BY RoleID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_ObtainCount]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Roles
-- =============================================
CREATE PROCEDURE [dbo].[Roles_ObtainCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Roles
END
GO
/****** Object:  StoredProcedure [dbo].[Simuu_Create]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Create a Simuu
-- =============================================
CREATE PROCEDURE [dbo].[Simuu_Create]
	(@SimuuID INT OUTPUT
	,@SimuuName NVARCHAR(50)
	,@SimuuAge INT
	,@SimuuBirth DATETIME2(7)
	,@SimuuDeath DATETIME2(7)
	,@SimuuXCoordinate INT
	,@SimuuYCoordinate INT
	,@ImpulseToRest INT
	,@ImpulseToDrink INT
	,@ImpulseToEat INT
	,@StatEnergy INT
	,@StatThirst INT
	,@StatHunger INT
	,@StatMovementSpeed INT
	,@StatSenseRadius INT
	,@UserID INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Simuus 
		(SimuuName
		,SimuuAge
		,SimuuBirth
		,SimuuDeath
		,SimuuXCoordinate
		,SimuuYCoordinate
		,ImpulseToRest
		,ImpulseToDrink
		,ImpulseToEat
		,StatEnergy
		,StatThirst
		,StatHunger
		,StatMovementSpeed
		,StatSenseRadius
		,UserID)
	VALUES 
		(@SimuuName
		,@SimuuAge 
		,@SimuuBirth
		,@SimuuDeath
		,@SimuuXCoordinate
		,@SimuuYCoordinate
		,@ImpulseToRest
		,@ImpulseToDrink
		,@ImpulseToEat
		,@StatEnergy
		,@StatThirst
		,@StatHunger
		,@StatMovementSpeed
		,@StatSenseRadius
		,@UserID)
	SELECT @SimuuID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[Simuu_Delete]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Delete a Simuu
-- =============================================
CREATE PROCEDURE [dbo].[Simuu_Delete]
	@SimuuID INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Simuus
	WHERE SimuuID = @SimuuID
END
GO
/****** Object:  StoredProcedure [dbo].[Simuu_FindBySimuuID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single Simuu record by SimuuID
-- =============================================
CREATE PROCEDURE [dbo].[Simuu_FindBySimuuID]
	@SimuuID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		SimuuID
		,SimuuName
		,SimuuAge
		,SimuuBirth
		,SimuuDeath
		,SimuuXCoordinate
		,SimuuYCoordinate
		,ImpulseToRest
		,ImpulseToDrink
		,ImpulseToEat
		,StatEnergy
		,StatThirst
		,StatHunger
		,StatMovementSpeed
		,StatSenseRadius
		,Simuus.UserID
		,Username
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,RoleID
	FROM Simuus
	INNER JOIN Users ON Simuus.UserID = Users.UserID
	WHERE SimuuID = @SimuuID
END
GO
/****** Object:  StoredProcedure [dbo].[Simuu_JustUpdate]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Updates a Simuu
-- =============================================
CREATE PROCEDURE [dbo].[Simuu_JustUpdate]
	(@SimuuID INT OUTPUT
	,@SimuuName NVARCHAR(50)
	,@SimuuAge INT
	,@SimuuBirth DATETIME2(7)
	,@SimuuDeath DATETIME2(7)
	,@SimuuXCoordinate INT
	,@SimuuYCoordinate INT
	,@ImpulseToRest INT
	,@ImpulseToDrink INT
	,@ImpulseToEat INT
	,@StatEnergy INT
	,@StatThirst INT
	,@StatHunger INT
	,@StatMovementSpeed INT
	,@StatSenseRadius INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Simuus
	SET 
		SimuuName = @SimuuName
		,SimuuAge = @SimuuAge
		,SimuuBirth = @SimuuBirth
		,SimuuDeath = @SimuuDeath
		,SimuuXCoordinate = @SimuuXCoordinate
		,SimuuYCoordinate = @SimuuYCoordinate
		,ImpulseToRest = @ImpulseToRest
		,ImpulseToDrink = @ImpulseToDrink
		,ImpulseToEat = @ImpulseToEat
		,StatEnergy = @StatEnergy
		,StatThirst = @StatThirst
		,StatHunger = @StatHunger
		,StatMovementSpeed = @StatMovementSpeed
		,StatSenseRadius = @StatSenseRadius
	WHERE 
		SimuuID = @SimuuID
END
GO
/****** Object:  StoredProcedure [dbo].[Simuus_Get]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets all User records
-- =============================================
CREATE PROCEDURE [dbo].[Simuus_Get]
	@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		SimuuID
		,SimuuName
		,SimuuAge
		,SimuuBirth
		,SimuuDeath
		,SimuuXCoordinate
		,SimuuYCoordinate
		,ImpulseToRest
		,ImpulseToDrink
		,ImpulseToEat
		,StatEnergy
		,StatThirst
		,StatHunger
		,StatMovementSpeed
		,StatSenseRadius
		,Simuus.UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,RoleID
	FROM Simuus
	INNER JOIN Users ON Simuus.UserID = Users.UserID
	ORDER BY SimuuID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Simuus_GetRelatedToUserID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets all Simuu records related to a UserID
-- =============================================
CREATE PROCEDURE [dbo].[Simuus_GetRelatedToUserID]
	@UserID INT
	,@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Users.UserID
		,Users.UserName
		,SimuuID
		,SimuuName
	FROM Simuus
	INNER JOIN Users ON Simuus.UserID = Users.UserID
	WHERE Simuus.UserID = @UserID
	ORDER BY SimuuID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Simuus_ObtainCount]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Simuus
-- =============================================
CREATE PROCEDURE [dbo].[Simuus_ObtainCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Simuus
END
GO
/****** Object:  StoredProcedure [dbo].[Simuus_ObtainCountRelatedToUserID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Simuus
-- =============================================
CREATE PROCEDURE [dbo].[Simuus_ObtainCountRelatedToUserID]
	-- Add the parameters for the stored procedure here
	@UserID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Simuus
	WHERE UserID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[User_Create]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Create a User
-- =============================================
CREATE PROCEDURE [dbo].[User_Create]
	@UserID INT OUTPUT
	,@UserName NVARCHAR(25)
	,@UserEmail NVARCHAR(100)
	,@PasswordHash NVARCHAR(250)
	,@PasswordSalt NVARCHAR(250)
	,@RoleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users 
		(UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,RoleID)
	VALUES 
		(@UserName
		,@UserEmail
		,@PasswordHash
		,@PasswordSalt
		,@RoleID)
	SELECT @UserID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Delete a User
-- =============================================
CREATE PROCEDURE [dbo].[User_Delete]
	@UserID INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Items
	WHERE UserID = @UserID
	DELETE FROM Simuus
	WHERE UserID = @UserID
	DELETE FROM Users
	WHERE UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[User_FindByUserEmail]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single User record by UserEmail
-- =============================================
CREATE PROCEDURE [dbo].[User_FindByUserEmail]
	@UserEmail NVARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,Users.RoleID
		,RoleName
		,RolePermissions
	FROM Users
	INNER JOIN Roles ON Users.RoleID = Roles.RoleID
	WHERE UserEmail = @UserEmail
END
GO
/****** Object:  StoredProcedure [dbo].[User_FindByUserID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single User record by UserID
-- =============================================
CREATE PROCEDURE [dbo].[User_FindByUserID]
	@UserID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,Users.RoleID
		,RoleName
		,RolePermissions
	FROM Users
	INNER JOIN Roles ON Users.RoleID = Roles.RoleID
	WHERE UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[User_FindByUserName]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets a single User record by UserName
-- =============================================
CREATE PROCEDURE [dbo].[User_FindByUserName]
	@UserName NVARCHAR(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,Users.RoleID
		,RoleName
		,RolePermissions
	FROM Users
	INNER JOIN Roles ON Users.RoleID = Roles.RoleID
	WHERE UserName = @UserName
END
GO
/****** Object:  StoredProcedure [dbo].[User_JustUpdate]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Updates a User's UserName and UserEmail
-- =============================================
CREATE PROCEDURE [dbo].[User_JustUpdate]
	@UserID INT
	,@UserName NVARCHAR(25)
	,@UserEmail NVARCHAR(100)
	,@PasswordHash NVARCHAR(250)
	,@PasswordSalt NVARCHAR(250)
	,@RoleID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Users
	SET 
		UserName = @UserName
		,UserEmail = @UserEmail
		,PasswordHash = @PasswordHash
		,PasswordSalt = @PasswordSalt
		,RoleID = @RoleID
	WHERE 
		UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Get]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets all User records
-- =============================================
CREATE PROCEDURE [dbo].[Users_Get]
	@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,Users.RoleID
		,RoleName
		,RolePermissions
	FROM Users
	INNER JOIN Roles ON Users.RoleID = Roles.RoleID
	ORDER BY UserID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Users_GetRelatedToRoleID]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/12/2019
-- Description:	Gets all User records related to UserRoleID
-- =============================================
CREATE PROCEDURE [dbo].[Users_GetRelatedToRoleID]
	@RoleID INT
	,@Skip INT
	,@Take INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserID
		,UserName
		,UserEmail
		,PasswordHash
		,PasswordSalt
		,Users.RoleID
		,RoleName
		,RolePermissions
	FROM Users
	INNER JOIN Roles ON Users.RoleID = Roles.RoleID
	WHERE Users.RoleID = @RoleID
	ORDER BY UserID
	offset @Skip ROWS
	FETCH NEXT @Take ROWS only
END
GO
/****** Object:  StoredProcedure [dbo].[Users_ObtainCount]    Script Date: 9/9/2019 5:06:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Justin Davis
-- Create date: 08/14/2019
-- Description:	Obtains the count of Users
-- =============================================
CREATE PROCEDURE [dbo].[Users_ObtainCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM Users
END
GO
USE [master]
GO
ALTER DATABASE [Simuu] SET  READ_WRITE 
GO
