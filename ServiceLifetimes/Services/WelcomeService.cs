namespace ServiceLifetimes.Services;

public class WelcomeService : IWelcomeService
{
    private readonly DateTime _serviceCreated = DateTime.Now;
    private readonly Guid _serviceId = Guid.NewGuid();

    public string GetWelcomeMessage()
    {
        return $"Welcome! Service created on {_serviceCreated} with id {_serviceId}";
    }
}