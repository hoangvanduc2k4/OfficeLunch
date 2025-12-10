using FluentValidation;
using OfficeLunch.Application.DTOs.Shop.Request;

namespace OfficeLunch.Application.Validations
{
    public class SubmitOrderValidator : AbstractValidator<SubmitOrderRequest>
    {
        public SubmitOrderValidator()
        {
            // 1. Validate UserId (must be a positive number)
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("UserId is not valid.");

            // 2. Validate the list of order items
            RuleFor(x => x.Items)
                .NotNull().WithMessage("The item list cannot be null.")
                .Must(items => items != null && items.Count > 0)
                .WithMessage("You must select at least one item.");

            // 3. Validate each item inside the list (nested validation)
            RuleForEach(x => x.Items)
                .SetValidator(new OrderItemValidator());
        }
    }
}
