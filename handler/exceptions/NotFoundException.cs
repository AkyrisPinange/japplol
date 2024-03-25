namespace JAppInfos.handler.exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public int ErrorCode {  get; set; }
        public NotFoundException() { }

        public NotFoundException(string message, int errorCode) 
            : base(message) 
        {
            ErrorCode = errorCode;
        }
    }
}
