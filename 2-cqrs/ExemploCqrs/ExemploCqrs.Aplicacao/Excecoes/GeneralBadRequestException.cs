namespace ExemploCqrs.Aplicacao.Excecoes
{
    /// <summary>
    /// Custom exception for general Bad Requests.
    /// </summary>
    public class GeneralBadRequestException : Exception
    {
        public GeneralBadRequestException(string messsage)
            : base(messsage)
        {

        }
    }
}
