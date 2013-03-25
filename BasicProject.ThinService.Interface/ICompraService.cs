using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;

namespace BasicProject.ThinService.Interface {
    public interface ICompraService {
        void AdquirirOferta(Cliente comprador, Oferta ofertaAdquirida);
    } //interface
}
