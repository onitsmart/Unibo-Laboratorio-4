using Laboratorio2.Services.Clienti;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Onit.AspNetCore.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Laboratorio2.Web.Areas.Clienti
{
    public class ClientiController : Controller
    {
        private readonly ClientiService _clientiService;

        public ClientiController(ClientiService clientiService)
        {
            _clientiService = clientiService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(IndexViewModel model)
        {
            var clienti = await _clientiService.Query(model.ToClientiInElencoQuery());
            model.SetClienti(clienti);

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> New()
        {
            return RedirectToAction();
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? idCliente)
        {
            var model = new EditViewModel();

            if (idCliente.HasValue)
            {
                var cliente = await _clientiService.Query(new DettaglioClienteQuery { Id = idCliente });
                model.SetCliente(cliente);
            }

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Validazioni complesse (opzionali) da mettere nel comando
                    model.Id = await _clientiService.Handle(model.ToAddOrUpdateClienteCommand());
                    Alerts.AddSuccess(this, "Informazioni aggiornate");
                }
                catch (Exception e)
                {
                }
            }

            if (ModelState.IsValid == false)
            {
                Alerts.AddError(this, "Errore in aggiornamento");
            }

            return RedirectToAction(Actions.Edit(model.Id?.ToString()));
        }

    }
}
