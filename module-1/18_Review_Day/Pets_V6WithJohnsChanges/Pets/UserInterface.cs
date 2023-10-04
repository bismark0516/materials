using System;
using PetInfo.Exceptions;

namespace PetInfo
{
    class UserInterface
    {
        private Pets pets = new Pets();

        public void Run()
        {
            bool isDone = false;

            while (!isDone)
            {
                DisplayMenu();

                string userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        ListPets();
                        break;
                    case "2":
                        AddAPet();
                        break;
                    case "3":
                        DeleteAPet();
                        break;
                    case "9":
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }

        private void DeleteAPet()
        {
            ListPets();

            Console.WriteLine("Enter pet number to delete: ");
            int response = int.Parse(Console.ReadLine());

            bool result = pets.DeleteAPet(response);

            Console.WriteLine();
            if (result)
            {
                Console.WriteLine("Pet deleted.");
            }
            else
            {
                Console.WriteLine("Unable to delete pet.");
            }
        }

        private void AddAPet()
        {
            Pet newPet = new Pet();

            Console.WriteLine("Please enter a pet name: ");
            newPet.Name = Console.ReadLine();

            newPet.Age = 0;
            while (newPet.Age == 0)
            {
                try
                {
                    Console.WriteLine("Please enter the pet's age: ");
                    newPet.Age = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (PetAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter the correct age.");
                }
                finally
                {
                    Console.WriteLine("Finished evaluating input.");
                }
            }

            Console.WriteLine("Please enter the type of pet (dog, cat, turtle, etc.): ");
            newPet.Type = Console.ReadLine();

            bool result = pets.AddAPet(newPet);
        }

        private void ListPets()
        {
            Pet[] temp = pets.ListPets();

            Console.WriteLine();

            if (temp.Length == 0)
            {
                Console.WriteLine("No pets in list.");
            }
            else
            {
               foreach (Pet pet in temp)
                {
                    Console.WriteLine(pet);
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice");
            Console.WriteLine("To list pets, press 1.");
            Console.WriteLine("To add a pet, press 2.");
            Console.WriteLine("To delete a pet, press 3.");
            Console.WriteLine("To end the program, press 9.");
        }
    }
}
