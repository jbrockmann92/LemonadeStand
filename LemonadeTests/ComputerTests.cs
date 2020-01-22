using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade;

namespace LemonadeTests
{
    [TestClass]
    public class ComputerTests
    {
        [TestMethod]
        public void TestifLemonsEqualTen()
        {
            //Arrange
            double expectedResult = 10;
            double actualResult;

            //Act
            Computer computer = new Computer();
            computer.AddInventory();
            actualResult = computer.inventory.lemons.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestifSugarCubesEqualTen()
        {
            //Arrange
            double expectedResult = 10;
            double actualResult;

            //Act
            Computer computer = new Computer();
            computer.AddInventory();
            actualResult = computer.inventory.sugarCubes.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestifIceCubesEqualTen()
        {
            //Arrange
            double expectedResult = 10;
            double actualResult;

            //Act
            Computer computer = new Computer();
            computer.AddInventory();
            actualResult = computer.inventory.iceCubes.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestIfCupsEqualTen()
        {
            //Arrange
            double expectedResult = 10;
            double actualResult;

            //Act
            Computer computer = new Computer();
            computer.AddInventory();
            actualResult = computer.inventory.cups.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRecipeLemons()
        {
            double expectedResult = 1;
            double actualResult;

            Computer computer = new Computer();
            computer.MakeRecipe();
            actualResult = computer.recipe.amountOfLemons;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestRecipeSugar()
        {
            double expectedResult = 1;
            double actualResult;

            Computer computer = new Computer();
            computer.MakeRecipe();
            actualResult = computer.recipe.amountOfSugarCubes;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestRecipeIce()
        {
            double expectedResult = 1;
            double actualResult;

            Computer computer = new Computer();
            computer.MakeRecipe();
            actualResult = computer.recipe.amountOfIceCubes;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestRecipePrice()
        {
            double expectedResult = 1;
            double actualResult;

            Computer computer = new Computer();
            computer.MakeRecipe();
            actualResult = computer.recipe.pricePerCup;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
