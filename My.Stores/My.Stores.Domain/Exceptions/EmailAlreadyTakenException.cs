using My.Store.Domain.Exceptions.Abstractions;

namespace My.Store.Domain.Exceptions;

public class EmailAlreadyTakenException : ConflictException
{
    private const string ErrorMessage = "Email address has already been registered.";

    public EmailAlreadyTakenException() : base(ErrorMessage)
    {
    }
}