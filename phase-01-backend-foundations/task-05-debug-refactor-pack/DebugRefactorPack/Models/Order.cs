
namespace DebugRefactorPack.Models
{
    public class Order
    {

        public string ProductName { get; set; } = default!;
        public decimal Price {get;set;}
        public int Quantity { get; set; }
        public Customer Customer { get; set; } = default!;

    }
}