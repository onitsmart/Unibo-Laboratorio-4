using Laboratorio3.Infrastructure;
using Laboratorio3.Services.Clienti;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Laboratorio3.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // ES2 Registrazione dbContext
            services.AddDbContext<ClientiDbContext>(options =>
            {
                // ES2 SOLO PER ESERCITAZIONE. E' UN DATABASE IN MEMORY.
                // Se avessimo un vero databse, qui configureremmo la connessione al database con informazioni prese dagli appsettings (la connectionstring del db)
                options.UseInMemoryDatabase(databaseName: "Clienti");
                //options.UseSqlServer(appSettings.ConnectionString);
            });

            var builder = services.AddMvc();

            // ES3 Decommenta per usare localizzazione
            //builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //    .AddDataAnnotationsLocalization(options =>
            //    {   // Enable loading SharedResource for ModelLocalizer
            //        options.DataAnnotationLocalizerProvider = (type, factory) =>
            //            factory.Create(typeof(SharedResource));
            //    });

#if DEBUG
            builder.AddRazorRuntimeCompilation();
#endif

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Features/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/Shared/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            Container.RegisterTypes(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // ES3 Decommenta per usare localizzazione
            //app.UseRequestLocalization(SupportedCultures.CultureNames);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("Clienti", "Clienti", "Clienti/{controller=Clienti}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    // ES3 Decommenta per usare localizzazione
    //public static class SupportedCultures
    //{
    //    public readonly static string[] CultureNames;
    //    public readonly static CultureInfo[] Cultures;

    //    static SupportedCultures()
    //    {
    //        CultureNames = new[] { "it-it", "en-gb" };
    //        Cultures = CultureNames.Select(c => new CultureInfo(c)).ToArray();

    //        //NB: attenzione nel progetto a settare correttamente <NeutralLanguage>it-IT</NeutralLanguage>
    //    }
    //}
}
