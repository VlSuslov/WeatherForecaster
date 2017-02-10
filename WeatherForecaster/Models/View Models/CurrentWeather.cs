using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using WeatherForecaster.Models.Domen_Models;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace WeatherForecaster.Models.View_Models
{
    /// <summary>
    /// View-model class for current weather
    /// </summary>
    class CurrentWeather : PropertyChangedBase
    {
        public string Temperature { get; set; } 
        public string Weather { get; set; }
        public string Wind { get; set; }
        public BitmapImage Icon { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Cloudiness { get; set; }
        public string Rain { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        /// <summary>
        /// Method for updating objext state from Current object
        /// </summary>
        /// <param name="time">Domain model oblect with current weather data</param>
        public void Update(Current current)
        {
            if (current.Temperature.Unit == "metric")
            {
                Temperature = current.Temperature.Value + " °C";
            }
            if (current.Temperature.Unit == "kelvin")
            {
                Temperature = current.Temperature.Value + " K";
            }
            if (current.Temperature.Unit == "fahrenheit")
            {
                Temperature = current.Temperature.Value + " °F";
            }
            Weather = current.Weather.Value;
            Wind = current.Wind.Speed.Name + " " + current.Wind.Speed.Value + " m/s " + current.Wind.Direction.Name + " ("
                + current.Wind.Direction.Value + ")";
            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
            Icon = new BitmapImage(new Uri("../../Files/" + current.Weather.Icon+".png", UriKind.Relative));
            Pressure = current.Pressure.Value + " " + current.Pressure.Unit;
            Humidity = current.Humidity.Value + " " + current.Humidity.Unit;
            Cloudiness = current.Clouds.Name;
            Rain = current.Precipitation.Value;
            DateTime Time = DateTime.Parse(current.City.Sun.Rise);
            Sunrise =  Time.Hour+":"+Time.Minute;
            Time = DateTime.Parse(current.City.Sun.Set);
            Sunset = Time.Hour + ":" + Time.Minute;
        }     
    }
}
