using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAPI
{
    //Класс получения данных от API
    public class WeatherData
    {
        public MainInfo Main { get; set; }
        public List<WeatherInfo> Weather { get; set; }
        public WindInfo Wind { get; set; }
    }

    public class MainInfo
    {
        [JsonProperty("temp")]

        public double TemperatureInCelsius { get; set; }
    }

    public class WeatherInfo
    {
        public string Description { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}
