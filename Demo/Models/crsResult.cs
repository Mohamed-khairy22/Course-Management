using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_task1.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public float Degree { get; set; }
        [ForeignKey("Course")]
        public int crsId { get; set; }
        [ForeignKey("Trainee")]
        public int traineeId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
