namespace backend.Exceptions
{
    public class ContactDeleteFailedException : Exception
    {
        public ContactDeleteFailedException(string message) : base(message) { }
    }
}