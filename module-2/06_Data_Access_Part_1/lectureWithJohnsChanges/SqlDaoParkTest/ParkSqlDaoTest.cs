using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace SqlDaoParkTest
{
    [TestClass]
    public class ParkSqlDaoTest
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=UnitedStates;Trusted_Connection=True;";


        [TestMethod]
        public void GetParksByStateTest()
        {

            //Arrange

            ParkSqlDao parkDao = new ParkSqlDao(connectionString);

            //Act
            IList<Park> parks = parkDao.GetParksByState("WY");

            //Assert

            Assert.IsTrue(parks.Count > 0);
        }
    }
}
