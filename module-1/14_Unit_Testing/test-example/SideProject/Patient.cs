using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SideProject
{
    public class Patient
    {
        protected int patientID;
        protected string patientFirstName;
        protected string patientLastName;

        public Patient(string firstName, string lastName, int patientID)
        {
            patientFirstName = firstName;
            patientLastName = lastName;
            this.patientID = patientID;
        }

        private List<string> listOfVacations
        {
            get
            {
                using (StreamReader sr = new StreamReader("medicalrecord.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        listOfVacations.Add(sr.ReadLine());

                    }
                    return listOfVacations;
                }


            }
        }

    }
}
