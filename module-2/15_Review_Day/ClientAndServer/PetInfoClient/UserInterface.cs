using PetInfoClient.Models;
using PetInfoClient.Services;
using System;
using System.Net.Mail;

namespace PetInfoClient
{
    public class UserInterface
    {

        private readonly WeatherForecastApiService weatherForecastApiService;
        private readonly ConsoleService console = new ConsoleService();

        private readonly string url = "";
       


        public UserInterface(string url)
        {
            this.url = url;
            weatherForecastApiService = new WeatherForecastApiService(url);
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine();

                MainMenu();
                string menuSelection = console.PromptForString("Please choose an option");

                if (menuSelection == "Z")
                {
                    // Exit the loop
                    break;
                }

                else if (menuSelection == "W")
                {
                    // List hotels
                    ShowWeather();
                }

                else
                {
                    Console.WriteLine("Please try again");
                }

               

            }
        }

        private void MainMenu()
        {
            Console.WriteLine( "Pet Info");
            Console.WriteLine("W - Weather");
            Console.WriteLine("Z - Exit");
        }

        private void ShowWeather()
        {
            try
            {
                List<WeatherForecast> forecasts = weatherForecastApiService.GetForcasts();

                foreach (WeatherForecast forecast in forecasts)
                {
                    Console.WriteLine(forecast);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }
        }

    }
}
