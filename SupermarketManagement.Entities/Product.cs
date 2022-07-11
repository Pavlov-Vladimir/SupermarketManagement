namespace SupermarketManagement.Entities;
public class Product
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public string Name { get; set; } = null!;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
}
