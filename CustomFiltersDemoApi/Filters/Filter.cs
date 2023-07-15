namespace CustomFiltersDemoApi.Filters
{
    public class Filter
    {
        public Filter(string @operator, string filteredAttribute, string value)
        {
            Operator = @operator;
            FilteredAttribute = filteredAttribute;
            Value = value;
        }

        // TODO: change it to enum
        public string Operator { get; private set; }
        public string FilteredAttribute { get; private set; }
        public string Value { get; private set; }
    }
}
