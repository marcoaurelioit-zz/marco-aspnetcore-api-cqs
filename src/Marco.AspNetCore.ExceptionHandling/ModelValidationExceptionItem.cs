using Marco.Exceptions.Core;

namespace Marco.AspNetCore.ExceptionHandling
{
    public class ModelValidationExceptionItem : CoreExceptionItem
    {
        public ModelValidationExceptionItem(string message) 
            : base("ModelValidationItem", message)
        {
        }
    }
}