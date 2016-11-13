using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using DAL;

namespace RepositoryTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Load_Test()
        {
            using(ShimsContext.Create())
            {
                //Arrange
                System.IO.Fakes.ShimFile.ReadAllLinesString = s => new string[] { "aaa" , "bbb", "ccc"};
                //Act
                var target = new Repository("fakes.hex");
                //Assert
                Assert.AreEqual(3, target.Load("fakes.hex").Length);
            }
        }
    }
}
