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