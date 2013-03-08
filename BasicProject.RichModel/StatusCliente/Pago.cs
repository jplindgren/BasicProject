using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel.StatusCliente {
    public class Pago : IStatusCliente{
        public void ProximoStatus(Cliente cliente) {
            throw new Exception();
        }

        public void StatusAnterior(Cliente cliente) {
            cliente.StatusCliente = new AguardandoPagamento();
        }
    } //class
}
