using Marco.Exceptions.Core;

namespace Marco.AspNetCore.ExceptionHandling
{
    public abstract class ResourceNotFoundExceptionItem : CoreExceptionItem
    {
        protected ResourceNotFoundExceptionItem(string key, string message) 
            : base(key, message)
        {
        }
    }
}