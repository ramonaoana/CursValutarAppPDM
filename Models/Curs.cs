using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CursValutarApp.Models
{
    [XmlRoot("Cube",Namespace = "http://www.bnr.ro/xsd")]
    public class Cube
    {
        [XmlAttribute("date")]
        public DateTime date { get; set; }
        [XmlElement("Rate")]
        public List<Curs> ListaCurs { get; set; }
    }

    public class Curs
    {
        [XmlAttribute("currency")]
        [JsonPropertyName("symbol")]
        public string Currency { get; set; }

        [XmlText]
        [JsonPropertyName("current_price")]
        public double Value { get; set; }

        [XmlAttribute("multiplier")]
        [JsonIgnore]
        public int Multiplier { get; set; }

        [XmlIgnore]
        [JsonPropertyName("last_updated")]
        public DateTime Date { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public bool IsCrypto { get; set; }

        [XmlIgnore]
        public string Flag 
        { 
            get 
            {
                if (!IsCrypto)
                {
                    return "https://flagcdn.com/64x48/" + Currency.Substring(0, 2).ToLower() + ".png";
                    // return Currency.Substring(0, 2).ToLower() + ".png";
                }
                else return "https://cryptoicons.org/api/icon/"+Currency+"/64";

            } 
        }

        public Curs()
        {
            Multiplier = 1;
            IsCrypto = true;
        }

        public override string ToString()
        {
            return Currency;
        }

        

    }
}
