using FluentValidation;
using ServicePlanner.WebApi.Models.Requests;

namespace ServicePlanner.WebApi.Validators
{
    public class RecordByPeriodRequestValidator : AbstractValidator<RecordByPeriodRequest>
    {
        public RecordByPeriodRequestValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("ProfileId не заполнен.");

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Date не заполнен.");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("Date не заполнен.");
        }
    }
}
