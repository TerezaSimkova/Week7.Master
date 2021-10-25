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
    }
}
