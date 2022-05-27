namespace DeliveryPlanner;
public class DeliveryTimes
{
	// NB. Code relies on this list being sorted by increasing time
	// and containing at least one time
	List<TimeOnly> _deliveryTimes = new()
	{
		TimeOnly.Parse("08:30"),
		TimeOnly.Parse("09:00"),
		TimeOnly.Parse("12:15"),
		TimeOnly.Parse("13:00"),
		TimeOnly.Parse("15:20"),
	};
	public TimeOnly GetLastDeliveryTime() => _deliveryTimes[^1];

	//System.TimeOnly: struct that stores a time between 00:00 and 23:59
	public TimeOnly? GetNextDeliveryTime(TimeOnly timeNow)
	{
		//we can't use Linq FirstOrDefault() as it returns default value of the type in case of a mismatch. Since TimeOnly is a value type, the default value is 00:00
		int index = _deliveryTimes.FindIndex(time => time >= timeNow);
		return index >= 0 ? _deliveryTimes[index] : null;
	}
	public bool IsDeliveryExpectedWithin30Mins(TimeOnly timeNow)
	{
		TimeOnly? nextDelivery = GetNextDeliveryTime(timeNow);
		return nextDelivery != null && (nextDelivery.Value - timeNow).TotalMinutes <= 30;
	}

}