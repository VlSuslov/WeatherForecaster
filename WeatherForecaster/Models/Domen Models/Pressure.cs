using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Pressure
    {
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
