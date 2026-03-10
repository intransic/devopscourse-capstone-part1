using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InventoryItem
{
    [Key]
    public int ItemId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public string Location { get; set; }

    // Foreign key for Order (nullable for optional relationship)
    public int? OrderId { get; set; }

    // Navigation property
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {ItemId}, Name: {Name}, Quantity: {Quantity}, Location: {Location}");
    }
}