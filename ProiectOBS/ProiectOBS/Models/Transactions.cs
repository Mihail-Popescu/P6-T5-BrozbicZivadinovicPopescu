namespace ProiectOBS.Models
{
    public class Transactions
    {

        public int Id { get; set; }

        public virtual Client? Client { get; set; }
        public int ClientId { get; set; }

        public virtual Withdrawal? Withdrawal { get; set; }
        public int WithdrawalId { get; set; }

        public virtual Deposit? Deposit { get; set; }
        public int DepositId { get; set; }

        public virtual Transfer? Transfer { get; set; }
        public int TransferId { get; set; }
    }
}
