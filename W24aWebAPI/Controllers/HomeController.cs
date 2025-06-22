using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W24aWebAPI.AppDbContext;
using W24aWebAPI.Models;

namespace W24aWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }



        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Employee obj)
        {
            try
            {
                _db.Employee.Add(obj);     // adding to SQL query    //constructor part   
                                            // Employees is the table name defined in DataContext.cs
                _db.SaveChanges();      // Saving
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(obj);
        }


        [HttpGet]
        [Route("GetAll")]
        //public IActionResult GetEmployeeData()
        public IActionResult GetAllEmployee()
        {
            var Emp = _db.Employee.ToList();
            return Ok(Emp);
        }


        [HttpGet]
        [Route("GetById{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var Emp = _db.Employee.FirstOrDefault(x => x.id == id);  // search for employee with matching ID

            if (Emp == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }
            return Ok(Emp);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Emp = _db.Employee.FirstOrDefault(x => x.id == id);     // matching with database id
            if (Emp == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            _db.Employee.Remove(Emp);
            _db.SaveChanges();
            return Ok(Emp);
        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Employee obj)       // Saving edited page with information
        {
            if (id != obj.id)
            {
                return BadRequest("ID mismatch");
            }

            _db.Employee.Update(obj);
            _db.SaveChanges();
            return Ok();
        }

    }
}
