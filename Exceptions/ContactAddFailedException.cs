namespace backend.Exceptions
{
    public class ContactAddFailedException : Exception
    {
        public ContactAddFailedException(string message) : base(message) { }
    }
}