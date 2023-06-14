using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly QuizAppDBContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(QuizAppDBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await _entities.ToListAsync();

            }
            catch(Exception ex)
            {

            }
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRange(IList<T> entity)
        {
            await _entities.AddRangeAsync(entity);
        }

        public void Update(T entity)
        {
            //_context.ChangeTracker.Clear();
            //_context.Entry(entity).State = EntityState.Detached;
            _entities.Update(entity);
        }

        public async Task DeleteById(Guid id)
        {
            //_context.ChangeTracker.Clear();
            T entity = await GetById(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public void Delete(T entity)
        {
            //_context.ChangeTracker.Clear();
            _entities.Remove(entity);
        }
    }
}
