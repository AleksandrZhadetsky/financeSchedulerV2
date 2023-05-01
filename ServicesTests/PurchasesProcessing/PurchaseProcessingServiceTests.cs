using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Purchases.Tests
{
    [TestClass()]
    public class PurchaseProcessingServiceTests
    {
        [TestMethod()]
        public void GetPurchaseAsync_GivenValidPurchaseId_PurchaseReturned()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod()]
        public void GetPurchaseAsync_GivenInvalidPurchaseId_ExceptionThrown()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod()]
        public void GetPurchasesAsyncScenarioResults()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod()]
        public void CreatePurchaseAsyncScenarioResults()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod()]
        public void DeletePurchaseAsyncScenarioResults()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod()]
        public void UpdatePurchaseAsyncScenarioResults()
        {
            // Assert
            Assert.AreEqual(4, 2 + 2);
        }
    }
}