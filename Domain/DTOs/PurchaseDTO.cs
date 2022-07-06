namespace Domain.DTOs
{
    public class PurchaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
