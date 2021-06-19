using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    // https://github.com/DotNetMastery/Rocky

    public class PersonController : Controller
    {
        #region Properties and Constructor
        // Store the db context via constructor 
        // dependency injection
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        #endregion


        #region Class Methods

        public IActionResult Index()
        {
            IEnumerable<Person> people = _db.Person;
            return View(people);
        }

        // GET - Create Person
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create Person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            _db.Person.Add(person);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
