﻿using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateFeedSetting
{
    public class UpdateFeedSettingsCommandValidator : AbstractValidator<UpdateFeedSettingCommand>
    {
        public UpdateFeedSettingsCommandValidator()
        {
            RuleFor(v => v.RssCopyright)
                .NotEmpty().WithMessage("RssCopyright is required.")
                .MaximumLength(64).WithMessage("RssCopyright must not exceed 64 characters.");
            RuleFor(v => v.RssDescription)
                .NotEmpty().WithMessage("RssDescription is required.")
                .MaximumLength(512).WithMessage("RssDescription must not exceed 512 characters.");
            RuleFor(v => v.RssTitle)
                .NotEmpty().WithMessage("RssTitle is required.")
                .MaximumLength(64).WithMessage("RssTitle must not exceed 64 characters.");
            RuleFor(v => v.AuthorName)
                .NotEmpty().WithMessage("AuthorName is required.")
                .MaximumLength(32).WithMessage("AuthorName must not exceed 32 characters.");
        }
    }
}