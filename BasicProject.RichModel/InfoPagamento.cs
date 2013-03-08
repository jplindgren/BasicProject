using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class InfoPagamento {
        public long Id { get; set; }
        public decimal ValorEntrada { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal ValorTotalPlano { get; set; }

        public InfoPagamento(int numeroParcelas, decimal valorEntrada, decimal valorTotal) {
            this.NumeroParcelas = numeroParcelas;
            this.ValorEntrada = valorEntrada;
            this.ValorTotalPlano = valorTotal;
        }

        public decimal GetValorTotalParcelas() {
            return ValorTotalPlano - ValorEntrada;
        }
    } //class
}
