using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task AddRange(IList<T> entity);
        void Update(T entity);
        Task DeleteById(Guid id);
        void Delete(T entity);
    }
}