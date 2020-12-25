using System;
using System.Runtime.Serialization;

namespace Presentation.Api.Models
{
    public class WeatherModel
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
        
        [DataMember(Name = "temp")]
        public int Temperature { get; set; }
        
        [DataMember(Name = "pressure")]
        public int Pressure { get; set; }
        
        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }
        
        [DataMember(Name = "speed")]
        public decimal WindSpeed { get; set; }
    }
}