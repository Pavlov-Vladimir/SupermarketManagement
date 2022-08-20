namespace SupermarketManagement.Entities;
public class Transaction
{
    public int Id { get; set; }
    [Required]
    public DateTime TimeStamp { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int QtyBefore { get; set; }
    [Required]
    public int QtySold { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string CashierName { get; set; } = null!;
}
