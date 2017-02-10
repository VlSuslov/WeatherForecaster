using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WeatherForecaster.Models.Domen_Models;

namespace WeatherForecaster.Models.View_Models
{
    /// <summary>
    /// View-model class for day weather data
    /// </summary>
    class DayWeather 
    {
        public Part[] Parts { get; set; }
        public DayWeather()
        {
            Parts = new Part[8];
            for(int i= 0;i< 8;i++)
             Parts[i] = new Part(); 
        }

        /// <summary>
        /// Method for updating objext state from WeatherData object
        /// </summary>
        /// <param name="time">Domain model oblect with weather data for day</param>
        public void Update(WeatherData weather)
        {
            for (int i = 0; i < 8; i++)
            {
                 Parts[i].Update(weather.Forecast[i+1]);               
            }
        }     
    }

    /// <summary>
    /// View-model class for part of the day
    /// </summary>
    class Part :PropertyChangedBase
    {
        public string Time { get; set; }
        public string Temperature { get; set; }
        public string Weather { get; set; }
        public string Wind { get; set; }
        public BitmapImage Icon { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Clouds { get; set; }

        /// <summary>
        /// Method for updating objext state from Time object
        /// </summary>
        /// <param name="time">Domain model oblect with weather data for part of day</param>
        public void Update(Time time)
        {
            DateTime Date = DateTime.Parse(time.From);
            Time = Date.Day + " " + Date.ToString("MMM") + "\n" + Date.ToString("HH:mm");
            Weather = time.Symbol.Name;
            if (time.Temperature.Unit == "celsius")
                Temperature = time.Temperature.Value + " °C";
            if (time.Temperature.Unit == "kelvin")
                Temperature = time.Temperature.Value + " K";         
            if (time.Temperature.Unit == "fahrenheit")
                Temperature = time.Temperature.Value + " °F";
            Wind = time.WindSpeed.Mps + " m/s ";
            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
            Icon = new BitmapImage(new Uri("../../Files/" + time.Symbol.Var + ".png", UriKind.Relative));
            Pressure = time.Pressure.Value + " " + time.Pressure.Unit;
            Humidity = time.Humidity.Value + " " + time.Humidity.Unit;
            Clouds = time.Clouds.Value;
        }
    }
}
