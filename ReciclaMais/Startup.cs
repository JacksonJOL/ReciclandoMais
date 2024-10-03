using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ReciclaMais.Data;
using Microsoft.AspNetCore.Localization;
using ReciclaMais.Services;



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
        services.AddScoped<MessageService>();

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>();

       
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

        // Definindo o idioma
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

        app.UseAuthentication(); 
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
            endpoints.MapControllerRoute(
                name: "message",
                pattern: "{controller=Message}/{action=SendMessage}/{id?}");

        });
        
    }

}
