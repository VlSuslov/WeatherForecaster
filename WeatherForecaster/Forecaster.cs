using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecaster
{
    /// <summary>
    /// Interface for weather forecaster module
    /// </summary>
    interface IForecaster
    {
        /// <summary>
        /// Method which get weather forecast
        /// </summary>
        /// <param name="type">Type of weather forecast</param>
        /// <param name="place">Place for which is forecast</param>
        /// <param name="place">Number of forecast parts</param>
        Task<string> GetForecast(string type, string place, int count);
    }
    /// <summary>
    /// Realization of IForecaster for openweather api
    /// </summary>

    class Forecaster :IForecaster
    {
        private const string ServiceUrl = "http://api.openweathermap.org/data/2.5/{0}?q={1}&mode=xml&cnt={2}&units=metric&APPID=c28bb3a2fa9b9c8f6c4c73e707191bf2";

        /// <summary>
        /// Method which get weather forecast as xml 
        /// </summary>
        /// <param name="type">Type of weather forecast 
        /// weather-for current weather
        /// forecast-for every 3 hours forecast
        /// forecast/daily - for daily forecast</param>
        /// <param name="place">Place for which is forecast</param>
        /// <param name="place">Number of forecast parts</param>
        /// <returns> weather data in xml format
        public async Task<string> GetForecast(string type, string place, int count)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = null;
                try
                {
                    result = await client.GetStringAsync(String.Format(ServiceUrl, type, place, count));
                }
                catch (HttpRequestException)
                {
                    throw;
                }
                return result;
            }
        }
    }
}
