using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections
{
    public class ShowcaseViewModel
    {
        public string? Id { get; set; }
        public ImageViewModel ShowcaseImage { get; set; } = new ImageViewModel();
        public string? Title { get; set; }
        public string? Text { get; set; }
        public LinkViewModel Link { get; set; } = new LinkViewModel();
        public string? BrandText { get; set; }
        public List<ImageViewModel>? Brands { get; set; }
    }
}
