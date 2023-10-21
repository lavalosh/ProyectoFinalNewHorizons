namespace Muchik.Market.Pay.Domain.entities
{
    public partial class Payment
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString("N");
        //public string CustomerId { get; set; } = null!;
        //public string OrderId { get; set; } = null!;
        //public decimal Total { get; set; }
        //public int State { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int OperationId { get; set; }
        public int InvoiceId { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
    }
}