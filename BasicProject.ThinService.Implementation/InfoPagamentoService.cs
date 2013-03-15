using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.ThinService.Interface;
using BasicProject.NHibernateInfra.Implementation.Repositories;
using BasicProject.RichModel;
using BasicProject.Infra.Interface;

namespace BasicProject.ThinService.Implementation {
    public class InfoPagamentoService : IInfoPagamentoService{
        private readonly ILongKeyedRepository<InfoPagamento> _infoPagamentoRepository;

        public InfoPagamentoService(ILongKeyedRepository<InfoPagamento> infoPagamentoRepository) {
            this._infoPagamentoRepository = infoPagamentoRepository;
        }

        public InfoPagamentoService() {
            
        }
        public void SalvarInfoPagamento(RichModel.InfoPagamento infoPagamento) {
            _infoPagamentoRepository.Add(infoPagamento);
        }
    } //class
}
