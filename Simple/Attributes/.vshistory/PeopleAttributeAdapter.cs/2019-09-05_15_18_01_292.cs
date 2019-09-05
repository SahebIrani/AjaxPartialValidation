using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

using System;
using System.Globalization;

namespace Simple.Attributes
{
    public class PeopleAttributeAdapter : AttributeAdapterBase<PeopleAttribute>
    {
        public PeopleAttributeAdapter(
            PeopleAttribute attribute,
            IStringLocalizer stringLocalizer) : base(
                attribute,
                stringLocalizer) => _year = attribute.Year;
        private int _year;

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-person", GetErrorMessage(context));

            var year = Attribute.Year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-person-birthYear", year);
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext) => Attribute.GetErrorMessage();
    }
}
