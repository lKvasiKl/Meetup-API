namespace Business.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string massage)
            : base(massage)
        {

        }
    }
}
