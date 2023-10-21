namespace Muchik.Market.Transaction.Domain.entities
{
    public partial class TransactionEntity
    {
    
        public int TransactionId { get; set; }
        public int InvoiceId { get; set; }
        public decimal amount { get; set; }
    }
}