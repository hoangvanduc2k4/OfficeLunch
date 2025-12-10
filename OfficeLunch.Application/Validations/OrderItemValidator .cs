using FluentValidation;
using OfficeLunch.Application.DTOs.Shop.Request;

namespace OfficeLunch.Application.Validations
{
    public class OrderItemValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemValidator()
        {
            // ProductId must be a valid positive number
            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId is not valid.");

            // Quantity must be greater than 0 and not exceed the allowed limit
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                .LessThan(50).WithMessage("Quantity is too large, please contact the kitchen."); // Small business rule

            // Optional note field with a maximum length
            RuleFor(x => x.Note)
                .MaximumLength(200)
                .WithMessage("Note can have up to 200 characters.");
        }
    }

}
