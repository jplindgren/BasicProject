using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using FluentNHibernate.Mapping;

namespace BasicProject.NHibernateInfra.Implementation.Maps {
    public class PlanoPagamentoMap : ClassMap<PlanoPagamento>{
        public PlanoPagamentoMap() {
            Table("PlanoPagamento");
            Id(x => x.Id).GeneratedBy.Identity().Column("IdPlanoPagamento");
            Map(x => x.ValorEntrada).Access.CamelCaseField();
            HasMany<ItemPlanoPagamento>(x => x.ItensPlanoPagamento).Access.CamelCaseField().Cascade.AllDeleteOrphan();
        }
    } //end class
}
