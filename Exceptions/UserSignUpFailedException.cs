namespace backend.Exceptions
{
    public class UserSignUpFailedException : Exception
    {
        public UserSignUpFailedException(string message) : base(message) { }
    }
}