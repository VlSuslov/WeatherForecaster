using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Precipitation
    {
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("mode")]
        public string Mode { get; set; }
    }
}
