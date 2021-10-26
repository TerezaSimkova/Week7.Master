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
    public class CorsiController : Controller
    {
        //collegamento al business layer
        private readonly IBusinessLayer BL;
        //costruttore
        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        
        #region Fetch all corsi + details
        //CRUD del corso + API
        //url: http://localhost:44338/Home/Corsi

        [HttpGet]
        public IActionResult Index()
        {
            var corsi = BL.GetAllCorsi(); // -> scorro la lista la trasformo in corsi view mdoel e la metto nella nuovo lista creata qui sotto
            //creare la mappatura tra model Corsi e CorsoViewModel
            //li passo il nuovo modello corsi

            List<CorsoViewModel> corsoViewModels = new List<CorsoViewModel>();

            foreach (var item in corsi)
            {
                corsoViewModels.Add(item.ToCorsoViewModel()); // -> aggiungo dipendenza al Helper,corso view model e la lista e fatta dei oggetti di corso convertiti
            }

            return View(corsoViewModels);
        }

        //url: http://localhost:44338/Home/Corsi/Datails/id -> oppure codice o altro ma devo specificarlo poi nel percorso
        [HttpGet("Corsi/Details/{code}")] //-> devi specificare il percorso se cambio la variabile nella entrata
        public IActionResult Details(string code)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CodiceCorso == code);

            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); //->torna form vuoto
        }
        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel) //uso lo stesso nome perche in caso di inserimento va in coppia
        {
            if (ModelState.IsValid) //controllo
            {
                var corso = corsoViewModel.ToCorso(); // ->converto in corso cosi lo posso connettere con BL 
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel); //-> grazie questo se ce un errore mi memorizza i dati e da errore ,se non ce torna  il form vuoto
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(string id)
        {
            var corso = BL.GetAllCorsi().Find(c => c.CodiceCorso == id);
            var conversione = corso.ToCorsoViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Update(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.ModificaCorso(corso.CodiceCorso, corso.Nome, corso.Descrizione);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().Find(c => c.CodiceCorso == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }
        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.EliminaCorso(corso.CodiceCorso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }
        #endregion
    }
}
