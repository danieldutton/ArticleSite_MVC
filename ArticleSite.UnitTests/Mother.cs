using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ArticleSite.UnitTests
{
    public static class Mother
    {
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            
            Validator.TryValidateObject(model, ctx, validationResults, true);
            
            return validationResults;
        }

        public static void ValidateViewModel<VM, C>(VM viewModelToValidate, C controller) where C : Controller
        {
            var validationContext = new ValidationContext(viewModelToValidate, null, null);
            var validationResults = new List<ValidationResult>();
            
            Validator.TryValidateObject(viewModelToValidate, validationContext, validationResults, true);
            
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
        }
    }
}
