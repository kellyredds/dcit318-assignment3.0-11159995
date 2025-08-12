using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem.Repositories
{
    public class Repository<T>
    {
        protected readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => new(items); // Return a copy for encapsulation

        public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);

        public bool Remove(Func<T, bool> predicate)
        {
            var item = GetById(predicate);
            return item != null && items.Remove(item);
        }
    }
}