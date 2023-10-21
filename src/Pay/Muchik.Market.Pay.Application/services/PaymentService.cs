using AutoMapper;
using Muchik.Market.Pay.Application.dto;
using Muchik.Market.Pay.Application.interfaces;
using Muchik.Market.Pay.Domain.entities;
using Muchik.Market.Pay.Domain.interfaces;

namespace Muchik.Market.Pay.Application.services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository) 
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public bool CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            _paymentRepository.Add(payment);
            return _paymentRepository.Save();
        }
    }
}
