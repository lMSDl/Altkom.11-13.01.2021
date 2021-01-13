using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Validatable : IDataErrorInfo
    {
        private IValidator Validator => new AttributedValidatorFactory().GetValidator(GetType());
        [JsonIgnore]
        public bool IsValid => Validator?.Validate(this).IsValid ?? true;

        [JsonIgnore]
        public string Error => Validator != null ? GetErrors(Validator.Validate(this)) : string.Empty;

        private string GetErrors(ValidationResult validationResult)
        {
            if (validationResult == null || !validationResult.Errors.Any())
                return string.Empty;
            return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
        }

        public string this[string propertyName]
        {
            get
            {
                if (Validator == null)
                    return string.Empty;
                var result = Validator.Validate(new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(new List<string> { propertyName })));
                return GetErrors(result);
            }
        }
    }
}
