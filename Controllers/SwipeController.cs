using System.Linq;
using ProjFinRBEM.Models;

using Microsoft.AspNetCore.Mvc;
using ProjFinRBEM.Data;

namespace ProjFinRBEM.Controllers
{
    public class SwipeController : Controller
    {
        private ProjFinRBEMContext _context;

        public SwipeController(ProjFinRBEMContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var users = _context.User.ToList();
            return View(users);
        }
    }
}
