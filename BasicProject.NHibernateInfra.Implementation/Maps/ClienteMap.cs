using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using FluentNHibernate.Mapping;

namespace BasicProject.NHibernateInfra.Implementation.Maps {
    public class ClienteMap : ClassMap<Cliente>{
        public ClienteMap() {
            Table("Cliente");
            Id(x => x.Id).GeneratedBy.Identity().Column("IdInfoPagamento");
            References<PlanoPagamento>(x => x.planoPagamentoCliente).Column("IdPlanoPagamento").Cascade.All();
            References<Oferta>(x => x.oferta).Column("IdOferta").Cascade.All();
        }
    } //end class
}
