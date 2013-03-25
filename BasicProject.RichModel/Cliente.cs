using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel.StatusCliente;

namespace BasicProject.RichModel {
    public class Cliente {
        public long? Id { get; set; }
        public IStatusCliente StatusCliente { get; set; }
        public PlanoPagamento planoPagamentoCliente { get; set; }
        public Oferta oferta { get; set; }

        private Cliente(IStatusCliente statusCliente) {
            StatusCliente = statusCliente;
        }

        public static Cliente CriarNovoCliente() {
            return new Cliente(new DadosCadastrados());
        }

        public void AdquirirOferta(Oferta oferta) {
            this.oferta = oferta;
            this.planoPagamentoCliente = new PlanoPagamento(oferta.InfoPagamento.NumeroParcelas, oferta.InfoPagamento.ValorEntrada, oferta.InfoPagamento.ValorTotalPlano);
            StatusCliente.ProximoStatus(this);
        }

         //Hibernate
        private Cliente() { }
    } //class
}
