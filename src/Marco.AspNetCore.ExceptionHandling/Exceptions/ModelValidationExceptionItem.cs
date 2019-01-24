using Marco.Exceptions.Core;

namespace Marco.AspNetCore.ExceptionHandling.Exceptions
{
    public class ModelValidationExceptionItem : CoreExceptionItem
    {
        public ModelValidationExceptionItem(string message) 
            : base("ModelValidationItem", message)
        {
        }
    }
}