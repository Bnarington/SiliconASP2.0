using System.ComponentModel.DataAnnotations;

namespace SiliconASP.Models;

public class AccountAdressInfoModel
{
    [Display(Name = "Address", Prompt = "Enter your address", Order = 0)]
    [Required(ErrorMessage = "Invalid Address")]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "Secondary Address", Prompt = "Enter a secondary address", Order = 1)]
    public string? AddressLine_2 { get; set; }

    [Display(Name = "Postcode", Prompt = "Enter your postcode", Order = 2)]
    [Required(ErrorMessage = "Invalid postcode")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "Invalid city")]
    public string City { get; set; } = null!;
}
