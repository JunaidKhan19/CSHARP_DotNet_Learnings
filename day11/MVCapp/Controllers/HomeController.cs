using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;

namespace MVCapp.Controllers
{
    public class HomeController : Controller
    {
        EmpDbContext _dbcontext = null;

        public HomeController(EmpDbContext context)
        {
            //Dependency Injection of DbContext 
            _dbcontext = context; //Binding DbContext to EmpDbContext variable
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _dbcontext.emps.ToList(); //LINQ to Entities
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            _dbcontext.emps.Add(emp); //Adding new Emp record
            _dbcontext.SaveChanges(); //Saving changes to database
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empToBeUpdated = _dbcontext.emps.FirstOrDefault(e => e.empno == id); //Finding existing Emp record
            return View(empToBeUpdated);
        }

        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            _dbcontext.emps.Update(emp); //Updating existing Emp record
            _dbcontext.SaveChanges(); //Saving changes to database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var empToBeDeleted = _dbcontext.emps.FirstOrDefault(e => e.empno == id); //Finding existing Emp record
            _dbcontext.emps.Remove(empToBeDeleted); //Deleting existing Emp record
            _dbcontext.SaveChanges(); //Saving changes to database
            return RedirectToAction("Index");
        }
    }
}
