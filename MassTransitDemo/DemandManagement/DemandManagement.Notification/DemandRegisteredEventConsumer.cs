using DemandManagement.MessageContracts;
using MassTransit;

namespace DemandManagement.Notification
{
	public class DemandRegisteredEventConsumer : IConsumer<IDemandRegisteredEvent>
	{
		public async Task Consume(ConsumeContext<IDemandRegisteredEvent> context)
		{
			await Console.Out.WriteLineAsync($"Notification sent: Demand id {context.Message.DemandId}, Time:{DateTime.Now}");
		}
	}
}