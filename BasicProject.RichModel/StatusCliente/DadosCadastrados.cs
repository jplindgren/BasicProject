using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel.StatusCliente {
    public class DadosCadastrados : IStatusCliente{
        public void ProximoStatus(Cliente cliente) {
            cliente.StatusCliente = new AguardandoPagamento();
        }

        public void StatusAnterior(Cliente cliente) {
            throw new Exception();
        }
    } //class
}
