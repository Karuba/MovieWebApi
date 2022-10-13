namespace MovieWebApi.Domain.Interfaces.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) 
            : base(message)
        {
        }
    }
}
