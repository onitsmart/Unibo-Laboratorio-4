using Laboratorio3.Services.Clienti;
using Microsoft.Extensions.DependencyInjection;

namespace Laboratorio3.Web
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
