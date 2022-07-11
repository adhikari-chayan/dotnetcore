using DemandManagement.MessageContracts;
using DemandManagement.Notification;
using MassTransit;

Console.Title = "Notification";
var bus = BusConfigurator.ConfigureBus(cfg =>
                                       {
	                                       cfg.ReceiveEndpoint(RabbitMqConsts.NotificationServiceQueue,
	                                                           e =>
	                                                           {
		                                                           e.Consumer<DemandRegisteredEventConsumer>();
		                                                           e.UseMessageRetry(r => r.Immediate(5));
	                                                           });
                                       });

bus.StartAsync();
Console.WriteLine("Listening for Demand registered events.. Press enter to exit");
Console.ReadLine();
bus.StopAsync();