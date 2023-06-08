namespace App.Helpers.Exceptions
{
    public class NotFoundException: HttpException
    {
        public NotFoundException(string message = "Not Found") : base(message, 404) { }
    }
}
