using My.Store.Domain.Exceptions.Abstractions;

namespace My.Store.Domain.Exceptions;

public class InvalidEmailFormatException : BadRequestException
{
    private const string ErrorMessage = "The email address provided is not in a valid format.";

    public InvalidEmailFormatException() : base(ErrorMessage)
    {
    }
}