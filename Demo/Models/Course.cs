using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_task1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [UniqueName]
        public string Name { get; set; }
        [Required]
        [Range(50,100)]
        public float Degree { get; set; }
        [Remote("checkMinDegree","Course",AdditionalFields = "Degree"
            , ErrorMessage ="Minmum Degree must be less than Degree")]
        [Display(Name ="Minimum Degree")]
        [Required]
       // [Range(30, 70)]
        [RegularExpression(@"[0-9]{2}",ErrorMessage ="You must enter a valid numbers")]
        public float minDegree { get; set; }
        [ForeignKey("Department")]
        [Display(Name ="Department")]
        [Required]
        public int deptId { get; set; }
        public virtual Department1? Department { get; set; }

    }
}
