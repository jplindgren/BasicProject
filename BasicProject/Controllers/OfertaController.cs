using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicProject.RichModel;
using BasicProject.ThinService.Interface;

namespace BasicProject.Controllers{
    public class OfertaController : Controller{
        private IOfertaService _ofertaService;
        private ICompraService _compraService;

        public OfertaController(IOfertaService ofertaService, ICompraService compraService) {
            this._ofertaService = ofertaService;
            this._compraService = compraService;
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
        // GET: /Oferta/Adquirir/5
 
        public ActionResult Adquirir(int id){
            var ofertaASerAdquirida = _ofertaService.BuscarOfertas(id);
            return View(ofertaASerAdquirida);
        }

        //
        // POST: /Oferta/Adquirir/5
        [HttpPost]
        public ActionResult Adquirir(int id, FormCollection collection) {
            try{
                var ofertaAdquirida = _ofertaService.BuscarOfertas(id);                
                var cliente = Cliente.CriarNovoCliente(); //aqui buscariamos um cliente já pré-cadastrado, ou exigiriamos o cadastro de um novo.
                _compraService.AdquirirOferta(cliente, ofertaAdquirida);
                return RedirectToAction("Agradecimento", new { id = cliente.Id });
            }catch (Exception ex){
                return View();
            }
        }

        public ActionResult Agradecimento(long id) {
            return View();
        }
    } //end class
} //end namespace
