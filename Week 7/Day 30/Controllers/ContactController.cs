using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
         {
            new ContactInfo{ ContactId = 1, FirstName=  "Harsha", LastName= "Vardhan", CompanyName= "Tech Solutions", EmailId= "harsha.vardhan@gmail.com", MobileNo= 9876543210, Designation= "Software Engineer" },
        new ContactInfo{ ContactId = 2, FirstName= "Rahul", LastName= "Sharma", CompanyName= "Infosys", EmailId= "rahul.sharma@infosys.com", MobileNo= 9123456780, Designation= "System Analyst" },

new ContactInfo{ ContactId = 3, FirstName= "Priya", LastName= "Reddy", CompanyName= "Wipro", EmailId= "priya.reddy@wipro.com", MobileNo= 9988776655, Designation= "Project Manager" },

new ContactInfo{ ContactId = 4, FirstName= "Amit", LastName= "Kumar", CompanyName= "TCS", EmailId= "amit.kumar@tcs.com", MobileNo= 9012345678, Designation= "Developer" },

new ContactInfo{ ContactId = 5, FirstName= "Sneha", LastName= "Patel", CompanyName= "Capgemini", EmailId= "sneha.patel@capgemini.com", MobileNo= 9090909090, Designation= "HR Manager" }
         };

        public IActionResult ShowContacts()
        {
            
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            ContactInfo Conobj = contacts.FirstOrDefault(p => p.ContactId == id);
            return View(Conobj);
        }
        [HttpGet]
        public IActionResult AddContact()
        {

            return View();
        }
        [HttpPost]
             public IActionResult AddContact(ContactInfo Contact)
        {
            if (ModelState.IsValid) {
                contacts.Add(Contact);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "invalid data";
                    return View();
            }
          

            //return View(contacts);
        }
        public IActionResult Search( string designation)
        {

            var searchresult = contacts.Select(item => item);
            if ( designation!= null)
            {
                searchresult = searchresult.Where(x => x.Designation == designation);
            }
            return View(searchresult.ToList());
        }

    }
}
