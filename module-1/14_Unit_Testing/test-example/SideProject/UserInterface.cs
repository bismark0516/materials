using System;
using System.Collections.Generic;
using System.Text;

namespace SideProject
{
    public class UserInterface
    {
         Hospital_Records HR = new Hospital_Records("John", "Doe",30);
        
       

        public void Run()
        {
            bool done = false;

            while (!done)
            {
                DisplayMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        HR.Doctor_and_Patient_Records();
                        break;
                    //case "2":
                    //    Prescription_Management();
                    //    break;
                    //case "3":
                    //    Rooms_Management();
                    //    break;
                    //case "4":
                    //    Appointments_Management();
                    //    break;
                    //case "5":
                    //    Billing_Details();
                    //    break;
                    //case "6":
                    //    Patient_History();
                    //    break;
                    case "7":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
                

            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Main Menu");
            Console.WriteLine();
            Console.WriteLine("Select User");
            Console.WriteLine("(1)  Administrator");
            Console.WriteLine("(2)  Doctor");
            Console.WriteLine("(3)  Patient");
          
        }
    }
   
}

