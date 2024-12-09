namespace MyPro.Domain.ValueObjects;

/// <summary>
/// 表示货币的值对象
/// </summary>
public class Money
{
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; private set; }
    
    public string Currency { get; private set; }
    
    private Money() { }
}