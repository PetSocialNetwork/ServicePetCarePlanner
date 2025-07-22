using FluentValidation;
using ServicePlanner.WebApi.Models.Requests;

namespace ServicePlanner.WebApi.Validators
{
    public class UpdateRecordRequestValidator : AbstractValidator<UpdateRecordRequest>
    {
        public UpdateRecordRequestValidator()
        {
            RuleFor(x => x.Text)
              .NotNull()
              .WithMessage("Текст записи не может быть null.")
              .NotEmpty()
              .WithMessage("Текст записи не может быть пустым.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id не заполнен.");
        }
    }
}
