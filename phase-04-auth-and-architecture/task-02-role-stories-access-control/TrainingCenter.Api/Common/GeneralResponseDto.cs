namespace TrainingCenter.Common
{
    public class GeneralResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ErrorType? ErrorType { get; set; }
        public T? Data { get; set; }
    }
}