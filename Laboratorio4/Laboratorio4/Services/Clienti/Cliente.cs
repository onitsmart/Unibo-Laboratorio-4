using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio4.Services.Clienti
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public string RagioneSocialeONominativo { get; set; }

        // ES2.1 Aggiunta proprietà del cliente
        public string Indirizzo { get; set; }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public decimal? CapitaleSociale { get; set; }
        public DateTime? DataPrimoOrdine { get; set; }
        public StatoCliente Stato { get; set; }

        // ES 4 Campi aggiuntivi per il dettaglio del Cliente
        public string RagioneSocialeFatturazione { get; set; }
        public string PIVA { get; set; }
        public string CAP { get; set; }
        public string Note { get; set; }
    }

    public enum StatoCliente
    {
        Bozza = 1,
        Confermato = 2,
        Attivo = 3,
        Obsoleto = 4
    }
}
