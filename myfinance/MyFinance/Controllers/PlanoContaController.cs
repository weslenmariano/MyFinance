using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class PlanoContaController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;

        public PlanoContaController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            PlanoContaModel objPlanoContas = new PlanoContaModel(_httpContextAccessor);
            ViewBag.ListaPlanoContas = objPlanoContas.ListaPlanoConta();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel form)
        {
            if (ModelState.IsValid)
            {
                form._httpContextAccessor = _httpContextAccessor;
                form.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                PlanoContaModel objPlanoContas = new PlanoContaModel(_httpContextAccessor);
                ViewBag.Registro = objPlanoContas.CarregarRegistro(id);
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            PlanoContaModel objConta = new PlanoContaModel(_httpContextAccessor);
            objConta.Excluir(id);
            return RedirectToAction("Index");
        }


    }
}