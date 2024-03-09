using aspmvc.Models;
using aspmvc.Models.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace aspmvc.Areas.Contact.Controllers
{
    [Area("Contact")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("/admin/contact")]
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Contacts.ToListAsync());
        }

        [HttpGet("/admin/contact/detail/{id}")]
        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(p => p.Id == id);
            if(contact == null) {             
                return NotFound();
            }
            return View(contact);
        }

        [TempData]
        public string StatusMessage { set; get; }

        [HttpGet("/contact")]
        [AllowAnonymous]
        public IActionResult SendContact()
        {
            return View();
        }

        [HttpPost("/contact")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact([Bind("Name,Email,Phone,Message")] ContactModel contact)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine(contact.Name);
                
                _dbContext.Add(contact);
                await _dbContext.SaveChangesAsync();

                StatusMessage = "Liên hệ của bạn đã được gửi";

                return RedirectToAction("Index","Home");
            }
            return View(contact);
        }

        [HttpGet("/admin/contact/delete/{id}")]
        public async Task<IActionResult> Delete (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(p => p.Id == id);

            if(contact == null)
            {
                return NotFound();
            }
            return View(contact) ;
        }

        [HttpPost("/admin/contact/delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
