using System;

namespace TamagotchiMauiApp
{
    public interface IDataStore<T>
    {
        Task<bool> CreateItem(T item);
        Task<T> ReadItem();
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(T item);
	}
}
