namespace ProiectOBS.Models
{
    public class Withdrawal
    {
        public int Id { get; set; }

        public int Card { get; set; }

        public string? Bank { get; set; }

        public DateTime Date { get; set; }

        public int? Amount { get; set; }
    }
}
