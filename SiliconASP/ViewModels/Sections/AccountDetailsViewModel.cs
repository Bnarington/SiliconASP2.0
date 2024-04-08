using Infrastructure.Entities;
using Infrastructure.Models;

namespace SiliconASP.ViewModels.Sections;

public class AccountDetailsViewModel
{

    public UserEntity User { get; set; } = new UserEntity();

    public AddressEntity Address { get; set; } = new AddressEntity();

    public AccountAdressInfoModel AddressInfo { get; set; } = new AccountAdressInfoModel();

    public AccountBasicInfoModel BasicInfo { get; set; }  = new AccountBasicInfoModel();

}
