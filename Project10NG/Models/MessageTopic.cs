using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project10NG.Models
{
    public class MessageTopic
    {
        [Key]
        public int id_topic { get; set; }
        public string name_topic { get; set; }
    }
}
