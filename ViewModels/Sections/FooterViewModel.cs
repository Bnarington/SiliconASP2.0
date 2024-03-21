using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class FooterViewModel
{
    public List<SocialLinkViewModel> SocialLinks { get; set; } = [];
    public string Copyright { get; set; } = null!;
}
