using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel;

public class LoginViewModel
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email message is required!")]
    public string EmailAddress { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}