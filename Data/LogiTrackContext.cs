using Microsoft.EntityFrameworkCore;

public class LogiTrackContext : DbContext
{
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=logitrack.db");

    // Efficient method to print all order summaries
    public void PrintAllOrderSummaries()
    {
        var orders = Orders.Include(o => o.Items).ToList();
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetOrderSummary());
        }
    }
}