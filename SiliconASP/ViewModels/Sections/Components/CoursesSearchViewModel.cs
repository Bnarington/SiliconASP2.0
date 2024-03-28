using SiliconASP.Models;
using System.ComponentModel;

namespace SiliconASP.ViewModels.Sections.Components;

public class CoursesSearchViewModel
{
    public string SearchQuery { get; set; } = null!;
    public string SelectedCategory { get; set; } = null!;
    public List<CategoryModel> Categories { get; set; } = [];
    public List<CourseModel> Courses { get; set; } = [];
}
