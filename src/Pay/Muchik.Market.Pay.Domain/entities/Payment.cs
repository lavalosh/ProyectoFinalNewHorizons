namespace Muchik.Market.Pay.Domain.entities
{
    public partial class Payment
    {
        public int OperationId { get; set; }
        public int InvoiceId { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
    }
}