namespace Application.Errors.Exceptions;

public class BadArgumentException : Exception
{
    public BadArgumentException(string message, int code = 400) : base(message){}
}

