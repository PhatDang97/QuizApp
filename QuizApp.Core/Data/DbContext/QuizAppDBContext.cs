using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Data.Extensions;
using System.Reflection;

namespace QuizApp.Core.Data
{
    public class QuizAppDBContext : DbContext
    {
        public QuizAppDBContext()
        {

        }

        public QuizAppDBContext(DbContextOptions<QuizAppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();
        }
    }
}
