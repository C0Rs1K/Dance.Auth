namespace Dance.Auth.BusinessLogic.Exceptions;

public class AlreadyExistException(string message) : Exception(message)
{
    public static void ThrowIfNotNull(object? item)
    {
        if (item != null)
        {
            throw new AlreadyExistException("User already exist" + item);
        }
    }
}