using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Notes.DB;
using Notes.DB.Repository;
using Notes.Domain.Services;

namespace Notes.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages(); 
            builder.Services.AddDbContext<NotesDbContext>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IEncryptionService,EncryptionService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => 
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login");
        });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
