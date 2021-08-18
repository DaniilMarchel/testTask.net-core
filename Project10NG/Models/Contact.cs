using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project10NG.Models
{
    public class Contact
    {
        [Key]
        public int id_contact { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}
