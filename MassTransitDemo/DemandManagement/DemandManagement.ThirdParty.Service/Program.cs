using DemandManagement.MessageContracts;
using DemandManagement.ThirdParty.Service;
using MassTransit;

Console.Title = "ThirdParty";
var bus = BusConfigurator.ConfigureBus(cfg =>
                                       {
	                                       cfg.ReceiveEndpoint(RabbitMqConsts.ThirdPartyServiceQueue,
	                                                           e =>
	                                                           {
		                                                           e.Consumer<DemandRegisteredEventConsumer>();
																   e.UseRateLimit(1000, TimeSpan.FromMinutes(1));
															   });
                                       });

bus.StartAsync();
Console.WriteLine("Listening for Demand registered events.. Press enter to exit");
Console.ReadLine();
bus.StopAsync();