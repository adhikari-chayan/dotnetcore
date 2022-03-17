namespace TracebleObjectDemo
{
    internal class TraceableObject
    {
        public string? RequestId { get; set; }
        public int? SlipKey { get; set; }   
    }

    internal class TraceableObject<T>: TraceableObject
    {
        public T Document { get; set; }
    }

    internal class InplayData
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }

    internal class BetBuilderData
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }

    internal class VirtualSportsData
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}
