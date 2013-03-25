using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class InfoPagamento {
        private decimal valorTotalPlano;
        private int numeroParcelas;
        private decimal valorEntrada;

        public virtual long? Id { get; set; }

        public decimal ValorEntrada {
            get { return valorEntrada; }
        }       

        public int NumeroParcelas {
            get { return numeroParcelas; }
        }

        public decimal ValorTotalPlano {
            get { return valorTotalPlano; }
        }

        public InfoPagamento(int numeroParcelas, decimal valorEntrada, decimal valorTotal) {
            this.numeroParcelas = numeroParcelas;
            this.valorEntrada = valorEntrada;
            this.valorTotalPlano = valorTotal;
        }

        public virtual decimal GetValorTotalParcelas() {
            return ValorTotalPlano - ValorEntrada;
        }

        //Hibernate
        private InfoPagamento() { }
    } //class
}
