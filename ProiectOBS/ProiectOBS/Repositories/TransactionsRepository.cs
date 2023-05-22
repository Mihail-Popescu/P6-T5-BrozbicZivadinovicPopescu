using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Repositories
{
    public class TransactionsRepository
    {
        private readonly ProiectOBSDbContext _context;

        public TransactionsRepository(ProiectOBSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Deposit> GetDepositsByClientId(int clientId)
        {
            var transactions = _context.Transactions
                .Where(t => t.ClientId == clientId && t.DepositId.HasValue)
                .ToList();

            var depositIds = transactions.Select(t => t.DepositId.Value).ToList();

            var deposits = _context.Deposit
                .Where(d => depositIds.Contains(d.Id))
                .ToList();

            return deposits;
        }

        public IEnumerable<Withdrawal> GetWithdrawalsByClientId(int clientId)
        {
            var transactions = _context.Transactions
                .Where(t => t.ClientId == clientId && t.WithdrawalId.HasValue)
                .ToList();

            var withdrawalIds = transactions.Select(t => t.WithdrawalId.Value).ToList();

            var withdrawals = _context.Withdrawal
                .Where(d => withdrawalIds.Contains(d.Id))
                .ToList();

            return withdrawals;
        }

        public IEnumerable<Transfer> GetTransfersByClientId(int clientId)
        {
            var transactions = _context.Transactions
                .Where(t => t.ClientId == clientId && t.TransferId.HasValue)
                .ToList();

            var transferIds = transactions.Select(t => t.TransferId.Value).ToList();

            var transfers = _context.Transfer
                .Where(d => transferIds.Contains(d.Id))
                .ToList();

            return transfers;
        }

        public IEnumerable<Transactions> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public void AddTransaction(Transactions transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}