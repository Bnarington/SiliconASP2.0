using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class HeaderViewModel
{
    public List<NavigationItemViewModel> NavigationItems { get; set; } = new List<NavigationItemViewModel>();
    public AccountActionViewModel SignInAction { get; set; } = null!;
    public AccountActionViewModel SignUpAction { get; set; } = null!;
    public bool IsDarkModelEnabled { get; set; }
}
