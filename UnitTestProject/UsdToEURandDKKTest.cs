using BIZ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Timers;

namespace UnitTestProject
{
    [TestClass]
    public class UsdToEURandDKKTest
    {
        ClassBIZ BIZ = new ClassBIZ();
        private async void ApiCall()
        {
            await BIZ.StartCurrencyApiCallAsync();
        }
        [TestMethod]
        public void UsdInDKK()
        {
            //Assign
            ApiCall();
            Thread.Sleep(5000);

            //Act
            double dkkValueFromUSD = BIZ.Currency.rates["DKK"];
           
            //Assert

            
            Assert.AreEqual(6.823382, dkkValueFromUSD);

        }
        [TestMethod]
        public void UsdInEUR()
        {
            ApiCall();
            Thread.Sleep(5000);

            double EURValueFromUSD = BIZ.Currency.rates["EUR"];

            Assert.AreEqual(0.915168, EURValueFromUSD);
        }
        
    }
}
