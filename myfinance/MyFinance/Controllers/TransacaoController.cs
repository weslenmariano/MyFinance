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
        [HttpGet]
        public IActionResult ExcluirTransacao( int id)
        {
            
            TransacaoModel objTransacao = new TransacaoModel(_httpContextAccessor);
            ViewBag.Registro = objTransacao.CarregarRegistro(id);

            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            TransacaoModel objTransacao = new TransacaoModel(_httpContextAccessor);
            objTransacao.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Extrato(TransacaoModel formulario)
        {
            formulario._httpContextAccessor = _httpContextAccessor;
            ViewBag.ListaTransacao = formulario.ListaTransacao();
            ViewBag.ListaContas = new ContaModel(_httpContextAccessor).ListaConta();
            return View();
        }

        public IActionResult Dashboard()
        {


            List<Dashboard> lista = new Dashboard(_httpContextAccessor).RetornarDadosGraficoPie();

            string valores = "";
            string labels = "";
            string cores = "";

            var randon = new Random();
           // var color = String.Format("#{0:X6}", randon.Next(0x1000000));

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Total.ToString() + ",";
                labels += "'"+lista[i].PlanoConta.ToString() + "',";
                cores += "'"+String.Format("#{0:X6}", randon.Next(0x1000000)) +"',";
            }
            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;
            return View();
        }
    }
}