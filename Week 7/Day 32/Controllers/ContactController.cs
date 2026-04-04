using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactservice;
        public ContactController(IContactService contactservice)
        {
            _contactservice = contactservice;
        }
        public IActionResult ShowContacts()
        {
            var contacts =_contactservice.GetAllContacts();
            return View(contacts);
        }
        public IActionResult GetContactsById(int id)
        {
            var contacts = _contactservice.GetContactById(id);
            return View(contacts);
        }
        public IActionResult AddContact()
        {
           return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid){

                _contactservice.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            return View(contact);
        }
    }

}
