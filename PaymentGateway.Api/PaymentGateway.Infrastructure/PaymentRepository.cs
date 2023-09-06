using PaymentGateway.Domain;

namespace PaymentGateway.Infrastructure;

public class PaymentRepository
{
    private readonly Dictionary<Guid, Payment> _payments = new();
    
    public void Create(Payment payment)
    {
        if (payment is null)
        {
            return;
        }

        _payments[payment.Id] = payment;
    }
    
    public Payment GetById(Guid id)
    {
        return _payments[id];
    }
}