using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class ManageWorkViewModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public ImageViewModel Image { get; set; } = null!;
    public List<ManageListViewModel> ManageList { get; set; } = null!;
    public LinkViewModel Link { get; set; } = null!;
}
