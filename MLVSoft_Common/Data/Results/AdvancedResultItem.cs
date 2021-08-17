namespace MLVSoft_Common.Data.Results
{
    public class AdvancedResultItem<ElementTypeT>
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
        public ElementTypeT Element { get; set; }

        public AdvancedResultItem() { }

        public AdvancedResultItem(bool result, ElementTypeT element)
        {
            Result = result;
            Element = element;
        }

        public AdvancedResultItem(ElementTypeT element)
        {
            Result = true;
            Element = element;
        }

        public AdvancedResultItem(string errorMessage)
        {
            Result = false;
            ErrorMessage = errorMessage;
        }
    }
}