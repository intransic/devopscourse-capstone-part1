using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    
    [Required]
    public string CustomerName { get; set; }
    
    [Required]
    public DateTime DatePlaced { get; set; }

    // Navigation property for one-to-many relationship
    public List<InventoryItem> Items { get; set; } = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        if (Items.Contains(item)) return; // Avoid duplicates
        
        Items.Add(item);
        // Maintain relationship
        item.OrderId = OrderId;
        item.Order = this;
    }
    public void RemoveItem(InventoryItem item)
    {
        Items.Remove(item);
    }
    public string GetOrderSummary()
    {
        var summary = $"Order ID: {OrderId}, Customer: {CustomerName}, Date Placed: {DatePlaced}\nItems in Order:\n";
        foreach (var item in Items)
        {
            summary += $"{item.ItemId}: {item.Name} (Qty: {item.Quantity}, Loc: {item.Location})\n";
        }
        return summary;
    }
}