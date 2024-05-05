namespace JobTitle.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get item by id.
        /// </summary>
        /// <param name="id">Item's identifier</param>
        /// <returns>Item with a matching id</returns>
        T GetById(int id);
        /// <summary>
        /// Get item by id.
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <returns>Item with a matching name</returns>
        T GetByName(string name);
        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns>Collection of items</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Create item.
        /// </summary>
        /// <param name="item">Item for create</param>
        /// <returns><see langword="true"/> if item was created, otherwise <see langword="false"/></returns>
        bool Create(T item);
        /// <summary>
        /// Update already existed item.
        /// </summary>
        /// <param name="item">Item for update</param>
        /// <returns><see langword="true"/> if item was updated, otherwise <see langword="false"/></returns>
        bool Update(T item);
        /// <summary>
        /// Delete already existed item by id.
        /// </summary>
        /// <param name="id">Item for delete</param>
        /// <returns><see langword="true"/> if item was deleted, otherwise <see langword="false"/></returns>
        bool Delete(int id);
    }
}
