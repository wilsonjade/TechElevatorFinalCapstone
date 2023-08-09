namespace Capstone.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerType { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Website { get; set; }

        public Seller()
        {
        }

    }
}
