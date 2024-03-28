namespace SiliconASP.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool SelectedCategory { get; set; }
    public virtual ICollection<CourseModel> Courses { get; set; } = null!;
}
