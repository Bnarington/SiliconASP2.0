namespace Infrastructure.Models;

public class CourseModel
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string? CoAuthor { get; set; }
    public decimal Price { get; set; }
    public int Time { get; set; }
    public string Likes { get; set; } = null!;

    public int CategoryId { get; set; }
    public virtual CategoryModel Category { get; set; } = null!;
}
