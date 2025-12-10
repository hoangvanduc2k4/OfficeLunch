namespace OfficeLunch.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        // VD: throw new NotFoundException("Product", 10);
        // Output: "Entity \"Product\" (10) was not found."
        public NotFoundException(string name, object key)
                : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        // VD: throw new NotFoundException("Menu for date 2025-12-09 not found");
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
