using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class TransacaoController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;

        public TransacaoController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            TransacaoModel objTransacao = new TransacaoModel(_httpContextAccessor);
            ViewBag.ListaTransacao = objTransacao.ListaTransacao();
            return View();
        }
        public IActionResult Extrato()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(TransacaoModel form)
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
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                TransacaoModel objTransacao = new TransacaoModel(_httpContextAccessor);
                ViewBag.Registro = objTransacao.CarregarRegistro(id);

            }
            ViewBag.ListaContas = new ContaModel(_httpContextAccessor).ListaConta();
            ViewBag.ListaPlanoContas = new PlanoContaModel(_httpContextAccessor).ListaPlanoConta();
            return View();

           
        }
    }
}