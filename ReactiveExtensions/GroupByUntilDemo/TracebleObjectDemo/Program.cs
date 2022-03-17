using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace TracebleObjectDemo
{
    internal class Program
    {  
     
           
        static void Main(string[] args)
        {
            Subject<TraceableObject> responsePartsSource = new Subject<TraceableObject>();
            
             responsePartsSource.GroupByUntil(e => (e.RequestId, e.SlipKey),
                                           e => e,
                                           e => Observable.Timer(TimeSpan.FromSeconds(10)))
                              .Subscribe(OnNewResponsePartsGroup);




            var requestId = Guid.NewGuid().ToString();
            
            for (int i = 0; i < 2; i++)
            {
                var slipKey = i + 1;

                var inPlayData = new TraceableObject<InplayData>
                {
                    RequestId = requestId,
                    SlipKey = slipKey,
                    Document = new InplayData
                    {
                        Property1 = $"Property1-InPlayData-BetContext{i}",
                        Property2 = $"Property2-InPlayData-BetContext{i}"
                    }
                };
                responsePartsSource.OnNext(inPlayData);

                var betBuilderData = new TraceableObject<BetBuilderData>
                {
                    RequestId = requestId,
                    SlipKey = slipKey,
                    Document = new BetBuilderData
                    {
                        Property1 = $"Property1-BetBuilderData-BetContext{i}",
                        Property2 = $"Property2-BetBuilderData-BetContext{i}"
                    }
                };
                responsePartsSource.OnNext(betBuilderData);

                var virtualSportsData = new TraceableObject<VirtualSportsData>
                {
                    RequestId = requestId,
                    SlipKey = slipKey,
                    Document = new VirtualSportsData
                    {
                        Property1 = $"Property1-VirtualSportsData-BetContext{i}",
                        Property2 = $"Property2-VirtualSportsData-BetContext{i}"
                    }
                };
                responsePartsSource.OnNext(virtualSportsData);
            }

            Console.ReadKey();
        }

     

        private static async void OnNewResponsePartsGroup(IGroupedObservable<(string RequestId, int? SlipKey), TraceableObject> groupedObservable)
        {
            var groupedEvents = await  groupedObservable.ToList();

            var inplayData = groupedEvents.OfType<TraceableObject<InplayData>>().FirstOrDefault()?.Document;

            var betBuilderData = groupedEvents.OfType<TraceableObject<BetBuilderData>>().FirstOrDefault()?.Document;

            var virtualSportsData = groupedEvents.OfType<TraceableObject<VirtualSportsData>>().FirstOrDefault()?.Document;

            Console.WriteLine($"InplayData: {inplayData.Property1}-{inplayData.Property2}");
            Console.WriteLine($"BetBuilderData: {betBuilderData.Property1}-{betBuilderData.Property2}");
            Console.WriteLine($"VirtualSportsData: {virtualSportsData.Property1}-{virtualSportsData.Property2}");
        }

        //private static void TraceData()
        //{
        //    var requestId = Guid.NewGuid().ToString();
        //    for(int i = 0; i < 2; i++)
        //    {
        //        var slipKey = i + 1;
                
        //        var inPlayData = new TraceableObject<InplayData>
        //        {
        //            RequestId = requestId,
        //            SlipKey = slipKey,
        //            Document = new InplayData
        //            {
        //                Property1 = $"Property1-InPlayData-BetContext{i}",
        //                Property2 = $"Property2-InPlayData-BetContext{i}"
        //            }
        //        };
        //        responsePartsSource.OnNext(inPlayData);

        //        var betBuilderData = new TraceableObject<BetBuilderData>
        //        {
        //            RequestId = requestId,
        //            SlipKey = slipKey,
        //            Document = new BetBuilderData
        //            {
        //                Property1 = $"Property1-BetBuilderData-BetContext{i}",
        //                Property2 = $"Property2-BetBuilderData-BetContext{i}"
        //            }
        //        };
        //        responsePartsSource.OnNext(betBuilderData);

        //        var virtualSportsData = new TraceableObject<VirtualSportsData>
        //        {
        //            RequestId = requestId,
        //            SlipKey = slipKey,
        //            Document = new VirtualSportsData
        //            {
        //                Property1 = $"Property1-VirtualSportsData-BetContext{i}",
        //                Property2 = $"Property2-VirtualSportsData-BetContext{i}"
        //            }
        //        };
        //        responsePartsSource.OnNext(virtualSportsData);
        //    }
    }

       
}

