using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_task1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        [ForeignKey("Course")]
        public int crsId { get; set; }
        public virtual Department1 Department { get; set; }
        public virtual Course Course { get; set; }

    }
}
