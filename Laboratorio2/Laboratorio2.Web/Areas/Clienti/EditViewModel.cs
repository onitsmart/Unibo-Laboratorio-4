using Laboratorio2.Services.Clienti;
using System;

namespace Laboratorio2.Web.Areas.Clienti
{
    public class EditViewModel
    {
        public Guid? Id { get; set; }

        public void SetCliente(DettaglioClienteDTO cliente)
        {
            throw new NotImplementedException();
        }

        public AddOrUpdateClienteCommand ToAddOrUpdateClienteCommand()
        {
            return new AddOrUpdateClienteCommand();
        }
    }
}
