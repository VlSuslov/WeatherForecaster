using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Clouds
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        [XmlAttribute("all")]
        public string All { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
