using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade;

namespace LemonadeTests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void TestPlayerLemonsAdded()
        {
            //Arrange
            int expectedResult = 10;
            //Have to refactor AddLemons(). Replace moreLemons in for statement with 10
            int actualResult;

            //Act
            Store store = new Store();
            Player player = new Player();
            store.AddLemons(player);
            actualResult = player.inventory.lemons.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestPlayerSugarAdded()
        {
            //Arrange
            int expectedResult = 10;
            //Have to refactor AddSugar(). Replace moreSugar in for statement with 10
            int actualResult;

            //Act
            Store store = new Store();
            Player player = new Player();
            store.AddSugar(player);
            actualResult = player.inventory.sugarCubes.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestPlayerIceAdded()
        {
            //Arrange
            int expectedResult = 10;
            //Have to refactor AddIce(). Replace moreIce in for statement with 10
            int actualResult;

            //Act
            Store store = new Store();
            Player player = new Player();
            store.AddIce(player);
            actualResult = player.inventory.iceCubes.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestPlayerCupsAdded()
        {
            //Arrange
            int expectedResult = 10;
            //Have to refactor AddCups(). Replace moreCups in for statement with 10
            int actualResult;

            //Act
            Store store = new Store();
            Player player = new Player();
            store.AddCups(player);
            actualResult = player.inventory.cups.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
