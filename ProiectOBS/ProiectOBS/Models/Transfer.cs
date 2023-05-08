namespace ProiectOBS.Models
{
    public class Transfer
    {
        public int Id { get; set; }

        public virtual Client? Client { get; set; }
        public int ClientId1 { get; set; }

        public int IBAN { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
