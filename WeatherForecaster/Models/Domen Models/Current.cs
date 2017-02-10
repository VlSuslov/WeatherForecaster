using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    [XmlRoot("current"), XmlType("current")]
   public class Current
    {
        [XmlElement(ElementName = "city")]
        public City City { get; set; }
        [XmlElement("temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement("humidity")]
        public Humidity Humidity { get; set; }
        [XmlElement("pressure")]
        public Pressure Pressure { get; set; }
        [XmlElement("wind")]
        public Wind Wind { get; set; }
        [XmlElement("clouds")]
        public Clouds Clouds { get; set; }
        [XmlElement("visibility")]
        public string Visibility { get; set; }
        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement(ElementName = "weather")]
        public Weather Weather { get; set; }
        [XmlElement(ElementName = "lastupdate")]
        public LastUpdate LastUpdate { get; set; }
    }

    public class City
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "coord")]
        public Coordinate Coordinate { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }

    }

    public class Coordinate
    {
        [XmlAttribute("lat")]
        public string Latitude { get; set; }
        [XmlAttribute("lon")]
        public string Longitude { get; set; }
    }

    public class Weather
    {
        [XmlAttribute("number")]
        public string Number { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("icon")]
        public string Icon { get; set; }
    }

    public class LastUpdate
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
