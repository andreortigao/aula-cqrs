namespace ExemploCqrs.Middlewares
{
    public class DefaultErrorResponse
    {
        public int Status { get; internal set; }
        public string Detail { get; internal set; }
        public IReadOnlyDictionary<string, string>? Errors { get; internal set; }
    }
}
