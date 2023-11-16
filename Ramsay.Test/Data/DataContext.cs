using Microsoft.EntityFrameworkCore;
using Ramsay.Test.Data.Models;

namespace Ramsay.Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<StudentModel> Student { get; set; }
    }
}