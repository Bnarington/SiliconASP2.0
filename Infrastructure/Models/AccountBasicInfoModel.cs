using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public class AccountBasicInfoModel
{
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "Invalid first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Invalid last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email adress", Prompt = "Enter your email adress", Order = 2)]
    [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phonenumber is required.")]
    [Display(Name = "Phonenumber", Prompt = "Enter your phonenumber.", Order = 3)]
    public string Phone { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [MaxLength(500)]
    [Display(Name = "Biography (Optional)", Prompt = "Write something about yourself!", Order = 4)]
    public string? Bio {  get; set; }

    [Display(Name = "Priofile Image", Prompt = "Add a profile image!")]
    public IFormFile? ProfileImage { get; set; } = null!;

    public string? ProfileImageSrc { get; set; }
}
