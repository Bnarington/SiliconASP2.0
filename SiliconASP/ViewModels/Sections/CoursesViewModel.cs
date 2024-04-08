using SiliconASP.ViewModels.Sections.Components;

namespace SiliconASP.ViewModels.Sections
{
    public class CoursesViewModel
    {
        public CoursesSearchViewModel Search { get; set; } = null!;

        public List<CoursesCardViewModel> CoursesCards { get; set; } = [];

    }
}
