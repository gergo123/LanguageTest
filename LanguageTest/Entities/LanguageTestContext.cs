using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Entities;

public class LanguageTestContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public LanguageTestContext(DbContextOptions<LanguageTestContext> options) :
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Blog>()
        //    .HasKey(x => x.Id);
    }
}
