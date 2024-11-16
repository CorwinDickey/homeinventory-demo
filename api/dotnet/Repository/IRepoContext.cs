using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository
{
    /// <summary>
    /// Defines the DbContext for the application
    /// </summary>
    public interface IRepoContext
    {
        /// <summary>
        /// Overrides the standard SaveChangesAsync method to implement audit
        /// tracking
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the async call</param>
        /// <returns>Count of saved entity changes</returns>
        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a queryable set of entities from the context
        /// </summary>
        /// <typeparam name="T">Entity to query for</typeparam>
        /// <returns><see cref="IQueryable{T}"/></returns>
        IQueryable<T> Get<T>()
            where T : class;

        /// <summary>
        /// Adds an entity into the context asynchronously
        /// </summary>
        /// <param name="entity">Entity to add to the context</param>
        /// <param name="cancellationToken">Cancellation token for async request</param>
        /// <returns>Entity added to the context</returns>
        ValueTask<EntityEntry> AddAsync(
            object entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a range of entities to the context asynchronously
        /// </summary>
        /// <param name="entities">List of entities to add to the context</param>
        /// <param name="cancellationToken">Cancellation token for async request</param>
        /// <returns>Range of entities added to the context</returns>
        Task AddRangeAsync(
            IEnumerable<object> entities, CancellationToken cancellationToken = default);
    }
}
