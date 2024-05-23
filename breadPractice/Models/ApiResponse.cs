namespace breadPractice.Models
{
    public enum ResponseCode
    {
        OK = 200,
        BadRequest = 400,
        MethodNotAllowed = 405
    }
    public class ApiResponse
    {
        public object? Data { get; set; }
        public ResponseCode ResponseCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(object? data, ResponseCode responseCode, string message)
        {
            Data = data;
            ResponseCode = responseCode;
            Message = message;
        }
    }
}
