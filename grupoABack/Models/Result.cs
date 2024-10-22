namespace grupoABack.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public Result(bool success, string? message = null, object? data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public Result(bool success) : this(success, null, null)
        {
        }
    }
}
