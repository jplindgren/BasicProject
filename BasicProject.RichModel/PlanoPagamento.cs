using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class PlanoPagamento {
        public long Id { get; set; }
        private decimal valorEntrada { get; set; }
        private IList<ItemPlanoPagamento> itensPlanoPagamento { get; set; }

        public PlanoPagamento(int numeroParcelas, decimal valorEntrada, decimal valorTotalPlano) {
            var valorTotalParcelado = valorTotalPlano - valorEntrada;
            this.valorEntrada = valorEntrada;
            CriarItensPlanoPagamento(numeroParcelas, valorTotalParcelado);
        }


        private decimal GetTotalPlanoPagamento() {
            var total = itensPlanoPagamento.Select(x => x.Valor).Sum();
            return total;
        }

        private void CriarItensPlanoPagamento(int numeroParcelas, decimal valorTotalParcelado) {
            this.itensPlanoPagamento = new List<ItemPlanoPagamento>();
            var valorParcela = valorTotalParcelado / numeroParcelas;

            ItemPlanoPagamento itemPlanoPagamento = null;
            for (int i = 0; i < numeroParcelas; i++) {
                itemPlanoPagamento = new ItemPlanoPagamento(valorParcela);
                itensPlanoPagamento.Add(itemPlanoPagamento);
            }
        }
    } //class
}
