using DemandManagement.MessageContracts;
using MassTransit;

namespace DemandManagement.ThirdParty.Service
{
	public class DemandRegisteredEventConsumer : IConsumer<IDemandRegisteredEvent>
	{
		public async Task Consume(ConsumeContext<IDemandRegisteredEvent> context)
		{
			await Console.Out.WriteLineAsync($"ThirdParty integration done: Demand id {context.Message.DemandId}, Time:{DateTime.Now}");
		}
	}
}
