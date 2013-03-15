using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class InfoPagamento {
        public virtual long? Id { get; set; }
        public virtual decimal ValorEntrada { get; set; }
        public virtual int NumeroParcelas { get; set; }
        public virtual decimal ValorTotalPlano { get; set; }

        public InfoPagamento(int numeroParcelas, decimal valorEntrada, decimal valorTotal) {
            this.NumeroParcelas = numeroParcelas;
            this.ValorEntrada = valorEntrada;
            this.ValorTotalPlano = valorTotal;
        }

        public InfoPagamento() { }

        public virtual decimal GetValorTotalParcelas() {
            return ValorTotalPlano - ValorEntrada;
        }
    } //class
}
