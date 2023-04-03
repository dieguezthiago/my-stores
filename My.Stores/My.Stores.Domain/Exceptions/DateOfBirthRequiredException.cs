using My.Store.Domain.Exceptions.Abstractions;

namespace My.Store.Domain.Exceptions;

public class DateOfBirthRequiredException : BadRequestException
{
    private const string ErrorMessage = "Date of birth is required.";
    
    public DateOfBirthRequiredException() : base(ErrorMessage)
    {
    }
}