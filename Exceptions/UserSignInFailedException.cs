namespace backend.Exceptions
{
    public class UserSignInFailedException : Exception
    {
        public UserSignInFailedException(string message) : base(message) { }
    }
}