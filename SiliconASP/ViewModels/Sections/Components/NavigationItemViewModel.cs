namespace SiliconASP.ViewModels.Sections.Components;

public class NavigationItemViewModel
{
    public string Title { get; set; } = null!;
    public LinkViewModel Link { get; set; } = null!;
    public bool IsVisibleOnLargeScreen { get; set; }
    public AccountActionViewModel SignInAction { get; set; } = null!;
    public AccountActionViewModel SignUpAction { get; set; } = null!;
    public string ItemType { get; set; } = "Regular";
}
