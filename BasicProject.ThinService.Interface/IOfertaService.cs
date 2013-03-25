using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;

namespace BasicProject.ThinService.Interface {
    public interface IOfertaService {
        Oferta CriarOferta(Oferta oferta);
        IList<Oferta> ListarOfertas();
        Oferta BuscarOfertas(long id); 
    } //class
}
