using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using lent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lent.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly lentContext _context;

        public ContactFormController(lentContext context)
        {
            _context = context;
        }

        // GET: ContactForm/Create
        public ActionResult Create(int? id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

                var item =  _context.Item
                    .Include(i => i.Borrower)
                    .Include(i => i.Owner)
                    .FirstOrDefault(m => m.ID == id);
             ContactFormModel cfm = new ContactFormModel();

            cfm.Email = item.Owner.EMail;
            cfm.LastName = item.Owner.Lastname;
            cfm.Name = item.Owner.Surname;
            cfm.Message = "Hallo, ich möchte ihren Gegenstand " + item.Name + " ausleihen";
                if (item == null)
                {
                    return NotFound();
                }

                return View("CreateContactEmail",cfm);
        }

        // POST: ContactForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Email,LastName,Name,Message")]ContactFormModel cfm)
        {
           
            
                using (var message = new MailMessage(cfm.Email, "me@mail.uni-kiel.de"))
                {
                    //message.To.Add(new MailAddress("me@mydomain.com"));
                   // message.From = new MailAddress(cfm.Email);
                    message.Subject = "New E-Mail from my website";
                    message.Body = cfm.Message;

                    using (var smtpClient = new SmtpClient("smtp.mail.uni-kiel.de"))
                    {
                        smtpClient.Send(message);
                    }
                }
            

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View("CreateContactEmail");
            }
        }

    }
}