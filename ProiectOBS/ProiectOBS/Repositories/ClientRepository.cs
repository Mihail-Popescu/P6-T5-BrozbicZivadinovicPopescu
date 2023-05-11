using Microsoft.AspNetCore.Authentication;
using ProiectOBS.Data;
using ProiectOBS.Models;

namespace ProiectOBS.Repositories
{
    public class ClientRepository
    {
        private readonly ProiectOBSDbContext _context;

        public ClientRepository(ProiectOBSDbContext context)
        {
            _context = context;
        }

        public Client GetClientById(int id)
        {
            return _context.Client.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateClient(Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }
    }
}