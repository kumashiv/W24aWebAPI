using System.ComponentModel.DataAnnotations;

namespace W24aWebAPI.Models
{
    public class Employee
    {
        [Key]     // to make id primary key
        public int id { get; set; }   // properties  - auto type

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }
    }
}
