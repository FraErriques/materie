USE [Logging]
GO
/****** Object:  User [appuser]    Script Date: 10/13/2024 8:29:33 PM ******/
CREATE USER [appuser] FOR LOGIN [appuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [appuser]
GO
/****** Object:  Table [dbo].[Francesco__127_0_0_1]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Francesco__127_0_0_1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materie_fatClientBeta11_dbFrechet]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materie_fatClientBeta11_dbFrechet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materie_uilocalhostBeta11_dbRiemann]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materie_uilocalhostBeta11_dbRiemann](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materie_uiwebBeta11_dbRiemann]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materie_uiwebBeta11_dbRiemann](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materie_webBeta11_dbFrechet]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materie_webBeta11_dbFrechet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrimeData_Frechet]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrimeData_Frechet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrimeDataRiemann]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrimeDataRiemann](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TracciatoConData]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TracciatoConData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[when] [varchar](50) NOT NULL,
	[row_nature] [char](3) NOT NULL,
	[stack_depth] [varchar](5) NOT NULL,
	[function_name] [varchar](50) NOT NULL,
	[content] [varchar](7919) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[createLogTable]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE         procedure [dbo].[createLogTable]
    @logname char(50)
as

IF OBJECT_ID(@logname) IS NULL
BEGIN

declare @cmd varchar( 8000)

    SET @cmd = '
            CREATE TABLE Logging..'+@logname+' (

    [id] [int] IDENTITY (1, 1) NOT NULL ,
    [when] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [row_nature] char(3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [stack_depth] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [function_name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [content] varchar(7919) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    PRIMARY KEY  CLUSTERED
    (
        [id]
    )  ON [PRIMARY] 
    ) ON [PRIMARY]'
-- cmd text ready
    exec (@cmd)
END
-- else table already exists

 
GO
/****** Object:  StoredProcedure [dbo].[trace]    Script Date: 10/13/2024 8:29:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE         procedure [dbo].[trace]
            @logname char(50),
            @when varchar(50),
            @row_nature char(3),
            @stack_depth varchar(5),
            @function_name varchar(50),
            @content varchar(7971)
      as
        declare @cmd char(8000)
        IF OBJECT_ID('Logging..'+@logname) IS NOT NULL
        BEGIN
    SET @cmd = 'insert into Logging..'+
    @logname+'(
    [when],
    [row_nature],
    [stack_depth],
    [function_name],
    [content] 	  ) values('+
        @when+', '+
        @row_nature+', '+
        @stack_depth+', '+
        @function_name+', '+
        @content+  ' )'
 -- print @cmd  debug only
 exec (@cmd)
 end
     /*
         else
         begin
         -- required table not found -> do nothing
         END
     */
 		
 
GO
