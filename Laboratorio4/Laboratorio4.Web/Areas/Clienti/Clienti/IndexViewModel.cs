using Laboratorio4.Services.Clienti;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Laboratorio4.Web.Areas.Clienti.Clienti
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Clienti = Array.Empty<ClienteInElencoViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }

        public ClienteInElencoViewModel[] Clienti { get; set; }

        public int TotaleElementi { get; set; }

        internal void SetClienti(ClientiInElencoDTO dto)
        {
            Clienti = dto.Clienti.Select(x => new ClienteInElencoViewModel(x)).ToArray();
            TotaleElementi = dto.ElementiTotali;
        }

        public ClientiInElencoQuery ToClientiInElencoQuery()
        {
            // ES3 Passaggio filtro, già implementato
            return new ClientiInElencoQuery
            {
                Filtro = this.Filtro
            };
        }
    }

    public class ClienteInElencoViewModel
    {
        public ClienteInElencoViewModel() { }

        public ClienteInElencoViewModel(ClienteInElencoDTO dto)
        {
            // ES2 Valorizzare proprietà del modello dal dto passato come parametro
            this.Id = dto.Id;
            this.RagioneSocialeONominativo = dto.RagioneSociale;

            // ES2.1 Aggiunta proprietà del cliente
            this.Indirizzo = dto.Indirizzo;
            this.Comune = dto.Comune;
            this.Provincia = dto.Provincia;
            this.CapitaleSociale = dto.CapitaleSociale;
            this.DataPrimoOrdine = dto.DataPrimoOrdine;
            this.DataPrimoOrdineAsString = dto.DataPrimoOrdine?.ToString();
            this.Stato = dto.Stato;

            // Questo assegnamento funziona in questo caso perchè il nome degli stati ci sta bene come etichetta da mostrare all'utente.
            // Se non ci andasse bene dovremmo usare un attribute da impostare sopra ai singoli valori dello stato nell'enumerazione (visto in lab1 in uno dei test)
            // Altra opzione è controllare ogni singolo stato e impostare di conseguenza il testo:
            // dto.Stato == StatoCliente.Obsoleto ? "Obsoleto" : dto.Stato == ..... e così via per tutti i casi
            this.StatoAsString = dto.Stato.ToString();
        }

        public Guid Id { get; set; }

        [Display(Name = "Ragione sociale / Nominativo")]
        public string RagioneSocialeONominativo { get; set; }

        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }

        [Display(Name = "Comune")]
        public string Comune { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Capitale sociale")]
        public decimal? CapitaleSociale { get; set; }

        [Display(Name = "Data primo ordine")]
        public DateTime? DataPrimoOrdine { get; set; }
        public string DataPrimoOrdineAsString { get; set; }

        [Display(Name = "Stato")]
        public StatoCliente Stato { get; set; }
        public string StatoAsString { get; set; }
    }
}
