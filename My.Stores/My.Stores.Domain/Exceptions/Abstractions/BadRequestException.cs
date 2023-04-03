using System.Runtime.Serialization;

namespace My.Store.Domain.Exceptions.Abstractions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException()
    {
    }

    protected BadRequestException(string message) : base(message)
    {
    }

    protected BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}