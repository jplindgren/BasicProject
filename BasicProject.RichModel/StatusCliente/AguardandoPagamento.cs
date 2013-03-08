using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel.StatusCliente {
    public class AguardandoPagamento : IStatusCliente{
        public void ProximoStatus(Cliente cliente) {
            cliente.StatusCliente = new Pago();
        }

        public void StatusAnterior(Cliente cliente) {
            cliente.StatusCliente = new DadosCadastrados();
        }
    } //class
}
