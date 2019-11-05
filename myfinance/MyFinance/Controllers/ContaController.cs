using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ContaController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;

        public ContaController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            ContaModel objConta = new ContaModel(_httpContextAccessor);
            ViewBag.ListaConta = objConta.ListaConta();
            return View();
        }
        [HttpPost]
        public IActionResult CriarConta(ContaModel form)
        {
            if(ModelState.IsValid)
            {
                form._httpContextAccessor = _httpContextAccessor;
                form.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarConta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            ContaModel objConta = new ContaModel(_httpContextAccessor);
            objConta.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}