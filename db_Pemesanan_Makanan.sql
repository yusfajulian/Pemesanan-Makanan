USE [db_pemesanan_makanan]
GO
/****** Object:  Table [dbo].[tbl_akun]    Script Date: 1/9/2023 8:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_akun](
	[username] [varchar](20) NULL,
	[password] [varchar](20) NULL,
	[type] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_menu]    Script Date: 1/9/2023 8:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_menu](
	[nomor] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[harga] [float] NOT NULL,
	[jenis] [varchar](20) NOT NULL,
	[status] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tx_pesanan]    Script Date: 1/9/2023 8:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tx_pesanan](
	[nomor_pesanan] [varchar](15) NULL,
	[nomor_meja] [varchar](3) NULL,
	[makanan] [varchar](50) NULL,
	[minuman] [varchar](50) NULL,
	[status] [varchar](10) NULL
) ON [PRIMARY]
GO
