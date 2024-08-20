using Microsoft.EntityFrameworkCore;
using backstack.Models;

namespace backstack.Data.Context;

public class MoneyContext : DbContext
{
    public MoneyContext(DbContextOptions<MoneyContext> options) : base(options)
    {
    }

    public DbSet<Money> Money { get; set; }

}