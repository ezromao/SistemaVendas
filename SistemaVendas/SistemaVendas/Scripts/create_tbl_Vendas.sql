USE [SistemaVendas]
GO

/****** Object:  Table [dbo].[Vendas]    Script Date: 05/04/2023 12:40:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendas](
	[numeroVenda] [int] IDENTITY(1,1) NOT NULL,
	[produto01] [int] NULL,
	[produto02] [int] NULL,
	[produto03] [int] NULL,
	[produto04] [int] NULL,
	[produto05] [int] NULL,
	[produto06] [int] NULL,
	[produto07] [int] NULL,
	[produto08] [int] NULL,
	[produto09] [int] NULL,
	[produto10] [int] NULL,
	[produto11] [int] NULL,
	[produto12] [int] NULL,
	[produto13] [int] NULL,
	[produto14] [int] NULL,
	[produto15] [int] NULL,
	[produto16] [int] NULL,
	[produto17] [int] NULL,
	[produto18] [int] NULL,
	[produto19] [int] NULL,
	[produto20] [int] NULL,
	[val_produto01] [int] NULL,
	[val_produto02] [int] NULL,
	[val_produto03] [int] NULL,
	[val_produto04] [int] NULL,
	[val_produto05] [int] NULL,
	[val_produto06] [int] NULL,
	[val_produto07] [int] NULL,
	[val_produto08] [int] NULL,
	[val_produto09] [int] NULL,
	[val_produto10] [int] NULL,
	[val_produto11] [int] NULL,
	[val_produto12] [int] NULL,
	[val_produto13] [int] NULL,
	[val_produto14] [int] NULL,
	[val_produto15] [int] NULL,
	[val_produto16] [int] NULL,
	[val_produto17] [int] NULL,
	[val_produto18] [int] NULL,
	[val_produto19] [int] NULL,
	[val_produto20] [int] NULL,
	[pix] [bit] NULL,
	[cartao] [bit] NULL,
	[dinheiro] [bit] NULL,
	[valorVenda] [decimal](18, 2) NULL,
	[valorPago] [decimal](18, 2) NULL,
	[troco] [decimal](18, 2) NULL,
	[dataHoraInicioVenda] [datetime] NULL,
	[dataHoraEncerraVenda] [datetime] NULL,
	[nomeTerminalVenda] [nvarchar](50) NULL,
	[statusVenda] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vendas] PRIMARY KEY CLUSTERED 
(
	[numeroVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


