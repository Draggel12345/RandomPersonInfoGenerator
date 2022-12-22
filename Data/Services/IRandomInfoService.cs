using System;

namespace RandomPersonInfoGenerator.Data.Services
{
    public interface IRandomInfoService
    {
        string GetRandomMaleFirstName();
        string GetRandomFemaleFirstName();
        string GetRandomLastName();
        DateTime GetRandomDateOfBirth();
        string GetRandomGender();
    }
}
