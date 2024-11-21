using BIZ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class TestIfCustomerNativeToNativeIsEqual
    {
        ClassBIZ BIZ = new ClassBIZ();
        private async void ApiCall()
        {
            await BIZ.StartCurrencyApiCallAsync();
        }
        [TestMethod]
        public void CheckIfUSDToUSDisCorrect()
        {
            ApiCall();
            Thread.Sleep(5000);
            
            BIZ.SelectedCustomer.Customer=new Repository.ClassCustomer()
            {
                Id = 1,
                country= new Repository.ClassCountryData()
                {
                    CurrencyCode="USD"
                }
            };

            Assert.AreEqual("100", BIZ.SelectedCustomer.Customer.country.PriceUSD);
        }
        [TestMethod]
        public void CheckIfEURtoEURisCorrect()
        {
            ApiCall();
            Thread.Sleep(5000);

            BIZ.SelectedCustomer.Customer=new Repository.ClassCustomer()
            {
                Id = 1,
                country= new Repository.ClassCountryData()
                {
                    CurrencyCode="EUR"
                }
            };

            Assert.AreEqual("100", BIZ.SelectedCustomer.Customer.country.PriceEUR);
        }
        [TestMethod]
        public void CheckIfDKKtoDKKisCorrect()
        {
            ApiCall();
            Thread.Sleep(5000);

            BIZ.SelectedCustomer.Customer=new Repository.ClassCustomer()
            {
                Id = 1,
                country= new Repository.ClassCountryData()
                {
                    CurrencyCode="DKK"
                }
            };

            Assert.AreEqual("100", BIZ.SelectedCustomer.Customer.country.PriceDKK);
        }
    }
}
