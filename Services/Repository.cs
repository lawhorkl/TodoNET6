using System.Linq.Expressions;


namespace TodoNET6.Services
{
    public interface IEntity<TIndex>
    {
        TIndex Id { get; set; }
    }

    public interface IRepository<TEntity, TIndex>
        where TEntity : IEntity<TIndex>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> FetchAsync(TIndex index);
        Task<IEnumerable<TEntity>> WhereAsync(
            Expression<Func<TEntity, bool>> predicate
        );
        Task<TEntity> UpdateAsync(TIndex index, TEntity entity);
        Task DeleteAsync(TIndex index);
    }
}