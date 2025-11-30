using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCapp.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDataController : ControllerBase
    {
        private readonly EmpDbContext _dbContext; 
        public EmpDataController(EmpDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/<EmpDataController>
        [HttpGet]
        public IEnumerable<Emp> Get()
        {
            return _dbContext.emps.ToList();
        }

        // GET api/<EmpDataController>/5
        [HttpGet("{id}")]
        public Emp Get(int id)
        {
            var empToBeFetched = _dbContext.emps.FirstOrDefault(e => e.empno == id);
            return empToBeFetched;
        }

        // POST api/<EmpDataController>
        [HttpPost]
        public void Post([FromBody] Emp value)
        {
            _dbContext.emps.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/<EmpDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Emp value)
        {
            var empToBeUpdated = _dbContext.emps.FirstOrDefault(e => e.empno == id);
            if (empToBeUpdated != null) 
            {
                empToBeUpdated.ename = value.ename;
                empToBeUpdated.address = value.address;
                _dbContext.emps.Update(empToBeUpdated);
                _dbContext.SaveChanges();
            }
        }

        // DELETE api/<EmpDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var empToBeDeleted = _dbContext.emps.FirstOrDefault(e => e.empno == id);
            if (empToBeDeleted != null) 
            {
                _dbContext.emps.Remove(empToBeDeleted);
                _dbContext.SaveChanges();
            }
        }
    }
}
