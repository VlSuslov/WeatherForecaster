
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Wind
    {
        [XmlElement(ElementName = "speed")]
        public Speed Speed { get; set; }
        [XmlElement(ElementName = "gusts")]
        public string Gusts { get; set; }
        [XmlElement(ElementName = "direction")]
        public Direction Direction { get; set; }
    }

    public class Speed
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class Direction
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
