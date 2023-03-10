using DnsClient.Protocol;

namespace flightSearchEngine_back.Models
{
    public class Interval<T>
    {
        public T min { get; set; }
        public T max { get; set; }

        public Interval(T min,T max) 
        {
            this.min = min;
            this.max = max;

        }
    }
}