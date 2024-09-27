namespace Dance.Store.Application.Exceptions;

public class BadRequestException(string message) : Exception(message)
{
    public static void ThrowIfNotNull(object? item)
    {
        if (item == null)
        {
            throw new BadRequestException("Item already exist" + item);
        }
    }
}