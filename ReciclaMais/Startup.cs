using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ReciclaMais.Data;
using Microsoft.AspNetCore.Localization;



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

        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new System.Globalization.CultureInfo("pt-BR") };
            options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        services.AddControllersWithViews()
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();

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

        // Definindo culturas suportadas
        var supportedCultures = new[] { new CultureInfo("pt-BR") };
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("pt-BR"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };

        // Aplicando a configuração de localização
        app.UseRequestLocalization(localizationOptions);
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
