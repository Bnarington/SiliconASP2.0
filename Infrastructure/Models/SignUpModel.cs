using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class SignUpModel
    {
        [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Invalid last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adress", Prompt = "Enter your email adress", Order = 2)]
        [RegularExpression("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter your password, it needs 1 lowercase, 1 uppercase, 1 digit, 1 specialcharachter, atleast 8 characters in total.", Order = 3)]
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\w\\s]).{8,}$", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "I agree to the <a href=\"#\">Terms</a> & <a href=\"#\">Conditions", Order = 5)]
        [Required(ErrorMessage = "You must tick this box")]
        public bool TermsAndConditions { get; set; } = false;
    }

}
