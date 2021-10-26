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
    public class LezioniController : Controller
    {
        private readonly IBusinessLayer BL;
        public LezioniController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lezioni = BL.GetAllLezioni();

            List<LezioneViewModel> lezioneViewModels = new List<LezioneViewModel>();
            foreach (var item in lezioni)
            {
                lezioneViewModels.Add(item.ToLezioniViewModel());
            }

            return View(lezioneViewModels);
        }
        [HttpGet("Lezioni/Details/{id}")] //-> devi specificare il percorso se cambio la variabile nella entrata
        public IActionResult Details(int id)
        {
            var lezioni = BL.GetAllLezioni().FirstOrDefault(c => c.LezioneID == id);

            var lezioneViewModel = lezioni.ToLezioniViewModel();
            return View(lezioneViewModel);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); //->torna form vuoto
        }
        [HttpPost]
        public IActionResult Create(LezioneViewModel lezioneViewModel) //uso lo stesso nome perche in caso di inserimento va in coppia
        {
            if (ModelState.IsValid) //controllo
            {
                var lezione = lezioneViewModel.ToLezioni(); // ->converto in corso cosi lo posso connettere con BL 
                BL.InserisciNuovaLezione(lezione);
                return RedirectToAction(nameof(Index));
            }
            return View(lezioneViewModel); //-> grazie questo se ce un errore mi memorizza i dati e da errore ,se non ce torna  il form vuoto
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var lezioni = BL.GetAllLezioni().Find(l => l.LezioneID == id);
            var conversione = lezioni.ToLezioniViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Update(LezioneViewModel lezioneViewModel)
        {
            if (ModelState.IsValid) 
            {
                var lezione = lezioneViewModel.ToLezioni(); 
                BL.ModificaLezione(lezione.LezioneID, lezione.Aula);
                return RedirectToAction(nameof(Index));
            }
            return View(lezioneViewModel); 
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var lezioni = BL.GetAllLezioni().Find(l => l.LezioneID == id);
            var conversione = lezioni.ToLezioniViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Delete(LezioneViewModel lezioneViewModel)
        {
            if (ModelState.IsValid)
            {
                var lezione = lezioneViewModel.ToLezioni();
                BL.EliminaLezione(lezione.LezioneID);
                return RedirectToAction(nameof(Index));
            }
            return View(lezioneViewModel);
        }
        #endregion
    }
}
