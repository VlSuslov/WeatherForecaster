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
    /// View-class model for weather data for the week
    /// </summary>
    class WeekWeather
    {
        public Day[] Days;
        public WeekWeather()
        {
            Days = new Day[7];
            for (int i = 0; i < 7; i++)
                Days[i] = new Day();
        }
        /// <summary>
        /// Method for updating objext state from WeatherData object
        /// </summary>
        /// <param name="time">Domain model oblect with weather data for week</param>
        public void Update(WeatherData weather)
        {
            for (int i = 0; i < 7; i++)
            {
                Days[i].Update(weather.Forecast[i + 1]);
            }
        }  
    }

    /// <summary>
    /// View-model class for day from week forecast
    /// </summary>
    class Day : PropertyChangedBase
    {
        public string Date { get; set; }
        public string MorningTemp { get; set; }
        public string DayTemp { get; set; }
        public string EveningTemp { get; set; }
        public string NightTemp { get; set; }
        public string Weather { get; set; }
        public string Wind { get; set; }
        public BitmapImage Icon { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Clouds { get; set; }

        /// <summary>
        /// Method for updating objext state from Time object
        /// </summary>
        /// <param name="time">Domain model oblect with weather data day</param>
        public void Update(Time time)
        {
            DateTime Time = DateTime.Parse(time.Day);
             Date = Time.DayOfWeek + "\n" + Time.Day + " " + Time.ToString("MMM"); ;
             Weather = time.Symbol.Name;
            string Unit = " °C";
            if (time.Temperature.Unit == "celsius")
                Unit = " °C";
            if (time.Temperature.Unit == "kelvin")
                Unit = " K";
            if (time.Temperature.Unit == "fahrenheit")
                Unit = " °F";
             MorningTemp = time.Temperature.Morning + Unit;
             DayTemp = time.Temperature.Day + Unit;
             EveningTemp = time.Temperature.Evening + Unit;
             NightTemp = time.Temperature.Night + Unit;
             Wind = time.WindSpeed.Mps + " m/s ";
            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
             Icon = new BitmapImage(new Uri("../../Files/" + time.Symbol.Var + ".png", UriKind.Relative));
             Pressure = time.Pressure.Value + " " + time.Pressure.Unit;
             Humidity = time.Humidity.Value + " " + time.Humidity.Unit;
             Clouds = time.Clouds.Value;
        }
    }
    
}
