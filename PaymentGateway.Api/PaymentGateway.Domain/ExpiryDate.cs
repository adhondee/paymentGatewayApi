namespace PaymentGateway.Api;

public sealed class ExpiryDate
{
    public ExpiryDate(int month, int year)
    {
        if (month is < 1 or > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), month, "invalid month");
        }

        if (year < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(year), year, "invalid year");
        }

        Month = month;
        Year = year;
    }

    public int Month { get; }
    public int Year { get; }
}