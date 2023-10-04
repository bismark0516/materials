using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetInfo.DataAccess
{
    public class FileAccess
    {
        private string filename = "c:\\pets\\pets.csv";
        public List<Pet> ReadFile()
        {
            List<Pet> pets = new List<Pet>();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(";");
                    Pet pet = new Pet();
                    pet.Id = int.Parse(temp[0]);
                    pet.Name = temp[1];
                    pet.Age = int.Parse(temp[2]);
                    pet.Type = temp[3];
                    pets.Add(pet);
                }
            }

            //find the largest pet.Id and set the static
            //Pet.nextPetId to one larger than that value

            int largest = 0;
            foreach (Pet pet in pets)
            {
                if (pet.Id > largest)
                {
                    largest = pet.Id;
                }
            }
            Pet.nextPetId = largest + 1;

            return pets;
        }

        public void WriteFile(List<Pet> pets)
        {
            bool result = true;

            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                foreach (Pet pet in pets)
                {
                    string line = $"{pet.Id};{pet.Name};{pet.Age};{pet.Type}";
                    sw.WriteLine(line);
                }
            }
        }
    }
}
