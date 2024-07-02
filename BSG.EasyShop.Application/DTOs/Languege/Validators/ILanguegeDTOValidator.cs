﻿using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Languege.Validators
{
    public class ILanguegeDTOValidator:AbstractValidator<ILanguegeDTO>
    {
        public ILanguegeDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyNam} Length is more than 50.}");

        }
    }
}
