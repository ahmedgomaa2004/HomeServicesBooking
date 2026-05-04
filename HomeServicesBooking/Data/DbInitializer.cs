using HomeServicesBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!await context.Services.AnyAsync())
        {
            context.Services.AddRange(
                new Service
                {
                    Name = "سباكة",
                    Description = "إصلاح وصيانة أعمال السباكة المنزلية"
                },
                new Service
                {
                    Name = "كهرباء",
                    Description = "أعمال الكهرباء والتمديدات المنزلية"
                },
                new Service
                {
                    Name = "نجارة",
                    Description = "إصلاح وتصنيع الأثاث والأبواب"
                },
                new Service
                {
                    Name = "تكييف",
                    Description = "تركيب وصيانة وتنظيف أجهزة التكييف"
                },
                new Service
                {
                    Name = "دهانات",
                    Description = "أعمال الدهانات الداخلية والخارجية"
                });
        }

        if (!await context.AdminUsers.AnyAsync(admin => admin.Email == "admin@site.com"))
        {
            var admin = new AdminUser
            {
                Email = "admin@site.com"
            };

            admin.PasswordHash = new PasswordHasher<AdminUser>()
                .HashPassword(admin, "Admin@123");

            context.AdminUsers.Add(admin);
        }

        await context.SaveChangesAsync();
    }
}
