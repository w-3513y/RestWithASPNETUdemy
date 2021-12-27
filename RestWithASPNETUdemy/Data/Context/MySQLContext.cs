using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Model;

namespace RestWithASPNETUdemy.Data.Context;

public class MySQLContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public MySQLContext(DbContextOptions<MySQLContext> options)
    : base(options)
    {
    }


}