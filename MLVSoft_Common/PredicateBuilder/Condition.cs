namespace MLVSoft_Common.Business.Excel.PredicateBuilder
{
    public class Condition
    {
        public Operator Operator { get; set; }
        public Operation Operation { get; set; }
        public string FieldName { get; set; }
        public object Value { get; set; }

        public Condition() { }

        public Condition(Operator operatorElement, Operation operation, string fieldName, object value)
        {
            Operator = operatorElement;
            Operation = operation;
            FieldName = fieldName;
            Value = value;
        }

        public Condition(Operation operation, string fieldName, object value)
        {
            Operation = operation;
            FieldName = fieldName;
            Value = value;
        }
    }
}