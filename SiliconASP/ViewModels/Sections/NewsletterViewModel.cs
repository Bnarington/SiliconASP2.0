using Infrastructure.Models;
using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections;

public class NewsletterViewModel
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ImageViewModel?Image { get; set; }
    public List<NewsletterOptionsViewModel>? Options { get; set; } = [];
    public LinkViewModel? TermsLink { get; set; }
    public LinkViewModel? PrivacyLink { get; set; } 
    public NewsletterModel? Newsletter { get; set; }

}
