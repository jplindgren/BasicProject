﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicProject.Infra.Interface {
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    } //interface
}
