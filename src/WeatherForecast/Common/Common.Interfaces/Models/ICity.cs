using System.Collections.Generic;

namespace Common.Interfaces.Models
{
    public interface ICity
    {
        int Id { get; set; }
        string Name { get; set; }
        int ZipCode { get; set; }
        
        IList<IWeather> Weather { get; set; }
    }
}