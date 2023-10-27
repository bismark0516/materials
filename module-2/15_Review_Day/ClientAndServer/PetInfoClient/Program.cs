using PetInfoClient;

internal class Program
{
    private const string url = "https://localhost:7226/";
    private static void Main(string[] args)
    {
        UserInterface ui = new UserInterface(url);
        ui.Run();
    }
}
