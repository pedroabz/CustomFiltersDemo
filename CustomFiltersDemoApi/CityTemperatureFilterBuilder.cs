using CustomFiltersDemoApi.Filters;
using System.Linq.Expressions;
using System.Reflection;

namespace CustomFiltersDemoApi
{
    public class CityTemperatureFilterBuilder
    {
        private List<Filter> _filters;
        public CityTemperatureFilterBuilder(List<Filter> filters)
        {
            _filters = filters;
        }
        public Func<CityTemperature, bool> GetFilterExpression()
        { 
            Expression<Func<CityTemperature, bool>> filterExpression = BuildAndFilters();
            return filterExpression.Compile();
        }

        private Expression<Func<CityTemperature, bool>> BuildAndFilters()
        {
            return _filters
                .Select(filter => BuildFilterExpression(filter))
                .Aggregate((expr1, expr2) => And(expr1, expr2));
        }

        private Expression<Func<CityTemperature, bool>> BuildFilterExpression(Filter filter)
        {
            var parameter = Expression.Parameter(typeof(CityTemperature), "x");
            var property = Expression.Property(parameter, filter.FilteredAttribute);
            ConstantExpression convertedConstantValue = GetConvertedConstantValue(filter.Value, property);
            var expression = CreateExpression(filter.Operator, property, convertedConstantValue);

            return Expression.Lambda<Func<CityTemperature, bool>>(expression, parameter);
        }

        private static ConstantExpression GetConvertedConstantValue(string constantValue, MemberExpression property)
        {
            var propertyInfo = (PropertyInfo)property.Member;
            var value = Convert.ChangeType(constantValue, propertyInfo.PropertyType);
            var constant = Expression.Constant(value);
            return constant;
        }

        public Expression CreateExpression(string filterOperator, MemberExpression filterProperty, ConstantExpression filterConstant)
        {
            switch (filterOperator.ToLower())
            {
                case Operators.Equals:
                    return Expression.Equal(filterProperty, filterConstant);
                case Operators.Contains:
                    var method = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                    return Expression.Call(filterProperty, method, filterConstant); 
                case Operators.LessThan:
                    return Expression.LessThan(filterProperty, filterConstant);
                case Operators.GreaterThan:
                    return Expression.GreaterThan(filterProperty, filterConstant);
                default:
                    throw new ArgumentException($"the filter type {filterOperator} is invalid");
            }
        }

        public Expression<Func<CityTemperature, bool>> And (Expression<Func<CityTemperature, bool>> left, Expression<Func<CityTemperature, bool>> right)
        {
            var parameter = Expression.Parameter(typeof(CityTemperature), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(left, parameter),
                    Expression.Invoke(right, parameter)
                );
            var lambda = Expression.Lambda<Func<CityTemperature, bool>>(body, parameter);
            return lambda;
        }
    }
}
