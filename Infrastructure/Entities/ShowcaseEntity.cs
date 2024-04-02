namespace Infrastructure.Entities;

public class ShowcaseEntity
{
    public int Id { get; set; }
    public string ShowcaseImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string BrandText { get; set; } = null!;
    public ICollection<BrandItemEntity> BrandItem { get; set; } = [];
}
