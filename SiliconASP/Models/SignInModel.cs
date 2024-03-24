using System.ComponentModel.DataAnnotations;

namespace SiliconASP.Models;

public class SignInModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email adress", Prompt = "Enter your email adress", Order = 0)]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me", Prompt = "Enter your email adress", Order = 2)]
    public bool RememberMe { get; set; }
}
