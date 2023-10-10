using Assessment.Classes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Tests
{
    [TestClass]
    public class ClassesTest
    {
        [TestMethod]
        public void TicketPurchaseTest()
        {
            //arrange create an instance of the class
            TicketPurchase ticketPurchase = new TicketPurchase("Bill", 10);

            //act call the method that is being tested 
            decimal TotalPrice = ticketPurchase.TotalPrice(true, true);

            //assert
            Assert.AreEqual(((10 * 59.99M) + (10 * 10) + (10 * 50)), TotalPrice);

        }
       
        [TestMethod]

        public void TicketPurchaseTest1()
        {
            //arrange create an instance of the class
            TicketPurchase ticketPurchase = new TicketPurchase("Bob", 10);
            //act call the method that is being tested 
            decimal testObject = ticketPurchase.BasePrice;

            //assert
            Assert.AreEqual((10 * 59.99M), testObject);

        }


        [TestMethod]

        public void TicketPurchaseTest2()
        {
            //arrange create an instance of the class
            TicketPurchase ticketPurchase = new TicketPurchase("Bob", 10);

            //act call the method that is being tested 
            string name = ticketPurchase.Name;
            int numberOfTickets = ticketPurchase.NumberOfTickets;

            //assert
            Assert.AreEqual("Bob", name);
            Assert.AreEqual(10, numberOfTickets);
            

        }

    }
}


        
