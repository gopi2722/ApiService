namespace MsoneData
{
    public class ResponseMessage
    {
        public ResponseMessage() { }
        public ResponseMessage(bool _success, int _code, string _message, string _errordescription, dynamic _data)
        {
            success = _success;
            code = _code;
            message = _message;
            errordescription = _errordescription;
            data = _data;
        }
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public string errordescription { get; set; }
        public dynamic data { get; set; }
    }
}
