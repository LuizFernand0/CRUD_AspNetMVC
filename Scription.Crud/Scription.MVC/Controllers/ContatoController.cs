
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scription.MVC.Models;
using System.Data;

namespace Scription.MVC.Controllers
{
    public class ContatoController : Controller
    {
        private EntidadesBD banco = new EntidadesBD();


        public ActionResult Index()
        {

            var contatos = banco.Contato.ToList();

            return View(contatos);

        }
        public JsonResult Procurar(Contato contato)
        {
            var contatos = from c in banco.Contato
                          where c.Nome == contato.Nome
                          select c;

            return Json(contatos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                bool teste = banco.Contato.ToList().Exists(c => c.Nome == contato.Nome);

                if (!banco.Contato.ToList().Exists(c => c.Nome == contato.Nome))
                {
                    banco.Contato.Add(contato);
                    banco.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                    return View(contato);
            }

            return View(contato);
        }
        public ActionResult Editar(long id)
        {
            if (id <= 0 )
                return RedirectToAction("Index");
            else
            {
                var contato = banco.Contato.Find(id);

                return View(contato);

            }
        }

        [HttpPost]
        public ActionResult Editar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    banco.Entry(contato).State = EntityState.Modified;

                    banco.SaveChanges();

                    return RedirectToAction("Index");
                }

             }catch(Exception e){

                 throw new UpdateException(e.Message);
             }
            return View(contato);
        }

        
        public ActionResult Excluir(long id)
        {
            try
            {
                Contato contato = banco.Contato.Find(id);
                
                if (contato != null)
                {

                    banco.Contato.Remove(contato);
                    banco.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new UpdateException(ex.StackTrace); 
            }
        }
    
     }
}
