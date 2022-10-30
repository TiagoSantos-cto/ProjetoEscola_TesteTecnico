using Escola.Domain.Queries;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly EscolaDbContext context;

        public BaseRepository(EscolaDbContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T?> Get(int id) 
            => await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(BaseQueries<T>.GetById(id));

        public async Task<IEnumerable<T>?> GetAll() 
            => await context.Set<T>().AsNoTracking().ToListAsync();

        public async Task Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
