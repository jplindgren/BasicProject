using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using FluentNHibernate.Mapping;

namespace BasicProject.NHibernateInfra.Implementation.Maps {
    public class ItemPlanoPagamentoMap : ClassMap<ItemPlanoPagamento>{
        public ItemPlanoPagamentoMap() {
            Table("ItemPlanoPagamento");
            Id(x => x.Id).GeneratedBy.Identity().Column("IdItemPlanoPagamento");
            Map(x => x.Valor).Access.CamelCaseField();
        }
    } //end class
}
