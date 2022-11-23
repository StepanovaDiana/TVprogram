using FluentValidation;
using FluentValidation.Results;

namespace TVprogram.WebAPI.Models;

public class UpdateChannelRequest
{
    #region Model
     public string Name {get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateChannelRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }

     }
     #endregion
}
public static class UpdateChannelRequestExtension
{
    public static ValidationResult Validate(this UpdateChannelRequest model)
    {
        return new UpdateChannelRequest.Validator().Validate(model);
    }
}