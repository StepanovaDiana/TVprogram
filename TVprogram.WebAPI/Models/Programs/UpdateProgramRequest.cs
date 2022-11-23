using FluentValidation;
using FluentValidation.Results;

namespace TVprogram.WebAPI.Models;

public class UpdateProgramRequest
{
    #region Model
     public string Name {get;set;}
     public int Duration{get;set;}
     public DateTime Time{get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateProgramRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.Time)
                .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
            RuleFor(x=>x.Duration)
               .NotNull().WithMessage("Length > 0");
        }

     }
     #endregion
}
public static class UpdateProgramRequestExtension
{
    public static ValidationResult Validate(this UpdateProgramRequest model)
    {
        return new UpdateProgramRequest.Validator().Validate(model);
    }
}