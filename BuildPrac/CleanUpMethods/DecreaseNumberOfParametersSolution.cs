using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuildPrac.CleanUpMethods
{


    public class PersonRecord
    {
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string FileLocation { get; set; }
    }
    public class DecreaseNumberOfParametersSolution
    {
       
        public DecreaseNumberOfParametersSolution(string name, string homeAddress,
            string country, string email, string telephone, string fileLocation)
        {
            var record = new PersonRecord()
            {
                 Name=name,
                 HomeAddress=homeAddress,
                 Country=country,
                 Email=email,
                 Telephone=telephone,
                 FileLocation=fileLocation
            };
            SaveHomeAddress(record);
        }

        public void SaveHomeAddress(PersonRecord personRecord)
        {

            if (string.IsNullOrEmpty(personRecord.Name) || string.IsNullOrEmpty(personRecord.HomeAddress)
                || string.IsNullOrEmpty(personRecord.FileLocation) || string.IsNullOrEmpty(personRecord.Telephone))
            {
                Console.WriteLine("Input parameters are empty");
            }
            else
            {
                using FileStream fileStream = new FileStream(personRecord.FileLocation, FileMode.Append);
                using StreamWriter writer = new StreamWriter(fileStream);
                List<string> aPersonRecod = new List<string>
                {
                    personRecord.Name,
                    personRecord.HomeAddress,
                    personRecord.Country,
                    personRecord.Email,
                    personRecord.Telephone
                };
                writer.WriteLine(aPersonRecod);
            }
        }
    }
}
