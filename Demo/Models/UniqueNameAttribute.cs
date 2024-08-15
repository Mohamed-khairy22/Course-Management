using ITI_task1.Models;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        public int Id { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course userCrs =(Course) validationContext.ObjectInstance;
            ITIEntity entity = new ITIEntity();
            string name = value.ToString();
            
            Course crs= entity.courses.FirstOrDefault(c => c.Name== userCrs.Name && c.deptId==userCrs.deptId);
            if (crs == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("This name is alrady found,Try again");
            //return base.IsValid(value, validationContext);
        }

    }
}
