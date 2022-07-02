namespace Business.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string massage)
            : base(massage)
        {

        }
    }
}
