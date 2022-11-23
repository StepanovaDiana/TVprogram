using FluentValidation;
using FluentValidation.Results;

namespace TVprogram.WebAPI.Models;

public class UpdateUser_Channel_listRequest
{
    #region Model
    public bool Favorite_Channel {get;set;}

    #endregion
}

   /* #region Validator
     public class Validator: AbstractValidator<UpdateProgramRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Favorite_Channel)
                .NotEqual("false").WithMessage(" The value must be true");
        }

     }
     #endregion


    
}
public static class UpdateUser_Channel_listRequestExtension
{
     public static ValidationResult Validate(this UpdateUser_Channel_listRequest model)
    {
        return new UpdateUser_Channel_listRequest.Validator().Validate(model);
    }
}*/