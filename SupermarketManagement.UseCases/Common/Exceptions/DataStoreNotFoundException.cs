namespace SupermarketManagement.UseCases.Common.Exceptions;
public class DataStoreNotFoundException : Exception
{
    public DataStoreNotFoundException(string dataStoreName)
        : base($"Data store \"{dataStoreName}\" not found.")
    {
    }
}
