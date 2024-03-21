using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class FeaturesViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? TitleText { get; set; }
    public List<FeatureCardViewModel>? FeatureCards { get; set; }
}
