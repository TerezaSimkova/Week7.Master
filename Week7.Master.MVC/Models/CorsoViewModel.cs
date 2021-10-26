using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.MVC.Models
{
    public class CorsoViewModel
    {
        [Required]
        [DisplayName("Codice Corso")] //->se faccio riferimenbto a questa proprieta,esempio: nel form mi prende asp-for nome se non lo specifico io nel label
        public string CodiceCorso { get; set; }
        [Required]
        [DisplayName("Nome Corso")]
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public List<StudenteViewModel> Studenti { get; set; } = new List<StudenteViewModel>();
    }
}
