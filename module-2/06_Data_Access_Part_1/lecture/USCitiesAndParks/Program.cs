using USCitiesAndParks.DAO;

namespace USCitiesAndParks
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=UnitedStates;Trusted_Connection=True;";

            ICityDao cityDao = new CitySqlDao(connectionString);
            //ICityDao cityDao = new CityMemoryDao();
            IStateDao stateDao = new StateSqlDao(connectionString);
            IParkDao parkDao = new ParkSqlDao(connectionString);

            USCitiesAndParksCLI cli = new USCitiesAndParksCLI(cityDao, stateDao, parkDao);
            cli.RunCLI();
        }
    }
}
