using SiliconASP.ViewModels.Sections;

namespace SiliconASP.ViewModels.Sections.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = null!;
    public HeaderViewModel Header { get; set; } = null!;
    public ShowcaseViewModel Showcase { get; set; } = null!;
    public FeaturesViewModel Features { get; set; } = null!;
    public ManageWorkViewModel Managework { get; set; } = null!;
    public DownloadsViewModel Downloads { get; set; } = null!;
    public IntegrateViewModel Integrate { get; set; } = null!;
    public NewsletterViewModel Newsletter { get; set; } = null!;
    public FooterViewModel Footer { get; set; } = null!;
}
