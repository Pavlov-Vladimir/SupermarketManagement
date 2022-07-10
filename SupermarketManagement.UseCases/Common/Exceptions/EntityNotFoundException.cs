namespace SupermarketManagement.UseCases.Common.Exceptions;
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName)
        : base($"Entity \"{entityName}\" not found.")
    {
    }
}
