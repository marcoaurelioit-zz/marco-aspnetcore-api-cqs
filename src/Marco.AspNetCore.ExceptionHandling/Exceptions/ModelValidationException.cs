using Marco.Exceptions.Core;
using System;
using System.Collections.Generic;

namespace Marco.AspNetCore.ExceptionHandling.Exceptions
{
    [Serializable]
    public class ModelValidationException : CoreException<ModelValidationExceptionItem>
    {
        public override string Key => "ModelValidation";
        public override string Message => $"One or more errors occurred during model validation. Please check '{nameof(Items)}' for details.";

        public ModelValidationException(IEnumerable<ModelValidationExceptionItem> coreExceptionItems) 
            : base(coreExceptionItems)
        {
        }
    }
}