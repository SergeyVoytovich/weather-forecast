using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Presentation.Api.Models
{
    public class CityModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "weather")] 
        public IList<WeatherModel> Weather { get; set; } = new List<WeatherModel>();
    }
}