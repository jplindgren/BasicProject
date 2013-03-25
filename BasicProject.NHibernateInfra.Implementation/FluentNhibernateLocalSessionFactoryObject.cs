using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using FluentNHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate;

namespace BasicProject.NHibernateInfra.Implementation {
    public class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject{
        ///// <summary>
        ///// Sets the assemblies to load that contain fluent nhibernate mappings.
        ///// </summary>
        ///// <value>The mapping assemblies.</value>
        //public string[] FluentNhibernateMappingAssemblies {
        //    get;
        //    set;
        //}

        public string[] FluentNhibernateMappingAssemblies { get; set; }
        public string ConnectionStringName { get; set; }
        static readonly object factorylock = new object();

        protected override void PostProcessConfiguration(Configuration config) {
            ConnectionStringName = "Server=localhost;Database=basicproject;User ID=root;Password=kmn23po";
            base.PostProcessConfiguration(config);
            FluentConfiguration fluentConfig = Fluently.Configure(config)
                .Database(MySQLConfiguration.Standard.ConnectionString(ConnectionStringName))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            Array.ForEach(FluentNhibernateMappingAssemblies,
                           assembly => fluentConfig.Mappings(
                                                    m => m.FluentMappings.AddFromAssembly(Assembly.Load(assembly))
                                                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never())
                                                    )
                         );
            fluentConfig.BuildSessionFactory();
        }
    } //class
}
