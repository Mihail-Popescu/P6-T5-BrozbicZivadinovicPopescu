using Microsoft.AspNetCore.Authentication;
using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Repositories
{
    public class TransferRepository
    {
        private readonly ProiectOBSDbContext _context;

        public TransferRepository(ProiectOBSDbContext context)
        {
            _context = context;
        }
        public void Add(Transfer transfer)
        {
            transfer.Date = DateTime.Now;
            _context.Transfer.Add(transfer);
            _context.SaveChanges();
        }

        public List<Transfer> GetAll()
        {
            return _context.Transfer.ToList();
        }
    }
}