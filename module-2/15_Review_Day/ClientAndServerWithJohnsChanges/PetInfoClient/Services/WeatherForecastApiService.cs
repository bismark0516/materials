using PetInfoClient.Models;
using RestSharp;


namespace PetInfoClient.Services
{

    public class WeatherForecastApiService
    {
        protected static RestClient client;

        public WeatherForecastApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public List<WeatherForecast> GetForcasts()
        {
            RestRequest request = new RestRequest("WeatherForecast");
            IRestResponse<List<WeatherForecast>> response = client.Get<List<WeatherForecast>>(request);

            CheckForError(response, "Get Weathers");
            return response.Data;
        }

        private void CheckForError(IRestResponse response, string action)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException($"Unable to reach the server: " + action);
            }

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"There was an error in the call to the server: " + (int)response.StatusCode + " " + action);
            }

        }
    }
}
