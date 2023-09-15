using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laboratorio2.Services.Clienti
{
    public class ClientiInElencoQuery
    {
        public string Filtro { get; set; }

        public StatoCliente? FiltroStatoCliente { get; set; }
    }

    public class ClientiInElencoDTO
    {
        public IEnumerable<ClienteInElencoDTO> Clienti { get; set; }
        public int ElementiTotali { get; set; }
    }

    public class ClienteInElencoDTO
    {
    }

    public class DettaglioClienteQuery
    {
        public Guid IdCliente { get; set; }
    }

    public class DettaglioClienteInElencoDTO
    {
    }

    public partial class ClientiService
    {
        public async Task<ClientiInElencoDTO> Query(ClientiInElencoQuery qry)
        {
            // Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return null;
        }

        public async Task<DettaglioClienteInElencoDTO> Query(DettaglioClienteQuery qry)
        {
            // Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return null;
        }
    }
}
