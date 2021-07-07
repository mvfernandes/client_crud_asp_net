namespace ApiClientNet.Http
{
    public class BaseResponse<T>
    {
        public BaseResponse(T _data, bool _success = true, string _message = "")
        {
            data = _data;
            success = _success;
            message = _message;
        }
        public T data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
    }
}