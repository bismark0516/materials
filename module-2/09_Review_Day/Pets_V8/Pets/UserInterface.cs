using System;
using System.Collections.Generic;
using System.IO;
using PetInfo.DAL;
using PetInfo.Exceptions;
using PetInfo.Models;

namespace PetInfo
{
    class UserInterface
    {
        private PetDao pets = new PetDao();

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
                        UpdateAPet();
                        break;
                    case "4":
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
            try
            {
                ListPets();

                Console.WriteLine("Enter pet number to delete: ");
                int response = int.Parse(Console.ReadLine());

                pets.DeletePet(response);

                Console.WriteLine("Pet deleted.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Pet not deleted.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void UpdateAPet()
        {

            Pet updatedPet = new Pet();

            try
            {
                ListPets();

                Console.WriteLine("Enter pet number to update: ");
                int petId = int.Parse(Console.ReadLine());

                updatedPet = pets.GetPet(petId);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Please enter a pet name (Enter to leave unchanged): ");
            string result = Console.ReadLine();
            if (result != "")
            {
                updatedPet.Name = result;
            }

            try
            {
                Console.WriteLine("Please enter the pet's age (Enter to leave unchaged): ");
                result = Console.ReadLine();
                if (result != "")
                {
                    updatedPet.Age = int.Parse(result);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (PetAgeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Please enter the type of pet (dog, cat, turtle, etc.) (Enter to leave unchaged): ");
            result = Console.ReadLine();

            if (result != "")
            {
                updatedPet.Type = result;
            }

            try
            {
                pets.UpdatePet(updatedPet);

                Console.WriteLine("Updated pet.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Unable to update pet.");
                Console.WriteLine("Error: " + ex.Message);
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

            try
            {
                pets.AddPet(newPet);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Unable to add pet.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ListPets()
        {
            try
            {
                List<Pet> temp = pets.ListPets();

                Console.WriteLine();

                if (temp.Count == 0)
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
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice");
            Console.WriteLine("To list pets, press 1.");
            Console.WriteLine("To add a pet, press 2.");
            Console.WriteLine("To update a pet, press 3.");
            Console.WriteLine("To delete a pet, press 4.");
            Console.WriteLine("To end the program, press 9.");
        }
    }
}
