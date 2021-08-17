namespace VRS_Eng_Manage_Tool.Data
{
    public class MessageItem
    {
        public string Message { get; set; }
        public bool ErrorMessage { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MessageItem(string message, bool errorMessage, int left, int top, int width, int height)
        {
            Message = message;
            ErrorMessage = errorMessage;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
}