using HelloEntityFramework.Entities;

namespace HelloEntityFramework.Data;

public abstract class BaseRepository<TEntity> where TEntity : Entity
{
    public HelloEntityFrameworkContext Context { get; }

    public BaseRepository(HelloEntityFrameworkContext context)
    {
        Context = context;
    }

    public TEntity? FindById(long id) => Context
        .Set<TEntity>()
        .Where(entity => entity.Id == id)
        .FirstOrDefault();
}
