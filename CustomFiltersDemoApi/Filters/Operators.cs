namespace CustomFiltersDemoApi.Filters
{
    public static class Operators
    {
        // Has to work with all types
        public new const string Equals = "equals";
        // String only
        public const string Contains = "contains";
        // Both date and double
        public const string LessThan = "lessthan";
        // Both date and double
        public const string GreaterThan = "greaterthan";
    }
}
