using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using FluentNHibernate;
using System.Reflection;
using NHibernate;
using BasicProject.RichModel;
using System.IO;

namespace BasicProject.Tests.Domain {
    /// <summary>
    /// Summary description for InfoPagamentoTest
    /// </summary>
    [TestClass]
    public class InfoPagamentoTest {
        private static ISessionFactory _sessionFactory;

        public InfoPagamentoTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {

            try {
                IPersistenceConfigurer persistenceConfigurer = MySQLConfiguration.Standard.ConnectionString(c => c.Is("Server=localhost;Database=basicproject;User ID=root;Password=1234")).ShowSql();
                // initialize nhibernate with persistance configurer properties
                Configuration cfg = persistenceConfigurer.ConfigureProperties(new Configuration());
                

                // add mappings definition to nhibernate configuration
                var persistenceModel = new PersistenceModel();
                persistenceModel.AddMappingsFromAssembly(Assembly.Load("BasicProject.NHibernateInfra.Implementation"));
                persistenceModel.Configure(cfg);
                // set session factory field which is to be used in tests
                _sessionFactory = cfg.BuildSessionFactory();
            } catch (ReflectionTypeLoadException ex) {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions) {
                    sb.AppendLine(exSub.Message);
                    if (exSub is FileNotFoundException) {
                        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog)) {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                //Display or log the error based on your application.
            }

        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1() {
            var infoPagammento = new InfoPagamento(3,1000m,10000m);

            var session = _sessionFactory.GetCurrentSession();
            session.Save(infoPagammento);
            Assert.IsNotNull(infoPagammento.Id);
        }
    } //class
}
