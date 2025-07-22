using FluentValidation;
using ServicePlanner.WebApi.Models.Requests;

namespace ServicePlanner.WebApi.Validators
{
    public class RecordRequestValidator : AbstractValidator<RecordRequest>
    {
        public RecordRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .WithMessage("Текст записи не может быть null.")
                .NotEmpty()
                .WithMessage("Текст записи не может быть пустым.");

            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("ProfileId не заполнен.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date не заполнен.");
        }
    }
}
