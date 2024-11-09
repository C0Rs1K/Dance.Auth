namespace Dance.Store.Application.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    public static void ThrowIfNull(object? item)
    {
        if (item == null)
        {
            throw new NotFoundException("Item not found: " + item);
        }
    }
}