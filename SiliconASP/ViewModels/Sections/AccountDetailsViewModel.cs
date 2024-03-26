using SiliconASP.Models;

namespace SiliconASP.ViewModels.Sections;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account details";
 
    public AccountBasicInfoModel BasicInfo { get; set; } = new AccountBasicInfoModel()
    {
        FirstName = "Bnar",
        LastName = "Bnarington",
        Email = "bnar@test.se",
        Phone = "",
        ProfileImage = "/Images/Icons/account-picture.svg"
    };

    public AccountAdressInfoModel AdressInfo { get; set; } = new AccountAdressInfoModel();

}
