using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace brainjammer_cosmosdb
{
    public class Brainwave
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "pk")]
        public string Partition { get; set; }
        public Session Session { get; set; }
    }
    public class Session
    {
        public string Scenario { get; set; }
        public List<POWReading> POWReading { get; set; }
    }
    public class POWReading
    {
        public DateTime ReadingDate { get; set; }
        public int Counter { get; set; }
        public List<AF3> AF3 { get; set; }
        public List<T7> T7 { get; set; }
        public List<Pz> Pz { get; set; }
        public List<T8> T8 { get; set; }
        public List<AF4> AF4 { get; set; }
    }
    public class AF3
    {
        public double THETA { get; set; }
        public double ALPHA { get; set; }
        public double BETA_L { get; set; }
        public double BETA_H { get; set; }
        public double GAMMA { get; set; }
    }
    public class T7
    {
        public double THETA { get; set; }
        public double ALPHA { get; set; }
        public double BETA_L { get; set; }
        public double BETA_H { get; set; }
        public double GAMMA { get; set; }
    }
    public class Pz
    {
        public double THETA { get; set; }
        public double ALPHA { get; set; }
        public double BETA_L { get; set; }
        public double BETA_H { get; set; }
        public double GAMMA { get; set; }
    }
    public class T8
    {
        public double THETA { get; set; }
        public double ALPHA { get; set; }
        public double BETA_L { get; set; }
        public double BETA_H { get; set; }
        public double GAMMA { get; set; }
    }
    public class AF4
    {
        public double THETA { get; set; }
        public double ALPHA { get; set; }
        public double BETA_L { get; set; }
        public double BETA_H { get; set; }
        public double GAMMA { get; set; }
    }
}
