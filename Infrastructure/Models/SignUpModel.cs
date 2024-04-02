using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class SignUpModel
    {
        [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Invalid first name")]
        [MinLength(2, ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Invalid last name")]
        [MinLength(2, ErrorMessage = "Invalid last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adress", Prompt = "Enter your email adress", Order = 2)]
        [Required(ErrorMessage = "Invalid Email")]
        [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter your password.", Order = 3)]
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
        [Required(ErrorMessage = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "I agree to the <a href=\"#\">Terms</a> & <a href=\"#\">Conditions", Order = 5)]
        [CheckBoxRequired(ErrorMessage = "You must accept the terms and conditions.")]
        public bool TermsAndConditions { get; set; } = false;
    }

}
