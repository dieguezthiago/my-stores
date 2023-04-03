using My.Store.Domain.Exceptions.Abstractions;

namespace My.Store.Domain.Exceptions;

public class LastNameRequiredException : BadRequestException
{
    private const string ErrorMessage = "Last name is required.";
    
    public LastNameRequiredException() : base(ErrorMessage)
    {
    }
}