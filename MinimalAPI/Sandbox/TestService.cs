namespace MinimalAPI;

public interface ITestService
{
    public string Hello();
}

public class TestService : ITestService
{
    public string Hello()
    {
        return "4dotnet";
    }
}