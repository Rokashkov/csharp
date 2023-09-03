namespace App.Helpers.Exceptions
{
    public class HttpException: Exception
    {
        public ushort StatusCode { get; set; }
        public HttpException(string message, ushort statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
