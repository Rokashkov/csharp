namespace App.Helpers.Exceptions
{
    public class BadRequestException: HttpException
    {
        public BadRequestException(string? message = "Bad Request") : base(message!, 400) { }
    }
}
