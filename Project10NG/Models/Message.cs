using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project10NG.Models
{
    public class Message
    {
        [Key]
        public int id_message { get; set; }
        public string text_message { get; set; }
        public int id_topic { get; set; }
        public int id_contact { get; set; }
    }
}
