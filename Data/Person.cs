using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPersonInfoGenerator.Data
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"Person Info:\nName: {FirstName} {LastName}.\nAge: {Age}{(Age > 1 ? " years" : " year")} old.\nGender: {Gender}\n";
        }
    }
}
