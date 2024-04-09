using Infrastructure.Models;
using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class NewsletterViewModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ImageViewModel Image { get; set; } = null!;
    public List<NewsletterOptionsViewModel> Options { get; set; } = [];
    public string Email { get; set; } = null!;
    public LinkViewModel TermsLink { get; set; } = null!;
    public LinkViewModel PrivacyLink { get; set; } = null!;
    public NewsletterModel Newsletter { get; set; } = null!;

}
