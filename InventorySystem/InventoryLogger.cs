using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventorySystem.Models;

namespace InventorySystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath = "inventory.json")
        {
            _filePath = filePath;
        }

        public void Add(T item) => _log.Add(item);

        public List<T> GetAll() => new(_log);

        public void SaveToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_log, options);
            File.WriteAllText(_filePath, json);
        }

        public void LoadFromFile()
        {
            if (!File.Exists(_filePath)) return;

            string json = File.ReadAllText(_filePath);
            var items = JsonSerializer.Deserialize<List<T>>(json);
            
            _log.Clear();
            if (items != null) _log.AddRange(items);
        }
    }
}