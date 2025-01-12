using System.ComponentModel.DataAnnotations.Schema;

namespace CafePOS.Core.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public byte Quantity { get; set; }
        public decimal ExtendedPrice { get; set; }

        [ForeignKey("CafeOrder")]
        public int OrderID { get; set; }
        public int ItemPriceID { get; set; }

        public ItemPrice? ItemPrice { get; set; }
        public CafeOrder? CafeOrder { get; set; }
        
    }
}
