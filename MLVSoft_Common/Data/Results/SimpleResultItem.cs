namespace MLVSoft_Common.Data.Results
{
    public class SimpleResultItem
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public bool MessageFromEx { get; set; }

        public SimpleResultItem() { }

        public SimpleResultItem(bool result)
        {
            Result = result;
        }

        public SimpleResultItem(bool result, string errorMessage, bool exception)
        {
            Result = result;
            Message = errorMessage;
            MessageFromEx = exception;
        }
    }
}