using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.ThinService.Interface;
using BasicProject.Infra.Interface;
using BasicProject.RichModel;

namespace BasicProject.ThinService.Implementation {
    public class OfertaService : IOfertaService {
        private readonly ILongKeyedRepository<Oferta> _ofertaRepository;
        public OfertaService(ILongKeyedRepository<Oferta> ofertaRepository) {
            this._ofertaRepository = ofertaRepository;
        }

        public RichModel.Oferta CriarOferta(RichModel.Oferta oferta) {
            _ofertaRepository.Add(oferta);
            return oferta;
        }

        public IList<Oferta> ListarOfertas() {
            return _ofertaRepository.All().ToList();
        }

        public Oferta BuscarOfertas(long id) {
            return _ofertaRepository.FindBy(id);
        }

    } //class
}
