﻿using Microsoft.AspNetCore.Authentication;
using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Repositories
{
    public class DepositRepository
    {
        private readonly ProiectOBSDbContext _context;

        public DepositRepository(ProiectOBSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Deposit> GetDepositsByClientId(int clientId)
        {
            return _context.Deposit.Where(d => d.Id == clientId).ToList();
        }

        public void Add(Deposit deposit)
        {
            deposit.Date = DateTime.Now;
            _context.Deposit.Add(deposit);
            _context.SaveChanges();
        }

        public List<Deposit> GetAll()
        {
            return _context.Deposit.ToList();
        }
    }
}