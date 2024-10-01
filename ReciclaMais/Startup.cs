using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReciclaMais.Data;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public IConfiguration Configuration { get; }

    // Configuração dos serviços da aplicação
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddControllersWithViews();
    }

    // Configuração do pipeline de requisição HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            // Apaga e recria o banco de dados automaticamente quando o aplicativo é iniciado
            context.Database.EnsureDeleted();  // Apaga o banco de dados se ele existir
            context.Database.EnsureCreated();  // Recria o banco de dados
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");// Aqui definimos o HomeController como o padrão
        });
    }


}
