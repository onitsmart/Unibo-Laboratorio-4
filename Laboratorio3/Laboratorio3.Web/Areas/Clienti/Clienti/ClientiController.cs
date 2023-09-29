using Laboratorio3.Services.Clienti;
using Microsoft.AspNetCore.Mvc;
using Onit.AspNetCore.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Laboratorio3.Web.Areas.Clienti.Clienti
{
    [Area("Clienti")]
    public partial class ClientiController : Controller
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
            var model = new EditViewModel();
            return View(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? idCliente)
        {
            var model = new EditViewModel();

            if (idCliente.HasValue)
            {
                var cliente = await _clientiService.Query(new DettaglioClienteQuery { IdCliente = idCliente.Value });
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

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await _clientiService.Handle(new DeleteClienteCommand { Id = id });
            Alerts.AddSuccess(this, "Eliminazione effettuata correttamente");
            return RedirectToAction(Actions.Index());
        }
    }
}
