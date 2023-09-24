using DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{
    public class UserInterface
    {
        private PetInfo petInfo = new PetInfo();
        public void Run()
        {
            DisplayWelcome();

            bool done = false;

            while (!done)
            {
                DisplayMenu();
                string selection = Console.ReadLine();

                switch(selection)
                {
                    case "1":
                        AddPet();
                        break;
                    case "2":
                        DeletePet();
                        break;
                    case "3":
                        ListPets();
                        break;
                    case "E":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value.");
                        Console.WriteLine();
                        break;
                }
               
            } //end of while

        }

        private void ListPets()
        {
            Pet[] pets = petInfo.GetPets();
            foreach (Pet pet in pets)
            {
                Console.WriteLine(pet);
                Console.WriteLine();
            }
        }

        private void DeletePet()
        {
            throw new NotImplementedException();
        }

        private void AddPet()
        {
            Pet pet = new Pet ();

            Console.Write("Name: ");
            pet.Name = Console.ReadLine();

            Console.Write("Type (dog, cat, parrot, etc.): ");
            pet.Type = Console.ReadLine();

            Console.Write("Age in years (3, 6, 19, etc.): ");
            pet.Age = int.Parse(Console.ReadLine());

            bool result = petInfo.AddPet(pet);
                if (result)
            {
                Console.WriteLine("Pet Added.");
                Console.WriteLine();
            }
                else
            {
                Console.WriteLine("Unable to add pet");
                Console.WriteLine();
            }

        }

        private void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Pets Application!");
            Console.WriteLine("We hope you have fun.");
            Console.WriteLine();

        }
        private void DisplayMenu()
        {
            Console.WriteLine("1 - Add a pet");
            Console.WriteLine("2 - Delete a pet");
            Console.WriteLine("3 - List pets");
            Console.WriteLine("E - Exit program");
        }
    }
}
