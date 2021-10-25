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
    }
}
