namespace Infrastructure.Entities;

public class BrandItemEntity
{
    public int Id { get; set; }
    public int ShowcaseId { get; set; }
    public string BrandImageUrl { get; set; } = null!;
}
