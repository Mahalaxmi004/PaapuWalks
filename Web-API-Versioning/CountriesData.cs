using Web_API_Versioning.Models;

namespace Web_API_Versioning
{
    public class CountriesData
    {
        public static List<Country> Get()
        {
            var countries = new List<Country>
            {
                new Country{Id=1,Name="UnitedStates"}
                ,new Country{Id=2,Name="Africa"}
            };

            return countries;



            //var countries = new[]
            //{
            //    new {Id = 1, Name="United states"},
            //    new {Id = 2,Name = "Italy"},
            //     new {Id = 3,Name = "Africa"},
            //      new {Id = 4,Name = "Russia"},
            //       new {Id = 5,Name = "Australia"}
            //};

            //return countries.Select(c=>new Country { Id = c.Id, Name = c.Name }).ToList();
        }
    }
}
