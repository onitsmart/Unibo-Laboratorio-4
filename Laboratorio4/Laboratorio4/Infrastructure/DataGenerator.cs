using Laboratorio4.Services.Clienti;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Laboratorio4.Infrastructure
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
                    RagioneSocialeONominativo = "Pippo spa",
                    Indirizzo = "Via Roma 1",
                    Comune = "Roma",
                    Provincia = "RM",
                    CapitaleSociale = 10000,
                    DataPrimoOrdine = DateTime.Now,
                    Stato = StatoCliente.Attivo,
                    CAP = "00100",
                    PIVA = "12345678901",
                    RagioneSocialeFatturazione = "Pippo spa",
                    Note = "Note di Pippo"
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    RagioneSocialeONominativo = "Pluto High Quality Software srl",
                    Indirizzo = "Via Milano 2",
                    Comune = "Milano",
                    Provincia = "MI",
                    CapitaleSociale = 20000,
                    DataPrimoOrdine = DateTime.Now,
                    Stato = StatoCliente.Attivo,
                    CAP = "20100",
                    PIVA = "98765432109",
                    RagioneSocialeFatturazione = "Pluto High Quality Software srl",
                    Note = "Note di Pluto"
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    RagioneSocialeONominativo = "Paperino & co",
                    Indirizzo = "Via Napoli 3",
                    Comune = "Napoli",
                    Provincia = "NA",
                    CapitaleSociale = 30000,
                    DataPrimoOrdine = DateTime.Now,
                    Stato = StatoCliente.Obsoleto,
                    CAP = "30100",
                    PIVA = "12309845670",
                    RagioneSocialeFatturazione = "Paperino & co",
                    Note = "Note di Paperino"
                });

            context.SaveChanges();
        }
    }
}
