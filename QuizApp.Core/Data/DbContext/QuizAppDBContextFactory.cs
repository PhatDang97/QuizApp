using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QuizApp.Core.Data
{
    public class QuizAppDBContextFactory : IDesignTimeDbContextFactory<QuizAppDBContext>
    {
        public QuizAppDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            var connectionString = configuration.GetConnectionString("QuizAppDB");
            var optionsBuilder = new DbContextOptionsBuilder<QuizAppDBContext>();
            object value = optionsBuilder.UseSqlServer(connectionString);

            return new QuizAppDBContext(optionsBuilder.Options);
        }
    }
}
