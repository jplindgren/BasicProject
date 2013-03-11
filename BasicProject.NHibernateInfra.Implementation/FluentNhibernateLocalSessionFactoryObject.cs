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

        //protected override void PostProcessConfiguration(Configuration config) {
        //    base.PostProcessConfiguration(config);

        //    var autoMappingCfg = new AutoMappingConfiguration();

        //    var autoMap = AutoMap.AssemblyOf(autoMappingCfg)
        //    .Conventions.Add(DefaultCascade.All(), DefaultLazy.Never())
        //    .Conventions.Add()
        //    .Override(map => { map.IgnoreProperty(i => i.Total); });

        //    Fluently.Configure(config)
        //    .Mappings(m => m.AutoMappings.Add(autoMap))
        //    .BuildConfiguration();
        //}

        public string[] FluentNhibernateMappingAssemblies { get; set; }
        public string ConnectionStringName { get; set; }

        protected override void PostProcessConfiguration(Configuration config) {
            //return Fluently.Configure()
            //   .Database(MySQLConfiguration.Standard.ConnectionString(ConnectionStringName))
            //   .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            //   .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            //   .BuildSessionFactory();

            base.PostProcessConfiguration(config);

            FluentConfiguration fluentConfig = Fluently.Configure(config)
                .Database(MySQLConfiguration.Standard.ConnectionString(ConnectionStringName));

            Array.ForEach(FluentNhibernateMappingAssemblies,
                           assembly => fluentConfig.Mappings(
                                                    m => m.FluentMappings.AddFromAssembly(Assembly.Load(assembly))
                                                    )
                         );
            fluentConfig.BuildSessionFactory();


            //IPersistenceConfigurer persistenceConfigurer = MySQLConfiguration.Standard.ConnectionString(c => c.Is("Data Source=.SQL2008;Initial Catalog=NHibernateBlog; Integrated Security=True")).ShowSql(); 
            //// initialize nhibernate with persistance configurer properties
            //Configuration cfg = persistenceConfigurer.ConfigureProperties(new Configuration());
 
            //// add mappings definition to nhibernate configuration
            //var persistenceModel = new PersistenceModel();
            //persistenceModel.AddMappingsFromAssembly(Assembly.Load("NHConfigMappings"));
            //persistenceModel.Configure(cfg); 
            //// set session factory field which is to be used in tests
            //_sessionFactory = cfg.BuildSessionFactory();

        }
    } //class
}
