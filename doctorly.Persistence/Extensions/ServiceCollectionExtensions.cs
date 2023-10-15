using doctorly.Persistence.Managers;
using doctorly.Persistence.Managers.Impl;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace doctorly.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDoctorylyPersistence(this IServiceCollection services, string connectionString)
        {

            if (connectionString.Equals(Constants.InMemoryConnection, StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddSharedInMemorySqliteContext<DoctorlyContext>();
            }
            else
            {
                services.AddSqlServerContext(connectionString);
            }

            services.AddManagers();
        }

        private static void AddSqlServerContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DoctorlyContext>(options =>
            {
                options.UseSqlServer(connectionString, options => options.CommandTimeout(120));
            });
        }

        private static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IEventManager, EventManager>();
        }

        private static void AddSharedInMemorySqliteContext<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null) where TContext : DbContext
        {
            Action<DbContextOptionsBuilder> optionsAction2 = optionsAction;
            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            defaultInterpolatedStringHandler.AppendFormatted(Guid.NewGuid());
            defaultInterpolatedStringHandler.AppendLiteral(".db");
            string dataSource = defaultInterpolatedStringHandler.ToStringAndClear();
            SqliteConnectionStringBuilder sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = dataSource,
                Mode = SqliteOpenMode.Memory,
                Cache = SqliteCacheMode.Shared
            };
            SqliteConnection connection = new SqliteConnection(sqliteConnectionStringBuilder.ConnectionString);
            connection.Open();
            connection.EnableExtensions();
            services.AddDbContext<TContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseSqlite(connection);
                optionsAction2?.Invoke(options);
            });
        }
    }
}
