namespace SiliconASP.ViewModels.Sections.Components
{
    public class CoursesCardViewModel
    {
        public ImageViewModel Image { get; set; } = null!;
        public ImageViewModel Icon { get; set; } = null!;
        public ImageViewModel Bookmark { get; set; } = null!;
        public string CardTitle { get; set; } = null!;
        public string CardAuthor { get; set; } = null!;
        public string CardPrice { get; set; } = null!;
        public CardsTimeAndLikesViewModel TimeAndLikes { get; set; } = new CardsTimeAndLikesViewModel();

    }
}
