using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo.DAL;
using PetInfo.Models;
using System.Collections.Generic;
using PetInfo.DAL.Interfaces;

namespace PetsTest
{
    [TestClass]
    public class PetsSqlTest
    {
        IPetDao dao;

        [TestInitialize]
        public void Setup()
        {


            dao = new PetSqlDao();
        }


        [TestMethod]
        public void GetAPetTest()
        {
            PetSqlDao dao = new PetSqlDao();
            Pet pet = dao.GetPet(1);
            Assert.IsNotNull(pet);
        }
    }
}
