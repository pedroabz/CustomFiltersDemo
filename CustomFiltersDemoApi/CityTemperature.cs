namespace CustomFiltersDemoApi
{
        public class CityTemperature
        {
        public CityTemperature(string cityName, string regionName, double value, DateTime date)
        {
            CityName = cityName;
            CountryName = regionName;
            MinTemperature = value;
            Date = date;
        }

        public CityTemperature(string cityName, string countryName, double minTemperature, double maxTemperature, DateTime date)
        {
            CityName = cityName;
            CountryName = countryName;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Date = date;
        }
            public string CityName { get; set; }
            public string CountryName { get; set; }
            public double MinTemperature { get; set; }
            public double MaxTemperature { get; set; }
            public DateTime Date { get; set; }
        }
}
