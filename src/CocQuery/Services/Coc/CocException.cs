using CocQuery.Models.Coc;

namespace CocQuery.Services.Coc
{
    public class CocException : Exception
    {
        public CocErrorMessage Error { get; } = default!;

        public CocException()
        {
        }

        public CocException(string message)
            : base(message)
        {
        }

        public CocException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CocException(CocErrorMessage error)
        {
            Error = error;
        }

        public override string Message => Error.ToString();
    }
}
