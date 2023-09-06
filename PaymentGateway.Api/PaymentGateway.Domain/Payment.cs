using PaymentGateway.Api;

namespace PaymentGateway.Domain;

public record Payment(Guid Id, string CardNumber, ExpiryDate ExpiryDate, float Amount, String Currency, int CVV);