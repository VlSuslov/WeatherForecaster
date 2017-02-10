using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    [XmlRoot("weatherdata")]
   public class WeatherData
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "credit")]
        public string Credit { get; set; }
        [XmlElement(ElementName = "meta")]
        public Meta Meta { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }
        [XmlArray(ElementName = "forecast")]
        [XmlArrayItem("time", Type = typeof(Time))]
        public Time[] Forecast { get; set; }
    }

    public class Location
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "timezone")]
        public string TimeZone { get; set; }
        [XmlElement(ElementName = "location")]
        public GeoLocation GeoLocation { get; set; }              
    }

    public class GeoLocation
    {
        [XmlAttribute("altitude")]
        public string Altitude { get; set; }
        [XmlAttribute("latitude")]
        public string Latitude { get; set; }
        [XmlAttribute("longitude")]
        public string Longitude { get; set; }
        [XmlAttribute("geobase")]
        public string Geobase { get; set; }
        [XmlAttribute("geobaseid")]
        public string GeobaseId { get; set; }
    }

    public class Meta
    {
        [XmlElement(ElementName = "lastupdate")]
        public string LastUpdate { get; set; }
        [XmlElement(ElementName = "calctime")]
        public string CalcTime { get; set; }
        [XmlElement(ElementName = "nextupdate")]
        public string NextUpdate { get; set; }
    }


    public class Forecast
    {
        [XmlArray("time")]
        public Time[] Time { get; set; }
    }

    public class Time
    {
        [XmlAttribute("from")]
        public string From { get; set; }
        [XmlAttribute("to")]
        public string To { get; set; }
        [XmlAttribute("day")]
        public string Day { get; set; }
        [XmlElement(ElementName = "symbol")]
        public Symbol Symbol { get; set; }
        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement("windDirection")]
        public WindDirection WindDirection { get; set; }
        [XmlElement("windSpeed")]
        public WindSpeed WindSpeed { get; set; }
        [XmlElement("temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement("pressure")]
        public Pressure Pressure { get; set; }
        [XmlElement("humidity")]
        public Humidity Humidity { get; set; }
        [XmlElement("clouds")]
        public Clouds Clouds { get; set; }
    }

    public class Symbol
    {
        [XmlAttribute("number")]
        public string Number { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("var")]
        public string Var { get; set; }     
    }

    public class WindDirection
    {
        [XmlAttribute("deg")]
        public string Degrees { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class WindSpeed
    {
        [XmlAttribute("mps")]
        public string Mps { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
