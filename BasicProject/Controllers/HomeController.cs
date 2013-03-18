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
        public IOfertaService _ofertaService { get; set; }
        public IInfoPagamentoService _infoPagamentoServvice { get; set; }

        public HomeController(IInfoPagamentoService infoPagamentoServvice) {
            this._infoPagamentoServvice = infoPagamentoServvice;
        }

        public ActionResult Index() {
            ViewBag.Message = Message;

            return View();
        }

        public ActionResult About() {
            return View();
        }
    } //class
} //namespace
