namespace TestMasGlobal.CalculatedSalary.Model
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User")]
        public string User { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
