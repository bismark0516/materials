namespace PetInfoClient
{
    class Program
    {
        private const string apiUrl = "https://localhost:44315/";
        static void Main()
        {
            PetInfoApp app = new PetInfoApp(apiUrl);
            app.Run();
        }
    }
}
