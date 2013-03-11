using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicProject.ThinService.Interface;
using Spring.Context.Support;
using Spring.Context;

namespace BasicProject.Controllers {
    public class HomeController : Controller {
        public string Message { get; set; }
        public ISampleService2 SampleService2 { get; set; }

        public HomeController(ISampleService2 sampleService2) {
            this.SampleService2 = sampleService2;
        }

        public ActionResult Index() {
            ViewBag.Message = Message;

            IApplicationContext ctx = ContextRegistry.GetContext();

            string teste = SampleService2.Teste();

            return View();
        }

        public ActionResult About() {
            return View();
        }
    } //class
} //namespace
