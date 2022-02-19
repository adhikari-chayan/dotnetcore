using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T>: IRepository<T> where T : class, IEntity, new()
    {      

        private readonly List<T> _items = new();

        public T CreateItem()
        {
            return new T();
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T? GetById(int id)
        {
            if(id == 0)
                return null;
            return _items.Single(_items => _items.Id == id);
        }
        public void Add(T item) 
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            //Everything is already saved in the list
        }
    }

}
