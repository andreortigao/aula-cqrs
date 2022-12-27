namespace ExemploCqrs.Aplicacao.Excecoes
{
    /// <summary>
    /// Custom exception used for Not Found situations
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, int id)
            : base($"No {entityName} found for given ID: {id}")
        {

        }

        public NotFoundException(string entityName, string details)
            : base($"No {entityName} found for given details: {details}")
        {

        }
    }
}
