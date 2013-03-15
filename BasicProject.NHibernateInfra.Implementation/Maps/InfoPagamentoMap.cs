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
            Id(x => x.Id).GeneratedBy.Identity();
        }
    } //class
}
