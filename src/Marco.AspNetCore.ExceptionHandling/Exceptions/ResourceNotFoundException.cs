using Marco.Exceptions.Core;
using System;
using System.Collections.Generic;

namespace Marco.AspNetCore.ExceptionHandling.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : CoreException<ResourceNotFoundExceptionItem>
    {
        public override string Key => "ResourceNotFound";
        public override string Message => $"One or more resources were not found. Please check '{nameof(Items)}' for details.";

        public ResourceNotFoundException(IEnumerable<ResourceNotFoundExceptionItem> coreExceptionItems) 
            : base(coreExceptionItems)
        {
        }
    }
}