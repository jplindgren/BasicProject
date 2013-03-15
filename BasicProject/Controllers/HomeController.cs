using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicProject.ThinService.Interface;
using Spring.Context.Support;
using Spring.Context;
using BasicProject.RichModel;

namespace BasicProject.Controllers {
    public class HomeController : Controller {
        public string Message { get; set; }
        public ISampleService2 SampleService2 { get; set; }
        public IInfoPagamentoService _infoPagamentoServvice { get; set; }

        public HomeController(ISampleService2 sampleService2,IInfoPagamentoService infoPagamentoServvice) {
            this.SampleService2 = sampleService2;
            this._infoPagamentoServvice = infoPagamentoServvice;
        }

        public ActionResult Index() {
            ViewBag.Message = Message;
            InfoPagamento info = new InfoPagamento(3,1000m,10000m);
            _infoPagamentoServvice.SalvarInfoPagamento(info);

            //IApplicationContext ctx = ContextRegistry.GetContext();

            

            return View();
        }

        public ActionResult About() {
            return View();
        }
    } //class
} //namespace
