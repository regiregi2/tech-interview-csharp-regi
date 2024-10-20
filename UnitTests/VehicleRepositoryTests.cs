using Models;
using Vehicles.Api.Repositories;

namespace UnitTests
{
    //followed https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022


    [TestClass]
    public class VehicleRepositoryTests
    {
        [TestMethod]
        public void GetAllFromTestFileCount()
        {
            // Arrange
            int expectedCount = 780;
            VehiclesRepository vehicleRepository = new VehiclesRepository();

            // Act
            IEnumerable<Vehicle> vehicles = vehicleRepository.GetAll().Result;

            // Assert
            int vehicelCount = vehicles.Count();
            Assert.AreEqual(expectedCount, vehicelCount, "GetAll didn't get expected number of cars");
        }

        [TestMethod]
        public void GetCarsByPriceCount()
        {
            // Arrange
            int expectedCount = 388;
            int minPrice = 10000;
            int maxPrice = 50000;
            VehiclesRepository vehicleRepository = new VehiclesRepository();

            // Act
            RepositoryResponse<IEnumerable<Vehicle>> vehicles = vehicleRepository.GetCarsByPrice(minPrice, maxPrice);

            // Assert
            int vehicelCount = vehicles.Result.Count();
            Assert.AreEqual(expectedCount, vehicelCount, "GetCarsByPrice didn't get expected number of cars");
        }

        [TestMethod]
        public void GetCarsByPriceMinHigherThanMax()
        {
            // Arrange
            string errorMessage = "Max Price Greater Than Minimum Price";
            int minPrice = 1000;
            int maxPrice = 100;
            VehiclesRepository vehicleRepository = new VehiclesRepository();

            // Act
            RepositoryResponse<IEnumerable<Vehicle>> vehicles = vehicleRepository.GetCarsByPrice(minPrice, maxPrice);

            // Assert
            string message = vehicles.Message;
            Assert.AreEqual(errorMessage, message, "Error should occur as min price higher than max price");
        }
    }
}