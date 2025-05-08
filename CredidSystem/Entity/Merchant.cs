namespace CredidSystem.Entity
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Branch> Branches { get; set; } // Navigation property
    }
}
