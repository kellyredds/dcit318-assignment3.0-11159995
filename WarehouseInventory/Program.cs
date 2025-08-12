using WarehouseInventory;

var manager = new WarehouseManager();

// Initialize data
manager.SeedData();

// Display all items
manager.PrintAllItems(manager.Electronics); //was manager._electronics
manager.PrintAllItems(manager.Groceries);

// Test operations with exception handling
Console.WriteLine("\n=== TESTING OPERATIONS ===");

// Valid operations
manager.IncreaseStock(manager.Electronics, 101, 10);  // Add stock
manager.RemoveItemById(manager.Groceries, 201);      // Remove existing

// Exception cases
manager.IncreaseStock(manager.Electronics, 999, 10); // Non-existent item
manager.RemoveItemById(manager.Groceries, 999);      // Non-existent item
manager.IncreaseStock(manager.Electronics, 102, -5); // Negative quantity