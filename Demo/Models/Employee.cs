using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public string image { get; set; }
        [ForeignKey("Department")]
        public int DepID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
