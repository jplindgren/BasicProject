using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.RichModel;
using NHibernate;

namespace BasicProject.NHibernateInfra.Implementation.Repositories {
    public class InfoPagamentoRepository : Repository<InfoPagamento>{

        public InfoPagamentoRepository(ISession session) : base(session){
            
        }

    } //end class
}
