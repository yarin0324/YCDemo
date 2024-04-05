namespace Api.Models
{
    public class ResponseResult
    {
        public ErrorCode ErrorCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
        Failed = 1 
    }
}
