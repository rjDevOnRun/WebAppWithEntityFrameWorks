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

        [HttpGet]
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
            if (ModelState.IsValid)
            {
                _db.Person.Add(person);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET - Edit Person
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var personToEdit = _db.Person.Find(id);
            if(personToEdit == null)
            {
                return NotFound();
            }

            return View(personToEdit);
        }

        // POST - Edit Person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _db.Person.Update(person);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET - Delete Person
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var personToEdit = _db.Person.Find(id);
            if (personToEdit == null)
            {
                return NotFound();
            }

            return View(personToEdit);
        }

        // POST - Delete Person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var person = _db.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            _db.Person.Remove(person);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
