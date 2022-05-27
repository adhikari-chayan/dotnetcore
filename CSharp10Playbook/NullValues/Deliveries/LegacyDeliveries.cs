﻿namespace DeliveryPlanner;
#nullable disable
public class LegacyDeliveries
{ 
	//	TimeOnly NextBeHereTime { get; init; } = TimeOnly.Parse("17:00");
	// NB. Code relies on this list being sorted by increasing time
	// and containing at least one time
	List<Delivery> _deliveries = new()
	{
		new("Daily newspapers", TimeOnly.Parse("08:30")),
		new("Fruit", TimeOnly.Parse("09:00")),
		new("Frozen food", TimeOnly.Parse("12:15")),
		new("Bakery", TimeOnly.Parse("13:00")),
		new("Medicines", TimeOnly.Parse("15:20")),
	};

    public Delivery GetLastDelivery() => _deliveries[^1];
	
    //There is no ? syntax for reference types here because nullability is assumed for all reference types
    public Delivery GetNextDelivery(TimeOnly timeNow)
		=> _deliveries.FirstOrDefault(delivery => delivery.Time >= timeNow);
	public bool IsDeliveryExpectedWithin30Mins(TimeOnly timeNow)
	{
		Delivery nextDelivery = GetNextDelivery(timeNow);
		return nextDelivery != null && (nextDelivery.Time - timeNow).TotalMinutes <= 30;
	}
}

