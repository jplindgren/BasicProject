using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class ItemPlanoPagamento {
        private decimal valor;
        public long Id { get; set; }
        public decimal Valor { get { return valor; } }

        public ItemPlanoPagamento(decimal valorParcela) {
            this.valor = valorParcela;
        }

        //hibernate
        private ItemPlanoPagamento() { }
    } //class
}
