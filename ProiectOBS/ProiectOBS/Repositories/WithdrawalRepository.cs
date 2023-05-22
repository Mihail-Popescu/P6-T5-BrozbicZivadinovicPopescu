using Microsoft.AspNetCore.Authentication;
using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Repositories
{
    public class WithdrawalRepository
    {
        private readonly ProiectOBSDbContext _context;

        public WithdrawalRepository(ProiectOBSDbContext context)
        {
            _context = context;
        }

        public void Add(Withdrawal withdrawal)
        {
            withdrawal.Date = DateTime.Now;
            _context.Withdrawal.Add(withdrawal);
            _context.SaveChanges();
        }

        public List<Withdrawal> GetAll()
        {
            return _context.Withdrawal.ToList();
        }
    }
}