using Microsoft.EntityFrameworkCore;
using PeopleAPI.Models;

namespace PeopleAPI.Persistence;

public class PeopleDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("PeopleDatabase");
}