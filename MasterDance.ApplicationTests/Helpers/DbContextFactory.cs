using System;
using MasterDance.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.ApplicationTests.Helpers
{
    internal class DbContextFactory : IDisposable
    {
        private readonly SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");

        public DbContextFactory()
        {
            _connection.Open();
        }

        internal MasterDanceDbContext GetContext()
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<MasterDanceDbContext>();
            optionsBuilder.UseSqlite(_connection);
            var context = new MasterDanceDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
            return context;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}