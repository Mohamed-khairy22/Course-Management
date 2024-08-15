using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_task1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Grade { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        public virtual Department1 Department { get; set; }


    }
}
