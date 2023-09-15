using Laboratorio2.Services.Clienti;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace Laboratorio2.Web.Areas.Clienti
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Clienti = Array.Empty<ClienteInElencoViewModel>();
            this.StatiCliente = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = StatoCliente.Bozza.ToString(),
                    Value = ((int)StatoCliente.Bozza).ToString()
                },
                new SelectListItem
                {
                    Text = StatoCliente.Confermato.ToString(),
                    Value = ((int)StatoCliente.Confermato).ToString()
                },
                new SelectListItem
                {
                    Text = StatoCliente.Attivo.ToString(),
                    Value = ((int)StatoCliente.Attivo).ToString()
                },
                new SelectListItem
                {
                    Text = StatoCliente.Obsoleto.ToString(),
                    Value = ((int)StatoCliente.Obsoleto).ToString()
                },
            };
        }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }

        [Display(Name = "Stato")]
        public StatoCliente? FiltroStatoCliente { get; set; }

        public List<SelectListItem> StatiCliente { get; set; }

        public ClienteInElencoViewModel[] Clienti { get; set; }

        public int TotaleElementi { get; set; }

        internal void SetClienti(ClientiInElencoDTO dto)
        {
            StatiCliente = new List<SelectListItem>
            {
                new SelectListItem { Value = String.Empty,Text = String.Empty },
                new SelectListItem { Value = ((int)StatoCliente.Bozza).ToString(), Text = "Bozza" },
                new SelectListItem { Value = ((int)StatoCliente.Confermato).ToString(), Text = "Confermato" },
                new SelectListItem { Value = ((int)StatoCliente.Attivo).ToString(), Text = "Attivo" },
                new SelectListItem { Value = ((int)StatoCliente.Obsoleto).ToString(), Text = "Obsoleto" }
            };

            Clienti = dto.Clienti.Select(x => new ClienteInElencoViewModel(x)).ToArray();
            TotaleElementi = dto.ElementiTotali;
        }

        public ClientiInElencoQuery ToClientiInElencoQuery()
        {
            return new ClientiInElencoQuery
            {
                Filtro = this.Filtro,
                FiltroStatoCliente = this.FiltroStatoCliente
            };
        }

        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }
    }

    public class ClienteInElencoViewModel
    {
        public ClienteInElencoViewModel() { }

        public ClienteInElencoViewModel(ClienteInElencoDTO dto)
        {
            // Valorizzare proprietà da dto
        }

        public string UrlEdit { get; set; }

        public string Id { get; set; }

        [Display(Name = "Ragione sociale / Nominativo")]
        public string RagioneSocialeONominativo { get; set; }

        [Display(Name = "Ragione sociale")]
        public string RagioneSociale { get; set; }

        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }

        [Display(Name = "Città")]
        public string Citta { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Capitale sociale")]
        public decimal? CapitaleSociale { get; set; }

        [Display(Name = "Data primo ordine")]
        public DateTime? DataPrimoOrdine { get; set; }
        public string DateDataPrimoOrdineAsString { get; set; }

        [Display(Name = "Stato")]
        public StatoCliente Stato { get; set; }
    }
}
