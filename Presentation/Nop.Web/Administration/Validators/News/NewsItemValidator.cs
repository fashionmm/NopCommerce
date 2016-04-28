﻿using FluentValidation;
using Nop.Admin.Models.News;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Admin.Validators.News
{
    public class NewsItemValidator : BaseNopValidator<NewsItemModel>
    {
        public NewsItemValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Title.Required"));

            RuleFor(x => x.Short).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Short.Required"));

            RuleFor(x => x.Full).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Full.Required"));
        }
    }
}