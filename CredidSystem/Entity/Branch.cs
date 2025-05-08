namespace CredidSystem.Entity
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; } // Navigation property
    }
}
