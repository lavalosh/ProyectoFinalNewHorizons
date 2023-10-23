namespace Muchik.Market.Invoice.Domain.Entities;

public class Invoices
{
    public int Id { get; set; } 
    public decimal Amount { get; set; }
    public int State { get; set; }
}
