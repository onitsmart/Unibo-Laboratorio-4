using System;
using System.Threading.Tasks;

namespace Laboratorio3.Services.Clienti
{
    public class AddOrUpdateClienteCommand
    {
    }

    public class DeleteClienteCommand
    {
    }

    public partial class ClientiService
    {
        public async Task<Guid> Handle(AddOrUpdateClienteCommand cmd)
        {
            // Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return Guid.NewGuid();
        }

        public async Task Handle(DeleteClienteCommand cmd)
        {
            // Implementare logica eliminazione cliente

            return;
        }
    }
}
