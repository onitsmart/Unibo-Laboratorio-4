﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio3.Services.Clienti
{
    public class Cliente
    {
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
