namespace TabooGameApi.Exceptions.Languages
{
    public class LanguageDuplicateKeyException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public LanguageDuplicateKeyException()
        {
            ErrorMessage = "The code already exists";
        }

        public LanguageDuplicateKeyException(string message)
        {
            ErrorMessage = message;
        }
    }
}
