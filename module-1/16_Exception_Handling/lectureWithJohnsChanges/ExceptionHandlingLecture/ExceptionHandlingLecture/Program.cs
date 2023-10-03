using ExceptionHandlingLecture;
using System.Reflection.Metadata;

public class Program
{
    private static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();

        try
        {
            ui.Run("John");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("An Arguemnt out of Range error occurred: " + ex.Message);
        }
    
        catch (ArgumentException ex)
        {
            Console.WriteLine("An Argument Exception error occurred: "+ ex.Message);
        }
        catch (JohnHasDoneSomethingBadException ex)
        {
            Console.WriteLine("Oh, boy : " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program ending.");
        }
    }
}
