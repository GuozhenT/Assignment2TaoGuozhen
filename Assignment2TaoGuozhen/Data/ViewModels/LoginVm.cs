using System.ComponentModel.DataAnnotations;

namespace Assignment2TaoGuozhen.Data.ViewModels
{
    public class LoginVm
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
