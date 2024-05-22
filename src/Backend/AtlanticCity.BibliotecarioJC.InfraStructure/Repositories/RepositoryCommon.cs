using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Repositories
{
    public class RepositoryCommon<TEntity> : IRepositoryCommon<TEntity> where TEntity : class
    {
        public readonly BibliotecarioContext _context;

        public RepositoryCommon(BibliotecarioContext context)
        {
            _context = context;
        }

        public async ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).AnyAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity FindById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async ValueTask<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> FromSQLRawAsync(FormattableString sql, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FromSql<TEntity>(sql).ToListAsync(cancellationToken);
        }

        public IReadOnlyList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}