using Muchik.Market.Pay.Domain.entities;
using Muchik.Market.Pay.Domain.interfaces;
using Muchik.Market.Pay.Infrastructure.context;

namespace Muchik.Market.Pay.Infrastructure.repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context) { }
    }
}
