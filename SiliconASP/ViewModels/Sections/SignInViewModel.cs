using Infrastructure.Models;

namespace SiliconASP.ViewModels.Sections;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign In";

    public SignInModel Form { get; set; } = null!;

    public string? ErrorMessage { get; set; }
}
