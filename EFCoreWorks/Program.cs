using EFCoreWorks.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWorks;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("! This is the app, that works.");

        await using (var context = new MyDbContext())
        {
            Console.WriteLine("Ensure DB exists.");
            await context.Database.EnsureCreatedAsync().ConfigureAwait(false);
        }

        await using (var context = new MyDbContext())
        {
            Console.WriteLine("Seed.");
            var tenant = new TenantEntity { Id = Guid.NewGuid(), Name = "Tenant" };
            var user = new UserEntity { Id = Guid.NewGuid(), Name = "User" };
            var association = new TenantUserAssociationEntity { Tenant = tenant, User = user };

            context.Tenants.Add(tenant);
            context.Users.Add(user);
            context.TenantUserAssociations.Add(association);

            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        await using (var context = new MyDbContext())
        {
            // This works

            Console.Write("Tenants: ");
            var tenants = await context.Tenants.ToListAsync().ConfigureAwait(false);
            Console.Write(tenants.Count);
            Console.WriteLine();
        }

        await using (var context = new MyDbContext())
        {
            // This hangs forever

            Console.Write("Projections: ");
            var userProjections = await context.Users
             .Select(u => new
             {
                 UserId = u.Id,
                 Tenants = u.TenantUserAssociations.Select(ta => new
                 {
                     TenantId = ta.Tenant.Id,
                     TenantName = ta.Tenant.Name
                 })
             }).ToListAsync();

            Console.Write(userProjections.Count);
            Console.WriteLine();
        }


        Console.WriteLine("Done.");
    }
}