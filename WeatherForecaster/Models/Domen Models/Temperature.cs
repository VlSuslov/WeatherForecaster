using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Temperature
    {
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlAttribute("min")]
        public string Min { get; set; }
        [XmlAttribute("max")]
        public string Max { get; set; }
        [XmlAttribute("day")]
        public string Day { get; set; }
        [XmlAttribute("night")]
        public string Night { get; set; }
        [XmlAttribute("eve")]
        public string Evening { get; set; }
        [XmlAttribute("morn")]
        public string Morning { get; set; }
    }
}
