using System;
using System.Runtime.Serialization;

namespace Presentation.Api.Models
{
    public class WeatherModel
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
        
        [DataMember(Name = "temp")]
        public decimal Temperature { get; set; }
        
        [DataMember(Name = "pressure")]
        public decimal Pressure { get; set; }
        
        [DataMember(Name = "humidity")]
        public decimal Humidity { get; set; }
        
        [DataMember(Name = "speed")]
        public decimal WindSpeed { get; set; }
    }
}