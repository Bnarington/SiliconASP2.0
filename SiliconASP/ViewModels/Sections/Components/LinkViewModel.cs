namespace SiliconASP.ViewModels.Sections.Components;

public class LinkViewModel
{
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string? Text { get; set; } = null!;
    public string Fragment { get; set; } = null!;
}
