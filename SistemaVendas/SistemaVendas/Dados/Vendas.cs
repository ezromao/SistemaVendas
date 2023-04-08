using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dados
{
    public class Vendas 
    {
        public int numeroVenda { get; set; }
        public int produto01 { get; set; }
        public int produto02 { get; set; }
        public int produto03 { get; set; }
        public int produto04 { get; set; }
        public int produto05 { get; set; }
        public int produto06 { get; set; }
        public int produto07 { get; set; }
        public int produto08 { get; set; }
        public int produto09 { get; set; }
        public int produto10 { get; set; }
        public int produto11 { get; set; }
        public int produto12 { get; set; }
        public int produto13 { get; set; }
        public int produto14 { get; set; }
        public int produto15 { get; set; }
        public int produto16 { get; set; }
        public int produto17 { get; set; }
        public int produto18 { get; set; }
        public int produto19 { get; set; }
        public int produto20 { get; set; }

        public int val_produto01 { get; set; }
        public int val_produto02 { get; set; }
        public int val_produto03 { get; set; }
        public int val_produto04 { get; set; }
        public int val_produto05 { get; set; }
        public int val_produto06 { get; set; }
        public int val_produto07 { get; set; }
        public int val_produto08 { get; set; }
        public int val_produto09 { get; set; }
        public int val_produto10 { get; set; }
        public int val_produto11 { get; set; }
        public int val_produto12 { get; set; }
        public int val_produto13 { get; set; }
        public int val_produto14 { get; set; }
        public int val_produto15 { get; set; }
        public int val_produto16 { get; set; }
        public int val_produto17 { get; set; }
        public int val_produto18 { get; set; }
        public int val_produto19 { get; set; }
        public int val_produto20 { get; set; }

        public Boolean pix { get; set; }
        public Boolean cartao { get; set; }
        public Boolean dinheiro { get; set; }
        public double valorVenda { get; set; }
        public double valorPago { get; set; }
        public double troco { get; set;}
        public DateTime dataHoraInicioVenda { get; set; }
        public DateTime dataHoraEncerraVenda { get; set; }
        public String? nomeTerminalVenda { get; set; }
        public String? statusVenda { get; set; }
    }
}
