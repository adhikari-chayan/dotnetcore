using ProtoBuf;
using System;

namespace ProtobuDemo
{
    [ProtoContract]
    public class WeatherForecast
    {
        [ProtoMember(1)]
        public DateTime Date { get; set; }

        [ProtoMember(2)]
        public int TemperatureC { get; set; }

        //Unable to serialize and deserialize using protobuf
        //[ProtoMember(3)]
        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [ProtoMember(3)]
        public string Summary { get; set; }

    }
}
