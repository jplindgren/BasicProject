using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using FluentNHibernate.Mapping;

namespace BasicProject.NHibernateInfra.Implementation.Maps {
    public class OfertaMap : ClassMap<Oferta>{
        public OfertaMap(){
            Table("Oferta");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.DataInicioOferta);
            References<InfoPagamento>(x => x.InfoPagamento).Column("IdInfoPagamento").Cascade.All();
        }
    }//class
}
