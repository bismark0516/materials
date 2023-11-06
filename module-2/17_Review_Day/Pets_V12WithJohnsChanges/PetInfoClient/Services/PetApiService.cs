using PetInfoClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoClient.Services
{
    internal class PetApiService :AuthenticatedApiService
    {

        public PetApiService (string apiUrl) :base(apiUrl)
        {

        }

        public List<Pet> GetPets()
        {
            RestRequest request = new RestRequest("pet");

            IRestResponse<List<Pet>> response = client.Get<List<Pet>>(request);

            CheckForError(response);

            return response.Data;
        }

        public bool DeleteAPet(int petId)
        {
            RestRequest request = new RestRequest("pet/" + petId);
            IRestResponse response = client.Delete(request);

            CheckForError(response);
            return true;
        }

    }
}
