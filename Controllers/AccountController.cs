using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjFinRBEM.Data;
using ProjFinRBEM.Helpers;
using ProjFinRBEM.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjFinRBEM.Controllers
{
  
    public class AccountController : Controller
    {

        private readonly ProjFinRBEMContext _context;

        public AccountController(ProjFinRBEMContext context)
        {
            _context = context;
        }
      
            public IActionResult Index()
            {
                var user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "CurrentUser");



                if (user != null)
                {
                    switch (user.TypeOfUser)
                    {
                        case "Admin":
                            return RedirectToAction("HomeAdmin", "Admin");



                        case "Invite":
                            return View("Index");



                        case "MembreR":
                            return View("~/Views/MembreR/Index.cshtml");



                        case "MembreP":
                            return View("~/Views/MembreP/Index.cshtml");



                        default:

                            return RedirectToAction("Index", "Home");
                    }
                }
                else
                {



                    return View();
                }
            }
            
        

        public User UserGetByUsernamePassword(string username , string password) {

            return _context.User.
                SingleOrDefault(p => p.Username == username && p.Password == password);
        
        }

        public IActionResult Login(string username, string password)
        {
            
            if ((_context.User?.Any(e => e.Username == username && e.Password == password)).GetValueOrDefault())
            {
                var user = UserGetByUsernamePassword(username, password);

                if (UserGetByUsernamePassword(username, password).TypeOfUser== "Invite")
                {
                    HttpContext.Session.SetObjectAsJson("CurrentUser", user);
                    return RedirectToAction("Index", "Users");

                }
                if (UserGetByUsernamePassword(username, password).TypeOfUser == "MembreR")
                {
                    HttpContext.Session.SetObjectAsJson("CurrentUser", user);
                    return RedirectToAction("Index","MembreR");
                }
                if (UserGetByUsernamePassword(username, password).TypeOfUser == "MembreP")
                {
                    HttpContext.Session.SetObjectAsJson("CurrentUser", user);
                    return RedirectToAction("Index", "MembreP");
                }
                if (UserGetByUsernamePassword(username, password).TypeOfUser == "Admin")
                {
                    HttpContext.Session.SetObjectAsJson("CurrentUser", user);
                    return RedirectToAction("HomeAdmin", "Admin");




                }
                else
                {
                   

                    ViewBag.error = "Invalid Account";
                    return View("Index");
                }

            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }

       
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("~/Views/Account/index.cshtml");
        }

        public IActionResult InscrivezVous(string FirstName, string Username, string Email, string Password) 
        {
            //User user = new User(9999, "inscription", "inscription", "inscription", "inscription",
            //    DateTime.Now, "inscription", "inscription", "inscription", null);
            HttpContext.Session.SetString("InscrivezVousFirstName", FirstName);
            HttpContext.Session.SetString("InscrivezVousUsername", Username);
            HttpContext.Session.SetString("InscrivezVousEmail", Email);
            HttpContext.Session.SetString("InscrivezVousPassword", Password);
            //HttpContext.Session.SetObjectAsJson("CurrentUser", user);
            return View("~/Views/Account/Inscription.cshtml");
        }


        /*
        public IActionResult InscrivezVous(firstName, UsernamePasswordCredential, EmailAddressAttribute, typeofuser, email)
        {



            return View("~/Views/Account/Inscription.cshtml");
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfUser,FirstName,Username,Email,DateOfBirth,Gender,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ModelState.AddModelError("ConfirmPassword", "Les mots de passe ne correspondent pas.");
                    return View(user);
                }
            }


            return View(user);
        }*/
    }
}
