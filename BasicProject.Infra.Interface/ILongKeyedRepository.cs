using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.Infra.Interface {
    public interface ILongKeyedRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        TEntity FindBy(long id);
    }  //interface
}
