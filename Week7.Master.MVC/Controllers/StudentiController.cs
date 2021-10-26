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
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();

            List<StudenteViewModel> studenteViewModels = new List<StudenteViewModel>();
            foreach (var item in studenti)
            {
                studenteViewModels.Add(item.ToStudentiViewModel());
            }

            return View(studenteViewModels);
        }

        [HttpGet("Studenti/Details/{id}")] //-> devi specificare il percorso se cambio la variabile nella entrata
        public IActionResult Details(int id)
        {
            var studenti = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);

            var studenteViewModel = studenti.ToStudentiViewModel();
            return View(studenteViewModel);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); //->torna form vuoto
        }
        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel) //uso lo stesso nome perche in caso di inserimento va in coppia
        {
            if (ModelState.IsValid) //controllo
            {
                var studente = studenteViewModel.ToStudenti(); // ->converto in corso cosi lo posso connettere con BL 
                BL.InserisciNuovoStudente(studente);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel); //-> grazie questo se ce un errore mi memorizza i dati e da errore ,se non ce torna  il form vuoto
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var studente = BL.GetAllStudenti().Find(s => s.ID == id);
            var conversione = studente.ToStudentiViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Update(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudenti();
                BL.ModificaStudente(studente.ID,studente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studente = BL.GetAllStudenti().Find(s => s.ID == id);
            var conversione = studente.ToStudentiViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Delete(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudenti();
                BL.EliminaStudente(studente.ID);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }
        #endregion
    }
}
