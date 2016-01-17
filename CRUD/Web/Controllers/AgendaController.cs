using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repositorio;
namespace Web.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        private ContatoRep banco = new ContatoRep();
     

        public ActionResult Index()
        {

            return View(banco.Listar());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Contato contato)
        {
         if (ModelState.IsValid)
            {
                banco.Salvar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public ActionResult Editar (int id)
        {
            var buscar = banco.Buscar(id);

            if(buscar == null)
            {
                return HttpNotFound();
            }
            return View(buscar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                banco.Alterar(contato);
               return RedirectToAction("Index");
            }
            return View(contato);
        }

        public ActionResult Detalhar (int id)
        {
            var buscar = banco.Buscar(id);
            if(buscar == null)
            {
                return HttpNotFound();
            }

            return View(buscar);
        }

        public ActionResult Excluir(int id)
        {
            var excluir = banco.Buscar(id);
            if(excluir == null)
            {
                return HttpNotFound();
            }
            return View(excluir);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExclusao (int id)
        {
            var excluir = banco.Buscar(id);
            banco.Remover(excluir);
         return   RedirectToAction("Index");

        }
    }
}