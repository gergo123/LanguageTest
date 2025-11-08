using LanguageTest.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features.Ef;

public class Upsert : IFeature
{
    private readonly LanguageTestContext context;

    public Upsert()
    {
        var connectionString = "server=localhost;user=root;password=root;database=ef";
        var mysqlVersion = ServerVersion.AutoDetect(connectionString);

        var _contextOptions = new DbContextOptionsBuilder<LanguageTestContext>()
            .UseMySql(connectionString, mysqlVersion)
            //.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options;

        context = new LanguageTestContext(_contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public void Action()
    {
        Func<Task> wrapper = async () =>
        {
            Blog[] blogs = [
                new Blog { Name = "Blog1", Url = "http://blog1.com" },
            new Blog { Name = "Blog2", Url = "http://blog2.com" }
            ];
            context.AddRange(blogs);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            // try upserting
            await UpsertNoId(new Blog
            {
                Id = blogs[0].Id,
                Name = blogs[0].Name + " upsert",
                Url = blogs[0].Url // using this as unique ID
            });
            context.SaveChanges();
            context.ChangeTracker.Clear();

            await UpsertNoId(new Blog
            {
                Id = blogs[1].Id,
                Name = blogs[1].Name + " upsert with update",
                Url = "somenewurl"
            });
            context.SaveChanges();

            // non existing
            Blog newBlog = new()
            {
                Name = "non existing",
                Url = "srrromenewurl/123"
            };
            await UpsertNoId(newBlog);
            context.SaveChanges();

            var updated = await context.Blogs
                .Where(x => x.Id == newBlog.Id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(y => y.Name, "blabla")
                );
            Console.WriteLine($"Updated: {updated}");

            context.Dispose();
        };
        wrapper().GetAwaiter().GetResult();
    }

    public void UpsertWithId(Blog entity)
    {
        //context.Entry(entity).CurrentValues.SetValues(entity);
        //context.Update(entity);
    }

    public async Task UpsertNoId(Blog entity)
    {
        Func<Blog, Blog> updateAction = (a) =>
        {
            //await Task.Delay(100);
            //return true;
            var c = new Blog
            {
                Name = a.Name,
                Url = a.Url,
            };

            return c;
        };

        await context.Blogs.Upsert(entity)
            .On(x => x.Id)
            .WhenMatched((db, original) => new Blog
            {
                Name = original.Name,
                Url = db.Url,
            })
            .RunAsync();
    }
}
