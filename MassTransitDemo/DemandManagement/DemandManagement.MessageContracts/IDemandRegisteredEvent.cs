namespace DemandManagement.MessageContracts;

public interface IDemandRegisteredEvent
{
	public Guid DemandId { get; set; }

	public string Subject { get; set; }

	public string Description { get; set; }
}