using System.Text.RegularExpressions;
using My.Store.Domain.Exceptions;

namespace My.Store.Domain.ValueObjects;

public partial record Email
{
    public string Address { get; }

    private Email(string address)
    {
        Address = address;
    }

    public static Email Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidEmailFormatException();

        var inputLowerCase = input.Trim().ToLowerInvariant();

        if (!EmailFormat().IsMatch(inputLowerCase))
            throw new InvalidEmailFormatException();

        return new Email(inputLowerCase);
    }

    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailFormat();
}