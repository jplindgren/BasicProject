using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.RichModel.StatusCliente {
    public interface IStatusCliente {
        void ProximoStatus(Cliente cliente);
        void StatusAnterior(Cliente cliente);
    } //class
}
