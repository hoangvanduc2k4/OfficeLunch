namespace OfficeLunch.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        // Usage: throw new ValidationException("Price cannot be negative.");
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string[] errors)
            : base($"Multiple validation errors occurred: {string.Join(", ", errors)}")
        {
        }
    }
}
