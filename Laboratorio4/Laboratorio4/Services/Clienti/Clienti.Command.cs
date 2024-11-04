using System;
using System.Threading.Tasks;

namespace Laboratorio4.Services.Clienti
{
    public class AddOrUpdateClienteCommand
    {
        public Guid Id { get; set; }
        public string RagioneSocialeONominativo { get; set; }
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
            // ES6 Modificare codice per gestire salvataggio nuovo cliente

            return Guid.NewGuid();
        }

        public async Task Handle(DeleteClienteCommand cmd)
        {
            // ES7 Implementare logica eliminazione cliente

            return;
        }
    }
}
