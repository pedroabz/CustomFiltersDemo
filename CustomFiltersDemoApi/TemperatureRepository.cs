namespace CustomFiltersDemoApi
{
    public class TemperatureRepository
    {
        private List<CityTemperature> _cityTemperatureList = new List<CityTemperature>
            {
                new CityTemperature("Los Angeles", "United States", 18, 25.5, new DateTime(2022,04,06)),
                new CityTemperature("Los Angeles", "United States", 15.3, 23.2, new DateTime(2022,04,05)),
                new CityTemperature("Los Angeles", "United States", 13.8, 19.3, new DateTime(2022,04,04)),
                new CityTemperature("New York", "United States", 7.7, 15.5, new DateTime(2022, 04, 06)),
                new CityTemperature("New York", "United States", -3.1, 7.2, new DateTime(2022, 04, 05)),
                new CityTemperature("New York", "United States", 5.3, 18.3, new DateTime(2022, 04, 04)),
                new CityTemperature("New Jersey", "United States", 6.3, 19.3, new DateTime(2022, 04, 04)),
                new CityTemperature("Lisbon", "Portugal", 12, 22.5, new DateTime(2022,04,06)),
                new CityTemperature("Lisbon", "Portugal", 11.3, 21.2, new DateTime(2022,04,05)),
                new CityTemperature("Lisbon", "Portugal", 10.8, 19.3, new DateTime(2022,04,04)),
                new CityTemperature("Porto", "Portugal", 9.7, 14.5, new DateTime(2022, 04, 06)),
                new CityTemperature("Porto", "Portugal", 12.1, 13.2, new DateTime(2022, 04, 05)),
                new CityTemperature("Porto", "Portugal", 13.3, 15.3, new DateTime(2022, 04, 04)),
                new CityTemperature("Rio de Janeiro", "Brazil", 24.7, 30.5, new DateTime(2022, 04, 06)),
                new CityTemperature("Rio de Janeiro", "Brazil", 30.1, 33.2, new DateTime(2022, 04, 05)),
                new CityTemperature("Rio de Janeiro", "Brazil", 32.3, 38.3, new DateTime(2022, 04, 04)),
            };
        public List<CityTemperature> GetTemperatures()
        {
            return _cityTemperatureList;
        }

        public List<CityTemperature> GetTemperatures(Func<CityTemperature, bool> filterExpression)
        { 
            return _cityTemperatureList.Where(filterExpression).ToList();
        }
    }
}
