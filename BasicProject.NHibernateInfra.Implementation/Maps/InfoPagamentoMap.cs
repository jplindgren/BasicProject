using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using FluentNHibernate.Mapping;

namespace BasicProject.NHibernateInfra.Implementation.Maps {
    public class InfoPagamentoMap : ClassMap<InfoPagamento>{
        public InfoPagamentoMap(){
            Table("InfoPagamento");
            Id(x => x.Id).GeneratedBy.Identity().Column("IdInfoPagamento");
            Map(x => x.NumeroParcelas).Access.CamelCaseField();
            Map(x => x.ValorEntrada).Access.CamelCaseField();
            Map(x => x.ValorTotalPlano).Access.CamelCaseField();
        }
    } //class
}
