using DemandManagement.MessageContracts;
using MassTransit;

namespace DemandManagement.Registration;

public class RegisterDemandCommandConsumer : IConsumer<IRegisterDemandCommand>
{
	public async Task Consume(ConsumeContext<IRegisterDemandCommand> context)
	{
		var message = context.Message;
		var guid = Guid.NewGuid();
		await Task.Delay(1000);
		Console.WriteLine($"Demand successfully  registered. Subject:{message.Subject}, Description:{message.Description}, Id:{guid}, Time:{DateTime.Now}");
		await context.Publish<IDemandRegisteredEvent>(new
		                                              {
			                                              DemandId = guid,
			                                              Subject = message.Subject,
			                                              Description = message.Description
		                                              });
	}
}