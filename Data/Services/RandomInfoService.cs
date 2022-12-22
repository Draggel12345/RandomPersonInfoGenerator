using RandomPersonInfoGenerator.Data.Data_access;
using System;
using System.Collections.Generic;

namespace RandomPersonInfoGenerator.Data.Services
{
    public class RandomInfoService : IRandomInfoService
    {
        private readonly FileReaderService fileReader = new FileReaderService();
        private readonly static Random rnd = new Random();

        ////Returns a new random Person(Male) or Person(Female).
        //public Person CreateRandomPerson()
        //{
        //    string gender = GetRandomGender();
        //    Person person = null;

        //    //The switch use the random gender-value to set the correct name and gender.ToLower() to the Person-object. 
        //    switch (gender)
        //    {
        //        case "MALE":
        //            {
        //                person = new Person
        //                {
        //                    FirstName = GetRandomMaleFirstName(),
        //                    LastName = GetRandomLastName(),
        //                    Age = GetRandomAge(),
        //                    Gender = gender.ToLower()
        //                };
        //                break;
        //            }
        //        case "FEMALE":
        //            {
        //                person = new Person
        //                {
        //                    FirstName = GetRandomFemaleFirstName(),
        //                    LastName = GetRandomLastName(),
        //                    Age = GetRandomAge(),
        //                    Gender = gender.ToLower()
        //                };
        //                break;
        //            }
        //    }

        //    return person;
        //}

        //GetRandomMaleFirst/FemaleFirst/LastName...
        //1.Reads the data from the fileReaders-method and stores it in a placeholder variable.
        //2.Then from the placeholder returns ONE random name.  
        public string GetRandomMaleFirstName()
        {
            var maleFirstNames = fileReader.GetMaleFirstNames();
            if (maleFirstNames.Count <= 0)
            {
                return "Empty";
            }
            return maleFirstNames[rnd.Next(0, maleFirstNames.Count)];
        }

        public string GetRandomFemaleFirstName()
        {
            var femaleFirstNames = fileReader.GetFemaleFirstNames();
            if (femaleFirstNames.Count <= 0)
            {
                return "Empty";
            }
            return femaleFirstNames[rnd.Next(0, femaleFirstNames.Count)];
        }

        public string GetRandomLastName()
        {
            var lastNames = fileReader.GetLastNames();
            if (lastNames.Count <= 0)
            {
                return "Empty";
            }
            return lastNames[rnd.Next(0, lastNames.Count)];
        }

        //Returns a random birthdate.
        //The year value is between Today(2022 - 100) = 1922 and Today(2022 + 1), max age is 100. 
        public DateTime GetRandomAge()
        {
            int year = rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year + 1);
            int month = rnd.Next(1, 13);
            int day = 0;

            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                day += rnd.Next(1, 31);
            }
            else if (DateTime.IsLeapYear(year) && month == 2)
            {
                day += rnd.Next(1, 30);
            }
            else if (month == 2)
            {
                day += rnd.Next(1, 29);
            }
            else
            {
                day += rnd.Next(1, 32);
            }

            return new DateTime(year, month, day);
        }

        //1.A random number between 0 and 100 is made.
        //2.Checks if number is greater than 50, true = FEMALE and false = MALE.
        //3.Returns the (Enum)Genders-value, that's convertet to a string. 
        public string GetRandomGender()
        {
            return rnd.Next(100) > 50 ? Genders.FEMALE.ToString() : Genders.MALE.ToString();
        }
    }
}
