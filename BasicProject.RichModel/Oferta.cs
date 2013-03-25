using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class Oferta {
        public long Id { get; set; }
        public InfoPagamento InfoPagamento { get; set; }
        public DateTime DataInicioOferta { get; set; }

        //Hibernate
        private Oferta() { }

        private Oferta(int numeroParcelas, decimal entrada, decimal valorTotalPlano, DateTime dataInicioOferta) {
            this.DataInicioOferta = dataInicioOferta;
            this.InfoPagamento = new InfoPagamento(numeroParcelas, entrada, valorTotalPlano);
        }

        public static Oferta CriarOfertaComPlanoPagamento(int numeroParcelas, decimal entrada, decimal valorTotalPlano, DateTime dataInicioOferta) {
            return new Oferta(numeroParcelas, entrada, valorTotalPlano, dataInicioOferta);
        }
    }
}
