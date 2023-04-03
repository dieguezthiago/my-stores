using My.Store.Domain.Exceptions.Abstractions;

namespace My.Store.Domain.Exceptions;

public class FirstNameRequiredException : BadRequestException
{
    private const string ErrorMessage = "First name is required.";
    
    public FirstNameRequiredException() : base(ErrorMessage)
    {
    }
}