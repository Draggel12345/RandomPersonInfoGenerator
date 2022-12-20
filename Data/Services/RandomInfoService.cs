using RandomPersonInfoGenerator.Data.Data_access;
using System;
using System.Collections.Generic;

namespace RandomPersonInfoGenerator.Data.Services
{
    public class RandomInfoService : IRandomInfoService
    {
        private readonly FileReaderService fileReader = new FileReaderService();
        private readonly static Random rnd = new Random();

        //public List<string> MaleFirstNames { get; set; }
        //public List<string> FemaleFirstNames { get; set; }
        //public List<string> LastNames { get; set; }

        //Returns a new random Person(Male) or Person(Female).
        public Person CreateRandomPerson()
        {
            string gender = GetRandomGender();
            Person person = null;

            //The switch use the random gender-value to set the correct name and gender.ToLower() to the Person-object. 
            switch (gender)
            {
                case "MALE":
                    {
                        person = new Person
                        {
                            FirstName = GetRandomMaleFirstName(),
                            LastName = GetRandomLastName(),
                            Age = GetRandomAge(),
                            Gender = gender.ToLower()
                        };
                        break;
                    }
                case "FEMALE":
                    {
                        person = new Person
                        {
                            FirstName = GetRandomFemaleFirstName(),
                            LastName = GetRandomLastName(),
                            Age = GetRandomAge(),
                            Gender = gender.ToLower()
                        };
                        break;
                    }
            }

            return person;
        }

        //GetRandomMaleFirst/FemaleFirst/LastName...
        //1.Reads the data from the fileReaders-method and stores it in a placeholder variable.
        //2.Then from the placeholder returns ONE random name.  
        private string GetRandomMaleFirstName()
        {
            var maleFirstNames = fileReader.GetMaleFirstNames();
            return maleFirstNames[rnd.Next(0, maleFirstNames.Count)];
        }

        private string GetRandomFemaleFirstName()
        {
            var femaleFirstNames = fileReader.GetFemaleFirstNames();
            return femaleFirstNames[rnd.Next(0, femaleFirstNames.Count)];
        }

        private string GetRandomLastName()
        {
            var lastNames = fileReader.GetLastNames();
            return lastNames[rnd.Next(0, lastNames.Count)];
        }

        //Returns a random number.
        private int GetRandomAge()
        {
            return rnd.Next(0, 101); //101 so Person can be 100 years old.
        }

        //1.A random number between 0 and 100 is made.
        //2.Checks if number is greater than 50, true = FEMALE and false = MALE.
        //3.Returns the (Enum)Genders-value, that's convertet to a string. 
        private string GetRandomGender()
        {
            return rnd.Next(100) > 50 ? Genders.FEMALE.ToString() : Genders.MALE.ToString();
        }
    }
}
