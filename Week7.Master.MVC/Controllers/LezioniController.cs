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
    }
}
