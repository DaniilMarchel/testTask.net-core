using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project10NG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project10NG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class FormController : ControllerBase
    {
        public readonly FormContext db;
        public FormController(FormContext context)
        {
            db = context;
        }

        [HttpPost]
        public JsonResult Post(FormData formData)
        {
            int id_contact, id_topic, id_message;
            var contacts = db.Contacts.Where(c => c.email == formData.Email).Where(c => c.phone == formData.Phone).ToList();
            if (contacts.Count() == 0)
            {
                Contact contact = new Contact { name = formData.Name, email = formData.Email, phone = formData.Phone };
                db.Contacts.AddRange(contact);
                db.SaveChanges();
                id_contact = contact.id_contact;
            }
            else
            {
                id_contact = contacts[0].id_contact;
            }    

            var topics = db.MessageTopics.Where(mt => mt.name_topic == formData.Topic).ToList();
            id_topic = topics[0].id_topic;

            Message message = new Message { text_message = formData.Text, id_topic = id_topic, id_contact = id_contact };

            db.Messages.AddRange(message);
            db.SaveChanges();
            id_message = message.id_message;

            var messages = from m in db.Messages
                        join c in db.Contacts on m.id_contact equals c.id_contact
                        join mt in db.MessageTopics on m.id_topic equals mt.id_topic
                        where m.id_contact == id_contact
                        where m.id_topic == id_topic
                        where m.id_message == id_message
                        select new FormData
                        {
                            Name = c.name,
                            Email = c.email,
                            Phone = c.phone,
                            Topic = mt.name_topic,
                            Text = m.text_message
                        };
            return new JsonResult(messages.ToList()[0]);
        }
    }
    public class FormData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
    }
}
