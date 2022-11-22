using Directory.BLL.RepositoryPattern.Interfaces;
using Directory.DAL.Context;
using Directory.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Directory.UI.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _db;
        IPersonRepository _repoPerson;
        public HomeController(MyDbContext db,IPersonRepository repoPerson)
        {
            _db = db;   
            _repoPerson = repoPerson;   
        }
        public IActionResult PersonList()
        {
            List<Person> persons = _repoPerson.GetPerson();
            return View(persons);
        }
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Person persons)
        {
            if(!ModelState.IsValid)
            {
                return View(persons);
            }
            _repoPerson.Add(persons);
            return RedirectToAction("PersonList", "Person");
        }
        public IActionResult Edit(int id)
        {
            Person person=_repoPerson.GetById(id);
            return View(person);   
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if(!ModelState.IsValid)
            {
                return View(person);
            }
            _repoPerson.Update(person);
            return RedirectToAction("PersonList", "Person");
        }
        public IActionResult Delete(int id)
        {
            _repoPerson.Delete(id);
            return RedirectToAction("PersonList","Person");
        }
    }
}
