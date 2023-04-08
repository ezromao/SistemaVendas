using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dados
{
    public class VendasDAO
    {
        readonly string connectionString = "Data Source=ezDell\\SQLEXPRESS;Initial Catalog=SistemaVendas;Persist Security Info=True;User ID=sa;Password=1122345678";

        public void AtualizarVenda(Vendas vendas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Vendas SET " +
                               "[produto01] = @produto01, [produto02] = @produto02, [produto03] = @produto03, [produto04] = @produto04, [produto05] = @produto05, " +
                               "[produto06] = @produto06, [produto07] = @produto07, [produto08] = @produto08, [produto09] = @produto09, [produto10] = @produto10, " +
                               "[produto11] = @produto11, [produto12] = @produto12, [produto13] = @produto13, [produto14] = @produto14, [produto15] = @produto15, " +
                               "[produto16] = @produto16, [produto17] = @produto17, [produto18] = @produto18, [produto19] = @produto19, [produto20] = @produto20, " +
                               "[val_produto01] = @val_produto01, [val_produto02] = @val_produto02, [val_produto03] = @val_produto03, [val_produto04] = @val_produto04, [val_produto05] = @val_produto05, " +
                               "[val_produto06] = @val_produto06, [val_produto07] = @val_produto07, [val_produto08] = @val_produto08, [val_produto09] = @val_produto09, [val_produto10] = @val_produto10, " +
                               "[val_produto11] = @val_produto11, [val_produto12] = @val_produto12, [val_produto13] = @val_produto13, [val_produto14] = @val_produto14, [val_produto15] = @val_produto15, " +
                               "[val_produto16] = @val_produto16, [val_produto17] = @val_produto17, [val_produto18] = @val_produto18, [val_produto19] = @val_produto19, [val_produto20] = @val_produto20, " +
                               "[pix] = @pix, [cartao] = @cartao, [dinheiro] = @dinheiro, [valorVenda] = @valorVenda, [valorPago] = @valorPago, [troco] = @troco, " +
                               "[dataHoraInicioVenda] = @dataHoraInicioVenda, [dataHoraEncerraVenda] = @dataHoraEncerraVenda, " +
                               "[nomeTerminalVenda] = @nomeTerminalVenda, [statusVenda] = @statusVenda " +
                               "WHERE [numeroVenda] = @numeroVenda";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@produto01", vendas.produto01);
                command.Parameters.AddWithValue("@produto02", vendas.produto02);
                command.Parameters.AddWithValue("@produto03", vendas.produto03);
                command.Parameters.AddWithValue("@produto04", vendas.produto04);
                command.Parameters.AddWithValue("@produto05", vendas.produto05);
                command.Parameters.AddWithValue("@produto06", vendas.produto06);
                command.Parameters.AddWithValue("@produto07", vendas.produto07);
                command.Parameters.AddWithValue("@produto08", vendas.produto08);
                command.Parameters.AddWithValue("@produto09", vendas.produto09);
                command.Parameters.AddWithValue("@produto10", vendas.produto10);
                command.Parameters.AddWithValue("@produto11", vendas.produto11);
                command.Parameters.AddWithValue("@produto12", vendas.produto12);
                command.Parameters.AddWithValue("@produto13", vendas.produto13);
                command.Parameters.AddWithValue("@produto14", vendas.produto14);
                command.Parameters.AddWithValue("@produto15", vendas.produto15);
                command.Parameters.AddWithValue("@produto16", vendas.produto16);
                command.Parameters.AddWithValue("@produto17", vendas.produto17);
                command.Parameters.AddWithValue("@produto18", vendas.produto18);
                command.Parameters.AddWithValue("@produto19", vendas.produto19);
                command.Parameters.AddWithValue("@produto20", vendas.produto20);

                command.Parameters.AddWithValue("@val_produto01", vendas.val_produto01);
                command.Parameters.AddWithValue("@val_produto02", vendas.val_produto02);
                command.Parameters.AddWithValue("@val_produto03", vendas.val_produto03);
                command.Parameters.AddWithValue("@val_produto04", vendas.val_produto04);
                command.Parameters.AddWithValue("@val_produto05", vendas.val_produto05);
                command.Parameters.AddWithValue("@val_produto06", vendas.val_produto06);
                command.Parameters.AddWithValue("@val_produto07", vendas.val_produto07);
                command.Parameters.AddWithValue("@val_produto08", vendas.val_produto08);
                command.Parameters.AddWithValue("@val_produto09", vendas.val_produto09);
                command.Parameters.AddWithValue("@val_produto10", vendas.val_produto10);
                command.Parameters.AddWithValue("@val_produto11", vendas.val_produto11);
                command.Parameters.AddWithValue("@val_produto12", vendas.val_produto12);
                command.Parameters.AddWithValue("@val_produto13", vendas.val_produto13);
                command.Parameters.AddWithValue("@val_produto14", vendas.val_produto14);
                command.Parameters.AddWithValue("@val_produto15", vendas.val_produto15);
                command.Parameters.AddWithValue("@val_produto16", vendas.val_produto16);
                command.Parameters.AddWithValue("@val_produto17", vendas.val_produto17);
                command.Parameters.AddWithValue("@val_produto18", vendas.val_produto18);
                command.Parameters.AddWithValue("@val_produto19", vendas.val_produto19);
                command.Parameters.AddWithValue("@val_produto20", vendas.val_produto20);

                command.Parameters.AddWithValue("@pix", vendas.pix);
                command.Parameters.AddWithValue("@cartao", vendas.cartao);
                command.Parameters.AddWithValue("@dinheiro", vendas.dinheiro);
                command.Parameters.AddWithValue("@valorVenda", vendas.valorVenda);
                command.Parameters.AddWithValue("@valorPago", vendas.valorPago);
                command.Parameters.AddWithValue("@troco", vendas.troco);
                command.Parameters.AddWithValue("@dataHoraInicioVenda", vendas.dataHoraInicioVenda);
                command.Parameters.AddWithValue("@dataHoraEncerraVenda", vendas.dataHoraEncerraVenda);
                command.Parameters.AddWithValue("@nomeTerminalVenda", vendas.nomeTerminalVenda);
                command.Parameters.AddWithValue("@statusVenda", vendas.statusVenda);
                command.Parameters.AddWithValue("@numeroVenda", vendas.numeroVenda);


                connection.Open();
                Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GravarVenda(Vendas vendas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Vendas " +
                               "([produto01],[produto02],[produto03],[produto04],[produto05],[produto06],[produto07],[produto08],[produto09],[produto10]" +
                               ",[produto11],[produto12],[produto13],[produto14],[produto15],[produto16],[produto17],[produto18],[produto19],[produto20]" +
                               ",[val_produto01],[val_produto02],[val_produto03],[val_produto04],[val_produto05],[val_produto06],[val_produto07],[val_produto08]" +
                               ",[val_produto09],[val_produto10],[val_produto11],[val_produto12],[val_produto13],[val_produto14],[val_produto15],[val_produto16]" +
                               ",[val_produto17],[val_produto18],[val_produto19],[val_produto20],[pix],[cartao],[dinheiro],[valorVenda],[valorPago],[troco],[dataHoraInicioVenda]" +
                               ",[dataHoraEncerraVenda],[nomeTerminalVenda],[statusVenda])" +
                               "VALUES" +
                               "(@produto01,@produto02,@produto03,@produto04,@produto05,@produto06,@produto07,@produto08,@produto09,@produto10" +
                               ",@produto11,@produto12,@produto13,@produto14,@produto15,@produto16,@produto17,@produto18,@produto19,@produto20" +
                               ",@val_produto01,@val_produto02,@val_produto03,@val_produto04,@val_produto05,@val_produto06,@val_produto07,@val_produto08" +
                               ",@val_produto09,@val_produto10,@val_produto11,@val_produto12,@val_produto13,@val_produto14,@val_produto15,@val_produto16" +
                               ",@val_produto17,@val_produto18,@val_produto19,@val_produto20,@pix,@cartao,@dinheiro,@valorVenda,@valorPago,@troco,@dataHoraInicioVenda" +
                               ",@dataHoraEncerraVenda,@nomeTerminalVenda,@statusVenda)" +
                               "SELECT SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@produto01", vendas.produto01);
                command.Parameters.AddWithValue("@produto02", vendas.produto02);
                command.Parameters.AddWithValue("@produto03", vendas.produto03);
                command.Parameters.AddWithValue("@produto04", vendas.produto04);
                command.Parameters.AddWithValue("@produto05", vendas.produto05);
                command.Parameters.AddWithValue("@produto06", vendas.produto06);
                command.Parameters.AddWithValue("@produto07", vendas.produto07);
                command.Parameters.AddWithValue("@produto08", vendas.produto08);
                command.Parameters.AddWithValue("@produto09", vendas.produto09);
                command.Parameters.AddWithValue("@produto10", vendas.produto10);
                command.Parameters.AddWithValue("@produto11", vendas.produto11);
                command.Parameters.AddWithValue("@produto12", vendas.produto12);
                command.Parameters.AddWithValue("@produto13", vendas.produto13);
                command.Parameters.AddWithValue("@produto14", vendas.produto14);
                command.Parameters.AddWithValue("@produto15", vendas.produto15);
                command.Parameters.AddWithValue("@produto16", vendas.produto16);
                command.Parameters.AddWithValue("@produto17", vendas.produto17);
                command.Parameters.AddWithValue("@produto18", vendas.produto18);
                command.Parameters.AddWithValue("@produto19", vendas.produto19);
                command.Parameters.AddWithValue("@produto20", vendas.produto20);

                command.Parameters.AddWithValue("@val_produto01", vendas.val_produto01);
                command.Parameters.AddWithValue("@val_produto02", vendas.val_produto02);
                command.Parameters.AddWithValue("@val_produto03", vendas.val_produto03);
                command.Parameters.AddWithValue("@val_produto04", vendas.val_produto04);
                command.Parameters.AddWithValue("@val_produto05", vendas.val_produto05);
                command.Parameters.AddWithValue("@val_produto06", vendas.val_produto06);
                command.Parameters.AddWithValue("@val_produto07", vendas.val_produto07);
                command.Parameters.AddWithValue("@val_produto08", vendas.val_produto08);
                command.Parameters.AddWithValue("@val_produto09", vendas.val_produto09);
                command.Parameters.AddWithValue("@val_produto10", vendas.val_produto10);
                command.Parameters.AddWithValue("@val_produto11", vendas.val_produto11);
                command.Parameters.AddWithValue("@val_produto12", vendas.val_produto12);
                command.Parameters.AddWithValue("@val_produto13", vendas.val_produto13);
                command.Parameters.AddWithValue("@val_produto14", vendas.val_produto14);
                command.Parameters.AddWithValue("@val_produto15", vendas.val_produto15);
                command.Parameters.AddWithValue("@val_produto16", vendas.val_produto16);
                command.Parameters.AddWithValue("@val_produto17", vendas.val_produto17);
                command.Parameters.AddWithValue("@val_produto18", vendas.val_produto18);
                command.Parameters.AddWithValue("@val_produto19", vendas.val_produto19);
                command.Parameters.AddWithValue("@val_produto20", vendas.val_produto20);

                command.Parameters.AddWithValue("@pix", vendas.pix);
                command.Parameters.AddWithValue("@cartao", vendas.cartao);
                command.Parameters.AddWithValue("@dinheiro", vendas.dinheiro);
                command.Parameters.AddWithValue("@valorVenda", vendas.valorVenda);
                command.Parameters.AddWithValue("@valorPago", vendas.valorPago);
                command.Parameters.AddWithValue("@troco", vendas.troco);
                command.Parameters.AddWithValue("@dataHoraInicioVenda", vendas.dataHoraInicioVenda);
                command.Parameters.AddWithValue("@dataHoraEncerraVenda", vendas.dataHoraEncerraVenda);
                command.Parameters.AddWithValue("@nomeTerminalVenda", vendas.nomeTerminalVenda);
                command.Parameters.AddWithValue("@statusVenda", vendas.statusVenda);

                connection.Open();
                int VendaId = Convert.ToInt32(command.ExecuteScalar());
                vendas.numeroVenda = VendaId;

                return VendaId;
            }
        }
    }
}
