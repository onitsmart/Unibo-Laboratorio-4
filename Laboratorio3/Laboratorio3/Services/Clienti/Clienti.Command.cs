using System;
using System.Threading.Tasks;

namespace Laboratorio3.Services.Clienti
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
            // ES2 Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return Guid.NewGuid();
        }

        public async Task Handle(DeleteClienteCommand cmd)
        {
            // ES2 Implementare logica eliminazione cliente

            return;
        }
    }
}
