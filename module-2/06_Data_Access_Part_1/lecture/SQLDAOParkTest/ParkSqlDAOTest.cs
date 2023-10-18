using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace SQLDAOParkTest

{
    [TestClass]
    public class ParkSqlDAOTest
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=UnitedStates;Trusted_Connection=True;";


        [TestMethod]
        public void GetParkByStateTest()
        {
            //arrange
            ParkSqlDao parkDAO = new ParkSqlDao(connectionString);

            //act

            IList<Park> parks= parkDAO.GetParksByState("OH");


            //assert
            Assert.IsTrue(parks.Count > 0);
                



        }
    }
}
