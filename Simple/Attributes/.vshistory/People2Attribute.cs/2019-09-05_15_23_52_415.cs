using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using Simple.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Simple.Attributes
{
    public class People2Attribute : ValidationAttribute, IClientModelValidator
    {
        public People2Attribute(int year) => _year = year;
        private int _year;

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            _ = (Person)validationContext.ObjectInstance;
            //به خود شخص دسترسی داریم میتونیم رو هر پروپرتی که بخوایم شرط و شروط قرار بدیم ..

            var birthYear = ((DateTime)value).Year;

            return birthYear > _year ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-person", GetErrorMessage());

            var year = _year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-person-birthYear", year);
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key)) return false;

            attributes.Add(key, value);

            return true;
        }
        protected string GetErrorMessage()
        {
            return $"Classic movies must have a release year no later than {_year} [from attribute 2].";
        }
    }
}
