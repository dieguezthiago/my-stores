using System.Runtime.Serialization;

namespace My.Store.Domain.Exceptions.Abstractions;

public abstract class ConflictException : Exception
{
    protected ConflictException()
    {
    }

    protected ConflictException(string message) : base(message)
    {
    }

    protected ConflictException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}