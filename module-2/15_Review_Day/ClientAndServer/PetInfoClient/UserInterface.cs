using PetInfoClient.Models;
using PetInfoClient.Services;
using System;
using System.Net.Mail;

namespace PetInfoClient
{
    public class UserInterface
    {

        private readonly WeatherForecastApiService weatherForecastApiService;
        private readonly PetInfoApiService petInfoApiService;
        private readonly ConsoleService console = new ConsoleService();

        private readonly string url = "";
       


        public UserInterface(string url)
        {
            this.url = url;
            weatherForecastApiService = new WeatherForecastApiService(url);
            petInfoApiService = new PetInfoApiService(url);
        }
        public void Run()
        {
            bool isDone = false;

            while (!isDone)
            {
                DisplayMenu();

                string userResponse = console.PromptForString("Please choose an option"); ;

                switch (userResponse)
                {
                    case "1":
                        ListPets();
                        break;
                    case "2":
                        //AddAPet();
                        break;
                    case "3":
                        //UpdateAPet();
                        break;
                    case "4":
                        DeleteAPet();
                        break;
                    case "5":
                        //ListOwners();
                        break;
                    case "6":
                        //AddAnOwner();
                        break;
                    case "7":
                        //UpdateAnOwner();
                        break;
                    case "8":
                        //DeleteAnOwner();
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

        //private void UpdateAnOwner()
        //{
        //    Owner updatedOwner = new Owner();

        //    try
        //    {
        //        ListOwners();

        //        Console.WriteLine("Enter owner number to update: ");
        //        int ownerId = int.Parse(Console.ReadLine());

        //        updatedOwner = owners.GetOwner(ownerId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }

        //    Console.WriteLine("Please enter an owner name (Enter to leave unchanged): ");
        //    string result = Console.ReadLine();
        //    if (result != "")
        //    {
        //        updatedOwner.Name = result;
        //    }

        //    Console.WriteLine("Please enter the owner email (Enter to leave unchaged): ");
        //    result = Console.ReadLine();

        //    if (result != "")
        //    {
        //        updatedOwner.Email = result;
        //    }

        //    try
        //    {
        //        owners.UpdateOwner(updatedOwner);

        //        Console.WriteLine("Updated owner.");
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Unable to update owner.");
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //private void AddAnOwner()
        //{
        //    Owner newOwner = new Owner();

        //    Console.WriteLine("Please enter an owner name: ");
        //    newOwner.Name = Console.ReadLine();

        //    Console.WriteLine("Please enter the owner email: ");
        //    newOwner.Email = Console.ReadLine();

        //    try
        //    {
        //        owners.AddAOwner(newOwner);
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Unable to add owner.");
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //private void ListOwners()
        //{
        //    try
        //    {
        //        List<Owner> temp = owners.ListOwners();

        //        Console.WriteLine();

        //        if (temp.Count == 0)
        //        {
        //            Console.WriteLine("No owners in list.");
        //        }
        //        else
        //        {
        //            foreach (Owner owner in temp)
        //            {
        //                Console.WriteLine(owner);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //private void DeleteAnOwner()
        //{
        //    try
        //    {
        //        ListOwners();

        //        Console.WriteLine("Enter owner number to delete: ");
        //        int response = int.Parse(Console.ReadLine());

        //        owners.DeleteAOwner(response);

        //        Console.WriteLine("Owner deleted.");
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Owner not deleted.");
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        private void DeleteAPet()
        {
            try
            {
                ListPets();

                Console.WriteLine("Enter pet number to delete: ");
                int response = int.Parse(Console.ReadLine());

                petInfoApiService.DeleteAPet(response);

                Console.WriteLine("Pet deleted.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Pet not deleted.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //private void UpdateAPet()
        //{

        //    Pet updatedPet = new Pet();

        //    try
        //    {
        //        ListPets();

        //        Console.WriteLine("Enter pet number to update: ");
        //        int petId = int.Parse(Console.ReadLine());

        //        updatedPet = pets.GetPet(petId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }

        //    Console.WriteLine("Please enter a pet name (Enter to leave unchanged): ");
        //    string result = Console.ReadLine();
        //    if (result != "")
        //    {
        //        updatedPet.Name = result;
        //    }

        //    try
        //    {
        //        Console.WriteLine("Please enter the pet's age (Enter to leave unchaged): ");
        //        result = Console.ReadLine();
        //        if (result != "")
        //        {
        //            updatedPet.Age = int.Parse(result);
        //        }
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return;
        //    }
        //    catch (PetAgeException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return;
        //    }

        //    Console.WriteLine("Please enter the type of pet (dog, cat, turtle, etc.) (Enter to leave unchaged): ");
        //    result = Console.ReadLine();

        //    if (result != "")
        //    {
        //        updatedPet.Type = result;
        //    }


        //    ListOwners();

        //    try
        //    {
        //        Console.WriteLine("Please enter owner id (Enter to leave unchaged, 0 if no owner): ");
        //        result = Console.ReadLine();
        //        if (result != "")
        //        {
        //            updatedPet.Owner = int.Parse(result);
        //        }
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return;
        //    }


        //    try
        //    {
        //        pets.UpdatePet(updatedPet);

        //        Console.WriteLine("Updated pet.");
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Unable to update pet.");
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //private void AddAPet()
        //{
        //    Pet newPet = new Pet();

        //    Console.WriteLine("Please enter a pet name: ");
        //    newPet.Name = Console.ReadLine();

        //    newPet.Age = 0;
        //    while (newPet.Age == 0)
        //    {
        //        try
        //        {
        //            Console.WriteLine("Please enter the pet's age: ");
        //            newPet.Age = int.Parse(Console.ReadLine());
        //        }
        //        catch (FormatException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        catch (PetAgeException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            Console.WriteLine("Please enter the correct age.");
        //        }
        //        finally
        //        {
        //            Console.WriteLine("Finished evaluating input.");
        //        }
        //    }

        //    Console.WriteLine("Please enter the type of pet (dog, cat, turtle, etc.): ");
        //    newPet.Type = Console.ReadLine();

        //    ListOwners();

        //    try
        //    {
        //        Console.WriteLine("Please enter owner id.");
        //        string result = Console.ReadLine();
        //        if (result != "")
        //        {
        //            newPet.Owner = int.Parse(result);
        //        }
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine("Error selecting owner id.");
        //        Console.WriteLine(ex.Message);
        //        return;
        //    }

        //    try
        //    {
        //        pets.AddAPet(newPet);
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Unable to add pet.");
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        private void ListPets()
        {
            try
            {
                //List<Pet> temp = pets.ListPets();
                List<Pet> temp = petInfoApiService.GetPets();


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
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice");
            Console.WriteLine("(1) - List pets");
            Console.WriteLine("(2) - Add a pet");
            Console.WriteLine("(3) - Update a pet");
            Console.WriteLine("(4) - Delete a pet");
            Console.WriteLine("(5) - List owners");
            Console.WriteLine("(6) - Add an owner");
            Console.WriteLine("(7) - Update an owner");
            Console.WriteLine("(8) - Delete an owner");
            Console.WriteLine("(9) - To end the program");
        }

        //public void Run()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine();

        //        MainMenu();
        //        string menuSelection = console.PromptForString("Please choose an option");

        //        if (menuSelection.ToUpper() == "Z")
        //        {
        //            // Exit the loop
        //            break;
        //        }

        //        else if (menuSelection.ToUpper() == "W")
        //        {
        //            // Show Weather
        //            ShowWeather();
        //        }

        //        else
        //        {
        //            Console.WriteLine("Please try again");
        //        }
        //    }
        //}

        //private void MainMenu()
        //{
        //    Console.WriteLine( "Pet Info");
        //    Console.WriteLine("W - Weather");
        //    Console.WriteLine("Z - Exit");
        //}

        //private void ShowWeather()
        //{
        //    try
        //    {
        //        List<WeatherForecast> forecasts = weatherForecastApiService.GetForcasts();

        //        Console.WriteLine();

        //        foreach (WeatherForecast forecast in forecasts)
        //        {
        //            Console.WriteLine(forecast);
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.WriteLine("There was an error: " + ex.Message);
        //    }
        //}


    }
}
