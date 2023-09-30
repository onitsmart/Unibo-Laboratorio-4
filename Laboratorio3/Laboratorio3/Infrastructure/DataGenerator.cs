using Laboratorio3.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Laboratorio3.Infrastructure
{
    public class DataGenerator
    {
        // ES2 SOLO PER ESERCITAZIONE. Questo metodo inserisce utenti nel db in memory. Valorizzate i campi dell'entità cliente via via che ne aggiungete
        public static void InitializeClienti(ClientiDbContext context)
        {
            if (context.Clienti.Any())
            {
                return;   // Data was already seeded
            }

            // ES2.1 Aggiunta proprietà del cliente
            context.Clienti.AddRange(
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    RagioneSocialeONominativo = "Pippo spa"
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    RagioneSocialeONominativo = "Pluto High Quality Software srl"
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    RagioneSocialeONominativo = "Paperino & co"
                });

            context.SaveChanges();
        }
    }
}
