using System.Net;

namespace ProiectOBS.Models
{
    public class Client
    {

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public int? PhoneNumber { get; set; }
        public int? IBAN { get; set; }
        public int? Balance { get; set; }
        public virtual Card? Card { get; set; }
        public int CardId { get; set; }

        public virtual Address? Address { get; set; }
        public int AddressId { get; set; }

    }
}
