using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4.Services.Clienti
{
    public class ClientiInElencoQuery
    {
        public string Filtro { get; set; }
    }

    public class ClientiInElencoDTO
    {
        public IEnumerable<ClienteInElencoDTO> Clienti { get; set; }
        public int ElementiTotali { get; set; }
    }

    public class ClienteInElencoDTO
    {
        public Guid Id { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public decimal? CapitaleSociale { get; set; }
        public DateTime? DataPrimoOrdine { get; set; }
        public StatoCliente Stato { get; set; }
    }

    public class DettaglioClienteQuery
    {
        public Guid IdCliente { get; set; }
    }

    public class DettaglioClienteDTO
    {
        public Guid? Id { get; set; }

        public string RagioneSocialeONominativo { get; set; }

        public StatoCliente Stato { get; set; }

        public decimal? CapitaleSociale { get; set; }

        public string RagioneSocialeFatturazione { get; set; }

        public string PIVA { get; set; }

        public string Indirizzo { get; set; }

        public string CAP { get; set; }

        public string Comune { get; set; }

        public string Provincia { get; set; }

        public string Note { get; set; }

        public DateTime? DataPrimoOrdine { get; set; }
    }

    public partial class ClientiService
    {
        public async Task<ClientiInElencoDTO> Query(ClientiInElencoQuery qry)
        {
            // ES2 Implementare logica caricamento clienti per elenco
            var risultato = new ClientiInElencoDTO();
            var queryable = _dbContext.Clienti.AsQueryable();

            // ES3 Modificare implementazione per gestione filtro
            if (string.IsNullOrWhiteSpace(qry.Filtro) == false)
            {
                var filtri = qry.Filtro.Trim().Split(" ");

                // Il parametro OrdinalIgnoreCase ci serve per non considerare il case dei caratteri quando filtriamo.
                // Se fossimo su un vero database potrebbe essere direttamente il db ad ignorare il case per cui è molto probabile che questo parametro non ci serva. 
                // Nel nostro caso siamo in memoria per cui, se vogliamo essere case-insensitive dobbiamo inserirlo.
                foreach (var filtro in filtri)
                    queryable = queryable.Where(x => x.RagioneSocialeONominativo.Contains(filtro, StringComparison.OrdinalIgnoreCase));
            }

            risultato.Clienti = await queryable
                .Select(x => new ClienteInElencoDTO
                {
                    Id = x.Id,
                    RagioneSociale = x.RagioneSocialeONominativo,

                    // ES2.1 Aggiunta proprietà del cliente
                    Indirizzo = x.Indirizzo,
                    Comune = x.Comune,
                    Provincia = x.Provincia,
                    CapitaleSociale = x.CapitaleSociale,
                    DataPrimoOrdine = x.DataPrimoOrdine,
                    Stato = x.Stato
                }).ToArrayAsync();

            risultato.ElementiTotali = await _dbContext.Clienti.CountAsync();

            return risultato;
        }

        public async Task<DettaglioClienteDTO> Query(DettaglioClienteQuery qry)
        {
            // ES4 Implementare logica caricamento dettaglio cliente

            return await _dbContext.Clienti
                .Where(x => x.Id == qry.IdCliente)
                .Select(x => new DettaglioClienteDTO
                {
                    Id = x.Id,
                    RagioneSocialeONominativo = x.RagioneSocialeONominativo,
                    Stato = x.Stato,
                    CapitaleSociale = x.CapitaleSociale,
                    RagioneSocialeFatturazione = x.RagioneSocialeFatturazione,
                    PIVA = x.PIVA,
                    Indirizzo = x.Indirizzo,
                    CAP = x.CAP,
                    Comune = x.Comune,
                    Provincia = x.Provincia,
                    Note = x.Note,
                    DataPrimoOrdine = x.DataPrimoOrdine
                }).FirstOrDefaultAsync();
        }
    }
}
