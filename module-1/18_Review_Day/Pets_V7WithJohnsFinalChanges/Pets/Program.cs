using System;

namespace PetInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Owner bob = new Owner("Bob", "bob123@gmail.com");

            UserInterface ui = new UserInterface();
            ui.Run();
        }
    }
}
