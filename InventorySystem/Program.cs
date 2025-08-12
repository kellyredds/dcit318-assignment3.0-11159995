using InventorySystem;

var app = new InventoryApp();

// Simulate first run
app.SeedSampleData();
app.SaveData();
Console.WriteLine("Initial data saved.");

// Clear in-memory data to simulate new session
var freshApp = new InventoryApp();
freshApp.LoadData();
freshApp.PrintAllItems();