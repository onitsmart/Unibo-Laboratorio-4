using System;
using System.Threading.Tasks;

namespace Laboratorio2.Services.Clienti
{
    public class AddOrUpdateClienteCommand
    {
    }

    public partial class ClientiService
    {
        public async Task<Guid> Handle(AddOrUpdateClienteCommand cmd)
        {
            // Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return Guid.NewGuid();
        }
    }
}
