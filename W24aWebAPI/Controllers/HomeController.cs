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
        [Route("Get")]
        public IActionResult GetEmployeeData()
        {
            var Emp = _db.Employee.ToList();
            return Ok(Emp);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var Emp = _db.Employee.FirstOrDefault(x => x.id == id);     // matching with database id
            _db.Employee.Remove(Emp);
            _db.SaveChanges();
            return Ok(Emp);
        }


        [HttpPut]
        [Route("{id}")]
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
