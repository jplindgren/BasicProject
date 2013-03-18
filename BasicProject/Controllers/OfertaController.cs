using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicProject.RichModel;
using BasicProject.ThinService.Interface;

namespace BasicProject.Controllers{
    public class OfertaController : Controller{
        public IOfertaService _ofertaService { get; set; }
        public OfertaController(IOfertaService ofertaService) {
            this._ofertaService = ofertaService;
        }

        //
        // GET: /Oferta/

        public ActionResult Index(){
            var ofertas = _ofertaService.ListarOfertas();
            return View(ofertas);
        }

        //
        // GET: /Oferta/Details/5

        public ActionResult Details(int id){
            return View();
        }

        //
        // GET: /Oferta/Create

        public ActionResult Create(){
            return View();
        } 

        //
        // POST: /Oferta/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection){
            try{
                int numeroParcelas = Convert.ToInt32(collection["InfoPagamento.NumeroParcelas"]);
                decimal valorEntrada = Convert.ToDecimal(collection["InfoPagamento.ValorEntrada"]);
                decimal valorTotalPlano = Convert.ToDecimal(collection["InfoPagamento.ValorTotalPlano"]);
                DateTime dataInicioOferta = Convert.ToDateTime(collection["DataInicioOferta"]);
                Oferta oferta = Oferta.CriarOfertaComPlanoPagamento(numeroParcelas,valorEntrada,valorTotalPlano,dataInicioOferta);
                _ofertaService.CriarOferta(oferta);
                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }
        
        //
        // GET: /Oferta/Edit/5
 
        public ActionResult Edit(int id){
            return View();
        }

        //
        // POST: /Oferta/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection){
            try{
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }

        //
        // GET: /Oferta/Delete/5
 
        public ActionResult Delete(int id){
            return View();
        }

        //
        // POST: /Oferta/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection){
            try{
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }
    } //end class
} //end namespace
