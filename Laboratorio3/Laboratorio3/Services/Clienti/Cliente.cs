namespace Laboratorio3.Services.Clienti
{
    public class Cliente
    {
        // Aggiungere le proprietà che si vogliono gestire sul cliente.
        // Aggiungere gli attributi [Key], [DatabaseGenerated(DatabaseGeneratedOption.Identity)] sulla chiave (il secondo solo se usate un'identity a db)
        // Aggiungere attributi [ForeignKey("IdCliente")] [InverseProperty("Tags")] per costruire navigations su tabelle collegate tramite foreign key
    }

    public enum StatoCliente
    {
        Bozza = 1,
        Confermato = 2,
        Attivo = 3,
        Obsoleto = 4
    }

    public enum AreaCliente
    {
        Privati = 1,
        PA = 2,
        Industria = 3,
        Sanità = 4
    }
}
