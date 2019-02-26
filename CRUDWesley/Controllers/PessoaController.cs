using CRUDWesley.Models;
using CRUDWesley.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWesley.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository _repository;
        
        [HttpGet] //GET (pegar)
        public ActionResult Index()
        {         
            var pessoa = new Pessoa();
            return View(pessoa);
        }

        [HttpGet] //GET (pegar)
        public ActionResult Listados() // action dos listados
        {
            _repository = new PessoaRepository();
            var lista = _repository.BuscarTodos();
            return View(lista); // busca todas as pessas da lista de pessoas
        }


        [HttpPost] //POST (enviar pro BD)
        public ActionResult Index(Pessoa pessoa)
        {
            if (ModelState.IsValid) // Vai no Model e verifica os DataAnnotations se são válidos
            {
                _repository = new PessoaRepository();

                _repository.Adicionar(pessoa);
                return View("Resultado", pessoa);
            }
            return View(pessoa);
        }

        [HttpPost] //POST (enviar)
        public ActionResult EditarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid) // Vai no Model e verifica os DataAnnotations se são válidos
            {
                _repository = new PessoaRepository();
                _repository.Alterar(pessoa);           
            }

            return RedirectToAction("Listados"); // redireciona para action apontada
        }

        [HttpGet] //GET (pegar)
        public ActionResult AlterarPessoa(int id)
        {
            _repository = new PessoaRepository();
            var pessoaEscolhida = _repository.BuscarTodos().Find(pessoa => pessoa.Codigo == id);
            return View(pessoaEscolhida);
        }

        public ActionResult ExcluirPessoa(int id)
        {
            _repository = new PessoaRepository();
            _repository.Deletar(id);
            return RedirectToAction("Listados"); // redireciona para action apontada
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

    }
}
