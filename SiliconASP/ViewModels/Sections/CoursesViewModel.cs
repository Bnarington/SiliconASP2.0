using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections
{
    public class CoursesViewModel
    {
        public int Id { get; set; }
        public bool IsBestseller { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string RatingProcent { get; set; } = null!;
        public string RatingNumber { get; set; } = null!;
        public string Hours { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string? DiscountPrice { get; set; }
    }
}
