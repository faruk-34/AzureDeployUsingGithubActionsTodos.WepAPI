

using Microsoft.EntityFrameworkCore;
using Todos.WepAPI.Models;

namespace Todos.WepAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todo> Todos {get;set;}
    }
}
