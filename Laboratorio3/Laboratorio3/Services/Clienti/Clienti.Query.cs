using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Services.Clienti
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
    }

    public class DettaglioClienteQuery
    {
        public Guid IdCliente { get; set; }
    }

    public class DettaglioClienteDTO
    {
    }

    public partial class ClientiService
    {
        public async Task<ClientiInElencoDTO> Query(ClientiInElencoQuery qry)
        {
            // ES2 Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return null;
        }

        public async Task<DettaglioClienteDTO> Query(DettaglioClienteQuery qry)
        {
            // ES2 Implementare logica salvataggio nuovo cliente o aggiornamento cliente esistente

            return null;
        }
    }
}
