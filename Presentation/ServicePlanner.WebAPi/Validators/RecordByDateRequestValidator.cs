using FluentValidation;
using ServicePlanner.WebApi.Models.Requests;

namespace ServicePlanner.WebApi.Validators
{
    public class RecordByDateRequestValidator : AbstractValidator<RecordByDateRequest>
    {
        public RecordByDateRequestValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("ProfileId не заполнен.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date не заполнен.");

        }
    }
}
