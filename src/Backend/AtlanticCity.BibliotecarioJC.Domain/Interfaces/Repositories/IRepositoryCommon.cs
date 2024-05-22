using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories
{
    public interface IRepositoryCommon<TEntity> where TEntity : class
    {
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        ValueTask<IEnumerable<TEntity>> FromSQLRawAsync(FormattableString sql, CancellationToken cancellationToken = default);

        IReadOnlyList<TEntity> GetAll();

        ValueTask<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        ValueTask<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        ValueTask<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        TEntity FindById(int id);

        void Remove(TEntity entity);

        void Update(TEntity entity);
    }
}