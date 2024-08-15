using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class LoginViewModel
    {
        [Display (Name ="User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remeber Me")]
        public bool RememberMe { get; set; }  
    }
}
