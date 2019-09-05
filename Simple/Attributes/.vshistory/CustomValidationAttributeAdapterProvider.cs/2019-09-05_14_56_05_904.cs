using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

using System.ComponentModel.DataAnnotations;

namespace ValidationSample.Attributes
{
    #region snippet_CustomValidationAttributeAdapterProvider
    public class CustomValidationAttributeAdapterProvider :
        IValidationAttributeAdapterProvider
    {
        IValidationAttributeAdapterProvider baseProvider =
            new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute,
            IStringLocalizer stringLocalizer)
        {
            if (attribute is ClassicMovieAttribute)
            {
                return new ClassicMovieAttributeAdapter(
                    attribute as ClassicMovieAttribute, stringLocalizer);
            }
            else
            {
                return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
            }
        }
    }
    #endregion
}
