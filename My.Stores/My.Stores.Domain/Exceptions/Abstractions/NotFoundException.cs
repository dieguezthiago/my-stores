using System.Runtime.Serialization;

namespace My.Store.Domain.Exceptions.Abstractions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException()
    {
    }

    protected NotFoundException(string message) : base(message)
    {
    }

    protected NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}