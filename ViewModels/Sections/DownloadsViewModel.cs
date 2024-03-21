using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class DownloadsViewModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ImageViewModel Image { get; set; } = null!;
    public ReviewViewModel AppStore { get; set; } = null!;
    public ReviewViewModel GoogleStore { get; set; } = null!;
}
