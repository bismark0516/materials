using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using PetInfoClient.Models;

namespace PetInfoClient.Services
{
    public class PetApiService : AuthenticatedApiService
    {
        public PetApiService(string apiUrl) : base(apiUrl)
        {

        }
               
        public List<Pet> GetPets()
        {
            RestRequest request = new RestRequest("pet");
            IRestResponse<List<Pet>> response = client.Get<List<Pet>>(request);

            CheckForError(response);
            return response.Data;
        }
        public bool DeletePet(int petId)
        {

            RestRequest request = new RestRequest("{id}");
            IRestResponse <Pet> response = client.Delete <Pet>(request);

            CheckForError(response);
            return true;
        }
    }
}
