using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

using System.ComponentModel.DataAnnotations;

namespace Simple.Attributes
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        readonly IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            return attribute is PeopleAttribute
                ? new PeopleAttributeAdapter(attribute as PeopleAttribute, stringLocalizer)
                : baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
