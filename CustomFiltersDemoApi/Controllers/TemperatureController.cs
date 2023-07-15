using CustomFiltersDemoApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomFiltersDemoApi.Controllers
{
    // Implement Regex
    // Todo implement Or
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        // TODOS: Make custom method for filtering
        // TODOS: Make Enums for the FilterDto
        [HttpGet(Name = "")]
        public IEnumerable<CityTemperature> Get()
        {
            var temperatureRepository = new TemperatureRepository();
            return temperatureRepository.GetTemperatures();
        }

        [HttpPost(Name = "filtered/search")]
        public IEnumerable<CityTemperature> SearchFiltered([FromBody] List<Filter> filters)
        {
            var temperatureRepository = new TemperatureRepository();
            var filterBuilder = new CityTemperatureFilterBuilder(filters);
            var filter = filterBuilder.GetFilterExpression();
            return temperatureRepository.GetTemperatures(filter);
        }
    }
}
