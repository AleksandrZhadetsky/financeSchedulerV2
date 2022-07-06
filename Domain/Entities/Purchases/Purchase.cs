using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Purchases
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public int Count { get; set; }

        public string CreatedById { get; set; }

        public string CategoryId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
