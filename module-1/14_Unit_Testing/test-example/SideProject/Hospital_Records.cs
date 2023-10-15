using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SideProject
{
    public class Hospital_Records : Patient
    {
        public Hospital_Records(string firstName, string lastName, int patientID): base (firstName, lastName, patientID)
        {

        }
        private List<string> medicalHistory
        {
            get
            {

                {
                    using (StreamReader sr = new StreamReader(@"C:\Hospital Records\Hospital Records - Sheet1.csv"))
                    {
                        while (!sr.EndOfStream)
                        {
                            medicalHistory.Add(sr.ReadLine());

                        }
                        return medicalHistory;
                    }
                }
            }
        }
        public void Doctor_and_Patient_Records()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ChooseDoctor();
                    break;
                case "2":
                    ChoosePatient();
                    break;
                default:
                    Console.WriteLine("Please Choose a Valid Option");
                    break;
            }

            //try
            //{
            //    using (StreamReader sr = new StreamReader())
            //}
        }

        public void ChooseDoctor()
        {

        }

        public void ChoosePatient()
        {

        }
    }
}



