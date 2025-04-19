// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

namespace Crossref.Net.Exceptions;

public class CrossrefException : Exception
{
    public CrossrefException(string exceptionMessage)
        : base(exceptionMessage)
    {
    }

    public CrossrefException(string exceptionMessage, Exception innerException)
        : base(exceptionMessage, innerException)
    {
    }
}
