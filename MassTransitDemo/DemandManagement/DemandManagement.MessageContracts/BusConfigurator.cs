using MassTransit;

namespace DemandManagement.MessageContracts;

public static class BusConfigurator
{
	public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
	{
		return Bus.Factory.CreateUsingRabbitMq(cfg =>
		                                       {
			                                       cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri),
			                                                host =>
			                                                {
				                                                host.Username(RabbitMqConsts.UserName);
				                                                host.Password(RabbitMqConsts.Password);
			                                                });

			                                       registrationAction?.Invoke(cfg);
		                                       });
	}
}