namespace ProjectManagement.Shared.Common;

public sealed class ResponseModel<T> where T : class
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public T? Response { get; set; } = null!;
    public string ErrorMessage { get; set; } = null!;
}
