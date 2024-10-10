namespace Dance.Auth.BusinessLogic.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    public static void ThrowIfNull(object? item)
    {
        if (item == null)
        {
            throw new NotFoundException("User not found: " + item);
        }
    }
}