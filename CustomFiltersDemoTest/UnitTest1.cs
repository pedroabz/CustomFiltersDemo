using CustomFiltersDemoApi;
using CustomFiltersDemoApi.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomFiltersDemoTest
{
    [TestClass]
    public class TemperatureApplicationTests
    {
        private readonly TemperatureRepository repo = new TemperatureRepository();

        [TestMethod]
        public void FilterNameEqualsShouldReturnCorrectCities()
        {
            var filters = new List<Filter>
            {
                new Filter("equals", "CityName", "New York"),
            };
            var repo = new TemperatureRepository();
            var filterBuilder = new CityTemperatureFilterBuilder(filters);
            var filterExpression = filterBuilder.GetFilterExpression();
            var filteredList = repo.GetTemperatures(filterExpression);
            Assert.AreEqual(filteredList.First().CityName, "New York");
            Assert.AreEqual(filteredList.Count, 3);
        }

        [TestMethod]
        public void FilterNameContainsShouldReturnCorrectCities()
        {
            var filters = new List<Filter>
            {
                new Filter("contains", "CityName", "New"),
            };
            var filterBuilder = new CityTemperatureFilterBuilder(filters);
            var filterExpression = filterBuilder.GetFilterExpression();
            var filteredList = repo.GetTemperatures(filterExpression);
            Assert.AreEqual(filteredList.Count, 4);
        }

        [TestMethod]
        public void FilterMaxTemperatureHigherShouldReturnCorrectCities()
        {
            var filters = new List<Filter>
            {
                new Filter("greaterthan", "MaxTemperature", "20"),
            };
            var filterBuilder = new CityTemperatureFilterBuilder(filters);
            var filterExpression = filterBuilder.GetFilterExpression();
            var filteredList = repo.GetTemperatures(filterExpression);
            Assert.AreEqual(filteredList.Count, 7);
        }


        [TestMethod]
        public void Test6()
        {
            var filters = new List<Filter>
            {
                new Filter("contains", "CityName", "New"),
                new Filter("contains", "CityName", "Jersey"),
                new Filter("greaterthan", "MaxTemperature", "18"),
            };
            var filterBuilder = new CityTemperatureFilterBuilder(filters);
            var filterExpression = filterBuilder.GetFilterExpression();
            var filteredList = repo.GetTemperatures(filterExpression);
            Assert.AreEqual(filteredList.Count, 1);
        }
    }
}