using Laboratorio4.Services.Clienti;
using Microsoft.Extensions.DependencyInjection;

namespace Laboratorio4.Web
{
    public class Container
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            // ES2 Registrazione servizio per clienti
            container.AddScoped<ClientiService>();
        }
    }
}
