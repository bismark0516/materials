using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetInfo
{
    public class FileAccess
    {
        private string filename = @"c:\petinfo\petinfo.csv";

        public List<Pet> GetPets()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                using(StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] fields = line.Split(",");

                        Pet pet = new Pet();
                        pet.Id = int.Parse(fields[0]);
                        pet.Name = fields[1];
                        pet.Age = int.Parse(fields[2]);
                        pet.Type = fields[3];

                        pets.Add(pet);
                    }
                }
            }
            catch (IOException ex)
            {
                pets = new List<Pet>();
            }

            return pets;
            
        }

        public bool WritePets(List<Pet> pets)
        {
            return false;
        }
    }
}
