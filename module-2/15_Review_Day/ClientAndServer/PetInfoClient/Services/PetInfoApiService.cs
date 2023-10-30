using Microsoft.VisualBasic.FileIO;
using PetInfoClient.Models;
using RestSharp;


namespace PetInfoClient.Services
{

    public class PetInfoApiService
    {
        protected static RestClient client;

        public PetInfoApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public List<Pet> GetPets()
        {
            RestRequest request = new RestRequest("pet");
            IRestResponse<List<Pet>> response = client.Get<List<Pet>>(request);

            CheckForError(response, "Get Pets");
            return response.Data;
        }

        public bool DeleteAPet(int petId)
        {

            RestRequest request = new RestRequest($"pet/{petId}");
            IRestResponse response = client.Delete(request);

            CheckForError(response, "Delete Pets");
            return true;

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
