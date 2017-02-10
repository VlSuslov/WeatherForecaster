using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecaster.Models.Domen_Models
{
    public class Sun
    {
        [XmlAttribute("rise")]
        public string Rise { get; set; }
        [XmlAttribute("set")]
        public string Set { get; set; }
    }
}
