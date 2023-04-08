using SistemaVendas.Dados;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Net.Security;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaVendas
{
    public partial class FormVendas : Form
    {
        Vendas vendas = new Vendas(); //objeto vendas
        List<string> listaVendaProdutos = new List<string>(); //lista de Vendas
        VendasDAO vendasDAO = new VendasDAO(); //ligação com o banco de dados

        public FormVendas()
        {
            InitializeComponent();
        }

        #region "Funções Locais"

        public static string NomedoEvento()
        {
            string evento = "-------" + "\n";
            //evento += "Show de Prêmios da Carminha\n";
            //evento += "em prol da APAE Pinhal\n";
            evento += "Data/Hora: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            return evento;
        }

        private void CalculaValorTotalVenda()
        {
            vendas.valorVenda = (vendas.produto01 * vendas.val_produto01) +
                                (vendas.produto02 * vendas.val_produto02) +
                                (vendas.produto03 * vendas.val_produto03) +
                                (vendas.produto04 * vendas.val_produto04) +
                                (vendas.produto05 * vendas.val_produto05) +
                                (vendas.produto06 * vendas.val_produto06) +
                                (vendas.produto07 * vendas.val_produto07) +
                                (vendas.produto08 * vendas.val_produto08) +
                                (vendas.produto09 * vendas.val_produto09) +
                                (vendas.produto10 * vendas.val_produto20) +
                                (vendas.produto11 * vendas.val_produto11) +
                                (vendas.produto12 * vendas.val_produto12) +
                                (vendas.produto13 * vendas.val_produto13) +
                                (vendas.produto14 * vendas.val_produto14) +
                                (vendas.produto15 * vendas.val_produto15) +
                                (vendas.produto16 * vendas.val_produto16) +
                                (vendas.produto17 * vendas.val_produto17) +
                                (vendas.produto18 * vendas.val_produto18) +
                                (vendas.produto19 * vendas.val_produto19) +
                                (vendas.produto20 * vendas.val_produto20);
            textBox_TotalVenda.Text = string.Format("{0:0.00}", vendas.valorVenda);


            txtbox_valor_produto01.Text = string.Format("{0:0.00}", (vendas.produto01 * vendas.val_produto01));
            txtbox_valor_produto02.Text = string.Format("{0:0.00}", (vendas.produto02 * vendas.val_produto02));
            txtbox_valor_produto03.Text = string.Format("{0:0.00}", (vendas.produto03 * vendas.val_produto03));
            txtbox_valor_produto04.Text = string.Format("{0:0.00}", (vendas.produto04 * vendas.val_produto04));
            txtbox_valor_produto05.Text = string.Format("{0:0.00}", (vendas.produto05 * vendas.val_produto05));
            txtbox_valor_produto06.Text = string.Format("{0:0.00}", (vendas.produto06 * vendas.val_produto06));
            txtbox_valor_produto07.Text = string.Format("{0:0.00}", (vendas.produto07 * vendas.val_produto07));
            txtbox_valor_produto08.Text = string.Format("{0:0.00}", (vendas.produto08 * vendas.val_produto08));
            txtbox_valor_produto09.Text = string.Format("{0:0.00}", (vendas.produto09 * vendas.val_produto09));
            txtbox_valor_produto10.Text = string.Format("{0:0.00}", (vendas.produto10 * vendas.val_produto10));
            txtbox_valor_produto11.Text = string.Format("{0:0.00}", (vendas.produto11 * vendas.val_produto11));
            txtbox_valor_produto12.Text = string.Format("{0:0.00}", (vendas.produto12 * vendas.val_produto12));
            txtbox_valor_produto13.Text = string.Format("{0:0.00}", (vendas.produto13 * vendas.val_produto13));
            txtbox_valor_produto14.Text = string.Format("{0:0.00}", (vendas.produto14 * vendas.val_produto14));
            txtbox_valor_produto15.Text = string.Format("{0:0.00}", (vendas.produto15 * vendas.val_produto15));
            txtbox_valor_produto16.Text = string.Format("{0:0.00}", (vendas.produto16 * vendas.val_produto16));
            txtbox_valor_produto17.Text = string.Format("{0:0.00}", (vendas.produto17 * vendas.val_produto17));
            txtbox_valor_produto18.Text = string.Format("{0:0.00}", (vendas.produto18 * vendas.val_produto18));
            txtbox_valor_produto19.Text = string.Format("{0:0.00}", (vendas.produto19 * vendas.val_produto19));
            txtbox_valor_produto20.Text = string.Format("{0:0.00}", (vendas.produto20 * vendas.val_produto20));
        }

        private void AtualizaTela()
        {
            //atualiza a quantidade dos produtos
            txtbox_qtd_produto01.Text = vendas.produto01.ToString();
            txtbox_qtd_produto02.Text = vendas.produto02.ToString();
            txtbox_qtd_produto03.Text = vendas.produto03.ToString();
            txtbox_qtd_produto04.Text = vendas.produto04.ToString();
            txtbox_qtd_produto05.Text = vendas.produto05.ToString();
            txtbox_qtd_produto06.Text = vendas.produto06.ToString();
            txtbox_qtd_produto07.Text = vendas.produto07.ToString();
            txtbox_qtd_produto08.Text = vendas.produto08.ToString();
            txtbox_qtd_produto09.Text = vendas.produto09.ToString();
            txtbox_qtd_produto10.Text = vendas.produto10.ToString();
            txtbox_qtd_produto11.Text = vendas.produto11.ToString();
            txtbox_qtd_produto12.Text = vendas.produto12.ToString();
            txtbox_qtd_produto13.Text = vendas.produto13.ToString();
            txtbox_qtd_produto14.Text = vendas.produto14.ToString();
            txtbox_qtd_produto15.Text = vendas.produto15.ToString();
            txtbox_qtd_produto16.Text = vendas.produto16.ToString();
            txtbox_qtd_produto17.Text = vendas.produto17.ToString();
            txtbox_qtd_produto18.Text = vendas.produto18.ToString();
            txtbox_qtd_produto19.Text = vendas.produto19.ToString();
            txtbox_qtd_produto20.Text = vendas.produto20.ToString();

            CalculaValorTotalVenda();

            //atualiza os items vendidos na tela
            AtualizaCupomVenda();
        }

        private void AtualizaCupomVenda()
        {
            listBoxVenda.DataSource = null;
            listBoxVenda.DataSource = listaVendaProdutos;
        }

        private void AtualizaControlesVendaAndamento()
        {
            //altera o controle dos botões 
            btn_NOVAVENDA.Enabled = false;
            btn_CANCELAVENDA.Enabled = true;
            btn_GRAVARVENDA.Enabled = true;
            btn_impressao.Enabled = true;
        }

        private void AtualizaControlesParaNovaVenda()
        {
            //altera o controle dos botões 
            btn_NOVAVENDA.Enabled = true;
            btn_CANCELAVENDA.Enabled = false;
            btn_GRAVARVENDA.Enabled = false;
            btn_impressao.Enabled = false;
        }

        private void ZeraQuantidadeProdutos()
        {
            //zera a quantidade dos produtos
            vendas.produto01 = 0;
            vendas.produto02 = 0;
            vendas.produto03 = 0;
            vendas.produto04 = 0;
            vendas.produto05 = 0;
            vendas.produto06 = 0;
            vendas.produto07 = 0;
            vendas.produto08 = 0;
            vendas.produto09 = 0;
            vendas.produto10 = 0;
            vendas.produto11 = 0;
            vendas.produto12 = 0;
            vendas.produto13 = 0;
            vendas.produto14 = 0;
            vendas.produto15 = 0;
            vendas.produto16 = 0;
            vendas.produto17 = 0;
            vendas.produto18 = 0;
            vendas.produto19 = 0;
            vendas.produto20 = 0;
        }

        private void DefineValorProdutos()
        {
            //zera o valor dos produtos
            vendas.val_produto01 = 6;
            vendas.val_produto02 = 6;
            vendas.val_produto03 = 6;
            vendas.val_produto04 = 8;
            vendas.val_produto05 = 8;
            vendas.val_produto06 = 3;
            vendas.val_produto07 = 4;
            vendas.val_produto08 = 0;
            vendas.val_produto09 = 0;
            vendas.val_produto10 = 0;
            vendas.val_produto11 = 10;
            vendas.val_produto12 = 0;
            vendas.val_produto13 = 10;
            vendas.val_produto14 = 10;
            vendas.val_produto15 = 15;
            vendas.val_produto16 = 0;
            vendas.val_produto17 = 0;
            vendas.val_produto18 = 0;
            vendas.val_produto19 = 5;
            vendas.val_produto20 = 2;

            txtbox_valor_produto01.Text = string.Format("{0:0.00}", vendas.val_produto01);
            txtbox_valor_produto02.Text = string.Format("{0:0.00}", vendas.val_produto02);
            txtbox_valor_produto03.Text = string.Format("{0:0.00}", vendas.val_produto03);
            txtbox_valor_produto04.Text = string.Format("{0:0.00}", vendas.val_produto04);
            txtbox_valor_produto05.Text = string.Format("{0:0.00}", vendas.val_produto05);
            txtbox_valor_produto06.Text = string.Format("{0:0.00}", vendas.val_produto06);
            txtbox_valor_produto07.Text = string.Format("{0:0.00}", vendas.val_produto07);
            txtbox_valor_produto08.Text = string.Format("{0:0.00}", vendas.val_produto08);
            txtbox_valor_produto09.Text = string.Format("{0:0.00}", vendas.val_produto09);
            txtbox_valor_produto10.Text = string.Format("{0:0.00}", vendas.val_produto10);
            txtbox_valor_produto11.Text = string.Format("{0:0.00}", vendas.val_produto11);
            txtbox_valor_produto12.Text = string.Format("{0:0.00}", vendas.val_produto12);
            txtbox_valor_produto13.Text = string.Format("{0:0.00}", vendas.val_produto13);
            txtbox_valor_produto14.Text = string.Format("{0:0.00}", vendas.val_produto14);
            txtbox_valor_produto15.Text = string.Format("{0:0.00}", vendas.val_produto15);
            txtbox_valor_produto16.Text = string.Format("{0:0.00}", vendas.val_produto16);
            txtbox_valor_produto17.Text = string.Format("{0:0.00}", vendas.val_produto17);
            txtbox_valor_produto18.Text = string.Format("{0:0.00}", vendas.val_produto18);
            txtbox_valor_produto19.Text = string.Format("{0:0.00}", vendas.val_produto19);
            txtbox_valor_produto20.Text = string.Format("{0:0.00}", vendas.val_produto20);
        }

        private void DesabilitaBotoesProdutos()
        {
            //desabilita o click nos botões de produtos
            btn_produto01.Enabled = false;
            btn_produto02.Enabled = false;
            btn_produto03.Enabled = false;
            btn_produto04.Enabled = false;
            btn_produto05.Enabled = false;
            btn_produto06.Enabled = false;
            btn_produto07.Enabled = false;
            btn_produto08.Enabled = false;
            btn_produto09.Enabled = false;
            btn_produto10.Enabled = false;
            btn_produto11.Enabled = false;
            btn_produto12.Enabled = false;
            btn_produto13.Enabled = false;
            btn_produto14.Enabled = false;
            btn_produto15.Enabled = false;
            btn_produto16.Enabled = false;
            btn_produto17.Enabled = false;
            btn_produto18.Enabled = false;
            btn_produto19.Enabled = false;
            btn_produto20.Enabled = false;
        }

        private void HabilitaBotoesProdutos()
        {
            btn_produto01.Enabled = true;
            btn_produto02.Enabled = true;
            btn_produto03.Enabled = true;
            btn_produto04.Enabled = true;
            btn_produto05.Enabled = true;
            btn_produto06.Enabled = true;
            btn_produto07.Enabled = true;
            btn_produto08.Enabled = true;
            btn_produto09.Enabled = true;
            btn_produto10.Enabled = true;
            btn_produto11.Enabled = true;
            btn_produto12.Enabled = true;
            btn_produto13.Enabled = true;
            btn_produto14.Enabled = true;
            btn_produto15.Enabled = true;
            btn_produto16.Enabled = true;
            btn_produto17.Enabled = true;
            btn_produto18.Enabled = true;
            btn_produto19.Enabled = true;
            btn_produto20.Enabled = true;
        }

        private void DesabilitaFormasPagamento()
        {
            checkBox_PIX.Checked = false;
            checkBox_PIX.Enabled = false;

            checkBox_CARTAO.Checked = false;
            checkBox_CARTAO.Enabled = false;

            checkBox_Dinheiro.Checked = false;
            checkBox_Dinheiro.Enabled = false;

            txtbox_DINHEIRO.Text = string.Empty;

            textBox_Troco.Text = string.Empty;

            DesabilitaPagamentoDinheiro();
        }

        private void DesabilitaPagamentoDinheiro()
        {
            txtbox_DINHEIRO.Enabled = false;

            btn_1real.Enabled = false;
            btn_2reais.Enabled = false;
            btn_5reais.Enabled = false;
            btn_10reais.Enabled = false;
            btn_20reais.Enabled = false;
            btn_50reais.Enabled = false;
            btn_100reais.Enabled = false;
            btn_200reais.Enabled = false;
            btn_05_centavos.Enabled = false;
            btn_10_centavos.Enabled = false;
            btn_25_centavos.Enabled = false;
            btn_50_centavos.Enabled = false;

            btn_ApagarValorDinheiro.Enabled = false;
        }

        private void HabilitaFormasPagamento()
        {
            checkBox_PIX.Checked = false;
            checkBox_PIX.Enabled = true;

            checkBox_CARTAO.Checked = false;
            checkBox_CARTAO.Enabled = true;

            checkBox_Dinheiro.Checked = false;
            checkBox_Dinheiro.Enabled = true;

            txtbox_DINHEIRO.Text = string.Empty;

            textBox_Troco.Text = string.Empty;

            btn_GRAVARVENDA.BackColor = Color.Gray;
            btn_GRAVARVENDA.Enabled = false;
        }

        private void HabilitaPagamentoDinheiro()
        {
            //txtbox_DINHEIRO.Enabled = true;

            btn_1real.Enabled = true;
            btn_2reais.Enabled = true;
            btn_5reais.Enabled = true;
            btn_10reais.Enabled = true;
            btn_20reais.Enabled = true;
            btn_50reais.Enabled = true;
            btn_100reais.Enabled = true;
            btn_200reais.Enabled = true;
            btn_05_centavos.Enabled = true;
            btn_10_centavos.Enabled = true;
            btn_25_centavos.Enabled = true;
            btn_50_centavos.Enabled = true;

            btn_ApagarValorDinheiro.Enabled = true;
        }

        private void LimpaTelaCupom()
        {
            // limpar a tela de impressão
            listaVendaProdutos.Clear();
            listBoxVenda.DataSource = null;
            listBoxVenda.DataSource = listaVendaProdutos;
        }

        private void NovaVenda()
        {
            AtualizaControlesVendaAndamento();

            ZeraQuantidadeProdutos();

            HabilitaBotoesProdutos();

            HabilitaFormasPagamento();

            LimpaTelaCupom();
        }

        private void CancelarVenda()
        {
            AtualizaControlesParaNovaVenda();

            ZeraQuantidadeProdutos();

            DesabilitaBotoesProdutos();

            DesabilitaFormasPagamento();

            LimpaTelaCupom();
        }

        private void GravarVenda()
        {
            AtualizaControlesParaNovaVenda();

            ZeraQuantidadeProdutos();

            DesabilitaBotoesProdutos();

            DesabilitaFormasPagamento();

            LimpaTelaCupom();
        }

        #endregion

        #region "Banco de Dados"
        private void AbrirVendaBD()
        {
            vendas.nomeTerminalVenda = "PDV01";
            vendas.statusVenda = "Aberta";
            vendas.dataHoraInicioVenda = DateTime.Now;
            DateTime sqlMinDateAsNetDateTime = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            vendas.dataHoraEncerraVenda = sqlMinDateAsNetDateTime;

            txtbox_VENDA.Text = vendasDAO.GravarVenda(vendas).ToString();
        }

        private void CancelarVendasBD()
        {
            vendas.nomeTerminalVenda = "PDV01";
            vendas.statusVenda = "Cancelada";
            vendas.dataHoraEncerraVenda = DateTime.Now;

            vendasDAO.AtualizarVenda(vendas);

            txtbox_VENDA.Text = "";
        }

        private void GravarVendaBD()
        {
            vendas.nomeTerminalVenda = "PDV01";
            vendas.statusVenda = "Finalizada";
            vendas.dataHoraEncerraVenda = DateTime.Now;


            vendasDAO.AtualizarVenda(vendas);

            txtbox_VENDA.Text = "";
        }

        #endregion

        #region "Produtos"

        private void btn_produto01_Click(object sender, EventArgs e)
        {
            vendas.produto01 += 1;

            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto01;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            //listaVendaProdutos.Add(nomeProduto + "\n\n");
            //listaVendaProdutos.Add(NomedoEvento());
            //AtualizaTela();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto02_Click(object sender, EventArgs e)
        {
            vendas.produto02 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto02;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto03_Click(object sender, EventArgs e)
        {
            vendas.produto03 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto03;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto04_Click(object sender, EventArgs e)
        {
            vendas.produto04 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto04;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto05_Click(object sender, EventArgs e)
        {
            vendas.produto05 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto05;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto06_Click(object sender, EventArgs e)
        {
            vendas.produto06 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto06;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto07_Click(object sender, EventArgs e)
        {
            vendas.produto07 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto07;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto08_Click(object sender, EventArgs e)
        {
            vendas.produto08 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto08;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto09_Click(object sender, EventArgs e)
        {
            vendas.produto09 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto09;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto10_Click(object sender, EventArgs e)
        {
            vendas.produto10 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto10;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto11_Click(object sender, EventArgs e)
        {
            vendas.produto11 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto11;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto12_Click(object sender, EventArgs e)
        {
            vendas.produto12 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto12;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto13_Click(object sender, EventArgs e)
        {
            vendas.produto13 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto13;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto14_Click(object sender, EventArgs e)
        {
            vendas.produto14 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto14;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto15_Click(object sender, EventArgs e)
        {
            vendas.produto15 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto15;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto16_Click(object sender, EventArgs e)
        {
            vendas.produto16 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto16;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto17_Click(object sender, EventArgs e)
        {
            vendas.produto17 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto17;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto18_Click(object sender, EventArgs e)
        {
            vendas.produto18 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto18;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto19_Click(object sender, EventArgs e)
        {
            vendas.produto19 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto19;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        private void btn_produto20_Click(object sender, EventArgs e)
        {
            vendas.produto20 += 1;
            EnumProdutos.Produtos enumProdutos = EnumProdutos.Produtos.produto20;
            string nomeProduto = typeof(EnumProdutos.Produtos).GetMember(enumProdutos.ToString())[0]
                                                              .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumProdutos.ToString();

            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add(nomeProduto);
            listaVendaProdutos.Add("");
            listaVendaProdutos.Add("............................");
            AtualizaTela();
        }

        #endregion

        #region "Operações de Venda"

        private void btn_NOVAVENDA_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirVendaBD(); //grava no banco de dados a venda com status Aberta

                NovaVenda(); //limpa todos os controles e altera status botões

                listaVendaProdutos.Add("-----------------------------------");
                listaVendaProdutos.Add("   SHOW DE PRÊMIOS   ");
                listaVendaProdutos.Add("---DA CARMINHA 2023---");
                listaVendaProdutos.Add("-----------------------------------");

                AtualizaCupomVenda(); //atualiza novamente o cupom da venda
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_CANCELAVENDA_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarVendasBD();

                CancelarVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_GRAVARVENDA_Click(object sender, EventArgs e)
        {
            try
            {
                GravarVendaBD();

                GravarVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_impressao_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btn_GRAVARVENDA.BackColor = Color.Green;
            btn_GRAVARVENDA.Enabled = true;

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            for (int i = 0; i < listBoxVenda.Items.Count; i++)
            {
                //e.Graphics.DrawString(listBoxVenda.Items[i].ToString(), new Font("Arial", 14), Brushes.Black, 50, 50 + i * 20);

                float yPos = 0f;
                int count = 0;

                foreach (var item in listBoxVenda.Items)
                {
                    yPos = count * 20;

                    e.Graphics.DrawString(item.ToString(), new Font("Arial", 14), Brushes.Black, 20, yPos);

                    count++;
                }
            }
        }

        #endregion

        #region "Formas Pagamento"

        private void checkBox_PIX_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PIX.Checked)
            {
                vendas.pix = true;
                vendas.valorPago = vendas.valorVenda;
                txtValorTotal.Text = string.Format("{0:0.00}", vendas.valorPago);
            }
            else
            {
                vendas.pix = false;
                vendas.valorPago = 0;
                txtValorTotal.Text = string.Empty;
            }
        }

        private void checkBox_CARTAO_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_CARTAO.Checked)
            {
                vendas.cartao = true;
                vendas.valorPago = vendas.valorVenda;
                txtValorTotal.Text = string.Format("{0:0.00}", vendas.valorPago);
            }
            else
            {
                vendas.cartao = false;
                vendas.valorPago = 0;
                txtValorTotal.Text = string.Empty;
            }
        }

        private void checkBox_Dinheiro_CheckedChanged(object sender, EventArgs e)
        {
            vendas.dinheiro = true;
            txtbox_DINHEIRO.Enabled = true;

            if (checkBox_Dinheiro.Checked)
            {
                HabilitaPagamentoDinheiro();
                vendas.dinheiro = true;
                vendas.valorPago = vendas.valorVenda;
                txtValorTotal.Text = string.Format("{0:0.00}", vendas.valorPago);

                //textBox_Troco.Text = "0";
                //double troco = double.Parse(txtbox_DINHEIRO.Text) - double.Parse(txtValorTotal.Text);
                //textBox_Troco.Text = string.Format("{0:0.00}", troco.ToString());

            }
            else
            {
                DesabilitaPagamentoDinheiro();
            }
        }

        private double Int16(string text)
        {
            throw new NotImplementedException();
        }

        private int Int32(string text)
        {
            throw new NotImplementedException();
        }

        private void btn_1real_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 1;
        }

        private void btn_2reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 2;
        }

        private void btn_5reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 5;
        }

        private void btn_10reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 10;
        }

        private void btn_20reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 20;
        }

        private void btn_50reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 50;
        }

        private void btn_100reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 100;
        }

        private void btn_200reais_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 200;
        }

        private void btn_05_centavos_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 0.05;
        }

        private void btn_10_centavos_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 0.10;
        }

        private void btn_25_centavos_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 0.25;
        }

        private void btn_50_centavos_Click(object sender, EventArgs e)
        {
            vendas.valorPago += 0.50;
        }
        private void btn_ApagarValorDinheiro_Click(object sender, EventArgs e)
        {
            vendas.valorPago = 0;
            txtbox_DINHEIRO.Text = string.Empty;
        }

        #endregion

        private void FormVendas_Load(object sender, EventArgs e)
        {
            btn_produto01.Text = "REFRIGERANTE";
            btn_produto02.Text = "COCA COLA ZERO";
            btn_produto03.Text = "CERVEJA SKOL/BRAHMA";
            btn_produto04.Text = "CERVEJA HEINEKEN";
            btn_produto05.Text = "CERVEJA SEM ÁLCOOL";
            btn_produto06.Text = "ÁGUA SEM GÁS";
            btn_produto07.Text = "ÁGUA COM GÁS";
            btn_produto08.Text = "Produto 08";
            btn_produto09.Text = "Produto 09";
            btn_produto10.Text = "Produto 10";
            btn_produto11.Text = "BOLO NO POTE";
            btn_produto12.Text = "BOLO SALGADO";
            btn_produto13.Text = "SANDUÍCHE DE PERNIL";
            btn_produto14.Text = "CACHORRO QUENTE";
            btn_produto15.Text = "PORÇÃO DE SALGADINHOS";
            btn_produto16.Text = "COXINHA";
            btn_produto17.Text = "Produto 17";
            btn_produto18.Text = "Produto 18";
            btn_produto19.Text = "BRINQUEDOS";
            btn_produto20.Text = "CANETA BIC";

            DefineValorProdutos();
        }

        
    }
}