using SiliconASP.Models.Sections;

namespace SiliconASP.ViewModels.Sections;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel SignUpForm { get; set; } = new SignUpModel();
}
