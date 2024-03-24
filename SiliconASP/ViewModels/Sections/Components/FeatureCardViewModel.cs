namespace SiliconASP.ViewModels.Sections.Components;

public class FeatureCardViewModel
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public ImageViewModel Image { get; set; } = new ImageViewModel();
    public LinkViewModel Link { get; set; } = new LinkViewModel();
}
