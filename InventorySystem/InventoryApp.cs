using InventorySystem.Models;
using System;

namespace InventorySystem
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger = new();

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-30)));
            _logger.Add(new InventoryItem(2, "Monitor", 15, DateTime.Now.AddDays(-15)));
            _logger.Add(new InventoryItem(3, "Keyboard", 50, DateTime.Now));
        }

        public void SaveData() => _logger.SaveToFile();

        public void LoadData() => _logger.LoadFromFile();

        public void PrintAllItems()
        {
            Console.WriteLine("\n=== CURRENT INVENTORY ===");
            foreach (var item in _logger.GetAll())
            {
                Console.WriteLine($"[{item.DateAdded:yyyy-MM-dd}] {item.Name} (ID: {item.Id}): {item.Quantity} units");
            }
        }
    }
}