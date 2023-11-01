using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Description{ get; set; }
        public string Name  { get; set; }
        public bool IsInvoiced { get; set; }
        public bool IsDeleted { get; set; }
    }
}
