namespace CredidSystem.Entity
{
    public class ProductDocuments : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
