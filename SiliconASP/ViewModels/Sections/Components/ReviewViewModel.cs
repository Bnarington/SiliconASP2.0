namespace SiliconASP.ViewModels.Sections.Components;

public class ReviewViewModel
{
    public string Title { get; set; } = null!;
    public string DescriptionTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<ImageViewModel> Stars { get; set; } = [];
    public ImageViewModel Icon { get; set; } = null!;
}
