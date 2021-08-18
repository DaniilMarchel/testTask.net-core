using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project10NG.Models
{
    public class FormContext : DbContext 
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageTopic> MessageTopics { get; set; }

        public FormContext(DbContextOptions<FormContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
