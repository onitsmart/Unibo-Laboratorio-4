using Laboratorio4.Services.Clienti;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio4.Web.Areas.Clienti.Clienti
{
    public class EditViewModel
    {
        public List<SelectListItem> StatiCliente { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = ((int)StatoCliente.Bozza).ToString(), Text = "Bozza" },
            new SelectListItem { Value = ((int)StatoCliente.Confermato).ToString(), Text = "Confermato"  },
            new SelectListItem { Value = ((int)StatoCliente.Attivo).ToString(), Text = "Attivo"  },
            new SelectListItem { Value = ((int)StatoCliente.Obsoleto).ToString(), Text = "Obsoleto"  }
        };

        public Guid? Id { get; set; }

        [Display(Name = "Ragione sociale / Nominativo")]
        public string RagioneSocialeONominativo { get; set; }

        [Display(Name = "Stato")]
        public StatoCliente Stato { get; set; }

        [Display(Name = "Capitale sociale")]
        public decimal? CapitaleSociale { get; set; }

        [Display(Name = "Ragione sociale di fatturazione")]
        public string RagioneSocialeFatturazione { get; set; }

        [Display(Name = "Partita IVA")]
        public string PIVA { get; set; }

        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }

        [Display(Name = "Città")]
        public string CAP { get; set; }

        [Display(Name = "Comune")]
        public string Comune { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Data primo ordine")]
        public DateTime? DataPrimoOrdine { get; set; }
        public string DataPrimoOrdineAsString { get; set; }

        public void SetCliente(DettaglioClienteDTO cliente)
        {
            // ES4 Implementare modello
            this.Id = cliente.Id;
            this.RagioneSocialeONominativo = cliente.RagioneSocialeONominativo;
            this.Stato = cliente.Stato;
            this.CapitaleSociale = cliente.CapitaleSociale;
            this.RagioneSocialeFatturazione = cliente.RagioneSocialeFatturazione;
            this.PIVA = cliente.PIVA;
            this.Indirizzo = cliente.Indirizzo;
            this.CAP = cliente.CAP;
            this.Comune = cliente.Comune;
            this.Provincia = cliente.Provincia;
            this.Note = cliente.Note;
            this.DataPrimoOrdine = cliente.DataPrimoOrdine;
            this.DataPrimoOrdineAsString = cliente.DataPrimoOrdine?.ToString();
        }

        public AddOrUpdateClienteCommand ToAddOrUpdateClienteCommand()
        {
            // ES5 ES6 Implementare creazione comando a partire dai dati del modello
            return new AddOrUpdateClienteCommand
            {
                Id = this.Id,
                RagioneSocialeONominativo = this.RagioneSocialeONominativo,
                Stato = this.Stato,
                CapitaleSociale = this.CapitaleSociale,
                RagioneSocialeFatturazione = this.RagioneSocialeFatturazione,
                PIVA = this.PIVA,
                Indirizzo = this.Indirizzo,
                CAP = this.CAP,
                Comune = this.Comune,
                Provincia = this.Provincia,
                Note = this.Note,
                DataPrimoOrdine = this.DataPrimoOrdine
            };
        }
    }
}
