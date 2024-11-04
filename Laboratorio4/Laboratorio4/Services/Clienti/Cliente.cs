using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio4.Services.Clienti
{
    public class Cliente
    {
        // ES2.1 Aggiunta proprietà del cliente

        [Key]
        public Guid Id { get; set; }

        public string RagioneSocialeONominativo { get; set; }
    }

    public enum StatoCliente
    {
        Bozza = 1,
        Confermato = 2,
        Attivo = 3,
        Obsoleto = 4
    }
}
