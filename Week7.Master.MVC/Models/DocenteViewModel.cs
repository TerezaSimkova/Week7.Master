using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class DocenteViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
