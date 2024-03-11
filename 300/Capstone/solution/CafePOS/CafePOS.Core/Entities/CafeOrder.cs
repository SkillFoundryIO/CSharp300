namespace CafePOS.Core.Entities
{
    public class CafeOrder
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Tip { get; set; }
        public decimal? AmountDue { get; set; }

        public int? PaymentTypeID { get; set; }
        public int ServerID { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
        public Server Server { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}
