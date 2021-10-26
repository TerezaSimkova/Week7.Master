using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Helper;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class DocentiController : Controller
    {

        private readonly IBusinessLayer BL;
        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();

            List<DocenteViewModel> docenteViewModels = new List<DocenteViewModel>();
            foreach (var item in docenti)
            {
                docenteViewModels.Add(item.ToDocentiViewModel());
            }

            return View(docenteViewModels);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); //->torna form vuoto
        }
        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel) //uso lo stesso nome perche in caso di inserimento va in coppia
        {
            if (ModelState.IsValid) //controllo
            {
                var docente = docenteViewModel.ToDocenti(); // ->converto in corso cosi lo posso connettere con BL 
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel); //-> grazie questo se ce un errore mi memorizza i dati e da errore ,se non ce torna  il form vuoto
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var docente = BL.GetAllDocenti().Find(d => d.ID == id);
            var conversione = docente.ToDocentiViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Update(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocenti();
                BL.ModificaDocente(docente.ID, docente.Nome, docente.Cognome, docente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocenti().Find(d => d.ID == id);
            var docenteViewModel = docente.ToDocentiViewModel();
            return View(docenteViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocenti();
                BL.EliminaDocente(docente.ID);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }
        #endregion
    }
}
