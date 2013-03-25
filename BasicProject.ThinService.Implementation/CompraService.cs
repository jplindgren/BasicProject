using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.ThinService.Interface;
using BasicProject.Infra.Interface;
using BasicProject.RichModel;

namespace BasicProject.ThinService.Implementation {
    public class CompraService : ICompraService {
        private readonly ILongKeyedRepository<Cliente> clienteRepository;

        public CompraService(ILongKeyedRepository<Cliente> clienteRepository) {
            this.clienteRepository = clienteRepository;
        }

        public void AdquirirOferta(Cliente comprador,Oferta ofertaAdquirida) {
            comprador.AdquirirOferta(ofertaAdquirida);
            clienteRepository.Add(comprador);
        }
    } //class
}
