using System;
using WarehouseInventory.Exceptions;
using WarehouseInventory.Models;
using WarehouseInventory.Repositories;

namespace WarehouseInventory
{
    public class WarehouseManagementSytem
    {
        public readonly InventoryRepository<ElectronicItem> Electronics = new();
        public readonly InventoryRepository<GroceryItem> Groceries = new();

        public void SeedData()
        {
            // Electronics
            Electronics.AddItem(new ElectronicItem(101, "Flashdrive", 65, "Sanyo", 17));
            Electronics.AddItem(new ElectronicItem(102, "Smartphone", 40, "Samsung", 27));

            // Groceries
            Groceries.AddItem(new GroceryItem(201, "Pineapples", 115, DateTime.Now.AddDays(14)));
            Groceries.AddItem(new GroceryItem(202, "Skimmed milk", 140, DateTime.Now.AddDays(7)));
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            Console.WriteLine($"\n=== {typeof(T).Name.ToUpper()} INVENTORY ===");
            foreach (var item in repo.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Updated {item.Name}: New quantity = {item.Quantity + quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.RemoveItem(id);
                Console.WriteLine($"Removed: {item.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}