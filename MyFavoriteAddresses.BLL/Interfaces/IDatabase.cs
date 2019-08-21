using System.Collections.Generic;

namespace MyFavoriteAddresses.BLL.Interfaces
{
    /// <summary>
    /// Basic database factory interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDatabase<T>
    {
        List<T> GetItems();

        void StoreItem(T item);
    }
}