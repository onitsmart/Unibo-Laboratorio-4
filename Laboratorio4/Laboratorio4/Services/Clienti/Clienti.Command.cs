using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4.Services.Clienti
{
    public class AddOrUpdateClienteCommand
    {
        public Guid? Id { get; set; }
        public string RagioneSocialeONominativo { get; set; }
        public string Indirizzo { get; set; }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public decimal? CapitaleSociale { get; set; }
        public DateTime? DataPrimoOrdine { get; set; }
        public StatoCliente Stato { get; set; }
        public string RagioneSocialeFatturazione { get; set; }
        public string PIVA { get; set; }
        public string CAP { get; set; }
        public string Note { get; set; }
    }

    public class DeleteClienteCommand
    {
        public Guid Id { get; set; }
    }

    public partial class ClientiService
    {
        public async Task<Guid> Handle(AddOrUpdateClienteCommand cmd)
        {
            // ES5 Implementare logica aggiornamento cliente esistente
            // IMPORTANTE - Non mettere una Select, altrimenti le modifiche non verranno persistite sul database

            // ES6 Modificare codice per gestire salvataggio nuovo cliente
            Cliente cliente = null;

            if (cmd.Id is not null)
            {
                cliente = await _dbContext.Clienti
                    .Where(x => x.Id == cmd.Id)
                    .FirstOrDefaultAsync();
            }
            else
            {
                cliente = new Cliente
                {
                    Id = Guid.NewGuid()
                };
                _dbContext.Clienti.Add(cliente);
            }

            cliente.RagioneSocialeONominativo = cmd.RagioneSocialeONominativo;
            cliente.Indirizzo = cmd.Indirizzo;
            cliente.Comune = cmd.Comune;
            cliente.Provincia = cmd.Provincia;
            cliente.CapitaleSociale = cmd.CapitaleSociale;
            cliente.DataPrimoOrdine = cmd.DataPrimoOrdine;
            cliente.Stato = cmd.Stato;
            cliente.RagioneSocialeFatturazione = cmd.RagioneSocialeFatturazione;
            cliente.PIVA = cmd.PIVA;
            cliente.CAP = cmd.CAP;
            cliente.Note = cmd.Note;

            await _dbContext.SaveChangesAsync();

            return cliente.Id;
        }

        public async Task Handle(DeleteClienteCommand cmd)
        {
            // ES7 Implementare logica eliminazione cliente
            var cliente = await _dbContext.Clienti
                    .Where(x => x.Id == cmd.Id)
                    .FirstOrDefaultAsync();

            if (cliente is not null)
            {
                // CANCELLAZIONE FISICA
                _dbContext.Clienti.Remove(cliente);

                // ALTERNATIVA ALLA RIGA SOPRA, CON CANCELLAZIONE LOGICA
                // In questo caso bisogna mettere mano alle queries di elenco e dettaglio per far si che se il cliente è obsoleto non venga mostrato in elenco
                // cliente.Stato = StatoCliente.Obsoleto;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
