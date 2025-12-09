namespace OfficeLunch.Domain.Exceptions
{
    public class BusinessRuleException : DomainException
    {
        // Usage: throw new BusinessRuleException(Messages.Order.OutOfStock);
        public BusinessRuleException(string message) : base(message)
        {
        }
    }
}
