namespace SupermarketManagement.Entities;
public class Category
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(250)]
    public string? Description { get; set; }

    public List<Product>? Products { get; set; }
}
