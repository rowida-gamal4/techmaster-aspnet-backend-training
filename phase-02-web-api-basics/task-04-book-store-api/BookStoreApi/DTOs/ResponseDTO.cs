namespace BookStoreApi.DTOs
{
   public class ResponseDTO<T>
{
    public bool Success { get; set; }

    public int StatusCode { get; set; }

    public List<string> Errors { get; set; } = new();

    public T? Data { get; set; }
}
}