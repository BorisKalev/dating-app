using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjFinRBEM.Data;

namespace ProjFinRBEM.Controllers
{
    public class MembreRController : Controller
    {

        private readonly ProjFinRBEMContext _context;

        public MembreRController(ProjFinRBEMContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString, string gender){
            ViewBag.Vide = true;

            var users = await _context.User.ToListAsync(); // Récupérer la liste des utilisateurs depuis la base de données

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Username.Contains(searchString) || u.FirstName.Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(gender))
            {
                users = users.Where(u => u.Gender == gender).ToList();
            }

            if (users.Count == 0)
            {
                ViewBag.Vide = false;
            }

            return View(users);
        }

    }
}
