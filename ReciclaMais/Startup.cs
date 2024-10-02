using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        services.AddRazorPages();

        // Mantenha apenas uma configuração de Identity
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        // Remova a segunda chamada do AddIdentity
        // services.AddIdentity<IdentityUser, IdentityRole>()
        //     .AddEntityFrameworkStores<ApplicationDbContext>()
        //     .AddDefaultTokenProviders();
    }

    // Configuração do pipeline de requisição HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // Certifique-se de que isso esteja aqui
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}"); // Mudar para Account/Login
        });
    }

}
