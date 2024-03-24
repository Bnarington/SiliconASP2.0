using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class IntegrateViewModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<IntegrateItemViewModel> IntegrateItem { get; set; } = null!;
}
