namespace ProiectOBS.Models
{
    public class Address
    {
        public int? Id { get; set; }
        public string? Street { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public int? Postalcode { get; set; }
        public int? Block { get; set; }
        public int? Floor { get; set; }
        public int? Apartment { get; set; }
        public int? Staircase { get; set; }
        public string? City { get; set; }
    }
}
