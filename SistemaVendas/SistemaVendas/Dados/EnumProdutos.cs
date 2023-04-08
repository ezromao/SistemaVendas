using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaVendas.Dados
{
    public class EnumProdutos
    {    
        public enum Produtos
        {
            [Display(Name = "REFRIGERANTE")]
            produto01,
            [Display(Name = "COCA ZERO")]
            produto02,
            [Display(Name = "SKOL/BRAHMA")]
            produto03,
            [Display(Name = "HEINEKEN")]
            produto04,
            [Display(Name = "HEINEKEN ZERO")]
            produto05,
            [Display(Name = "ÁGUA MINERAL")]
            produto06,
            [Display(Name = "ÁGUA C/ GÁS")]
            produto07,
            [Display(Name = "Produto 08")]
            produto08,
            [Display(Name = "Produto 09")]
            produto09,
            [Display(Name = "Produto 10")]
            produto10,
            [Display(Name = "BOLO POTE")]
            produto11,
            [Display(Name = "BOLO SALGADO")]
            produto12,
            [Display(Name = "SANDUÍCHE PERNIL")]
            produto13,
            [Display(Name = "CACHORRO QUENTE")]
            produto14,
            [Display(Name = "PORÇÃO SALGADOS")]
            produto15,
            [Display(Name = "COXINHA")]
            produto16,
            [Display(Name = "Produto 17")]
            produto17,
            [Display(Name = "Produto 18")]
            produto18,
            [Display(Name = "BRINQUEDOS")]
            produto19,
            [Display(Name = "CANETA BIC")]
            produto20
        }
    }
}
