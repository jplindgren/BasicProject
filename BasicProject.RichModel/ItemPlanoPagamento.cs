using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel {
    public class ItemPlanoPagamento {
        public long Id { get; set; }
        public decimal Valor { get; set; }

        public ItemPlanoPagamento(decimal valorParcela) {
            this.Valor = valorParcela;
        }
    } //class
}
