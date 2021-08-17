namespace VRS_Eng_Manage_Tool.Data
{
    public class ResultItem
    {
        public ResultItem() { }

        public ResultItem(bool result) { Result = result; }

        public ResultItem(bool result, string message)
        {
            Result = result;
            Message = message;
        }

        public bool Result { get; set; }
        public string Message { get; set; }
    }
}