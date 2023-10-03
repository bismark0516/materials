using ExceptionHandlingLecture;
using System.IO.Pipes;
using System.Linq.Expressions;
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
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("An arguement out of range error occured"+ ex.Message);
        }
        

        catch(ArgumentException ex)
        {
            Console.WriteLine("An error occurred " + ex.Message);
        }
        finally
        {
            Console.WriteLine("program ending");
        }
    }
}
