using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Humidity
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
