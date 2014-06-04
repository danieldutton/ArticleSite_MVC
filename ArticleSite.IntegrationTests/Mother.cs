﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.IntegrationTests
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
    }
}