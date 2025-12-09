namespace OfficeLunch.Domain.Exceptions
{
    public class UnauthorizedException : DomainException
    {
        // Usage: throw new UnauthorizedException(Messages.Order.NotHost);
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
