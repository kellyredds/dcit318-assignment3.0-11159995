using System;
using System.Collections.Generic;
using WarehouseInventory.Exceptions;
using WarehouseInventory.Models;

namespace WarehouseInventory.Repositories
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private readonly Dictionary<int, T> _items = new();

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
                throw new DuplicateItemException($"Item with ID {item.Id} already exists");
            _items.Add(item.Id, item);
        }

        public T GetItemById(int id)
        {
            if (!_items.TryGetValue(id, out var item))
                throw new ItemNotFoundException($"Item with ID {id} not found");
            return item;
        }

        public void RemoveItem(int id)
        {
            if (!_items.ContainsKey(id))
                throw new ItemNotFoundException($"Cannot remove - Item with ID {id} not found");
            _items.Remove(id);
        }

        public List<T> GetAllItems() => new(_items.Values);

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
                throw new InvalidQuantityException("Quantity cannot be negative");

            var item = GetItemById(id);
            item.Quantity = newQuantity;
        }
    }
}