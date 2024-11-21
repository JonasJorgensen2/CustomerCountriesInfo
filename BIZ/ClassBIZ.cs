using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;
namespace BIZ
{
    public class ClassBIZ : ClassNotify 
    {
        #region Private Fields
        private ClassCallWebAPI CCWA = new ClassCallWebAPI();
        private ClassCustomCountryDataDB CCCDB = new ClassCustomCountryDataDB();
        private ClassCurrency _Currency;
        
        private List<UserControlPersonObject> _StyledCustomerList;
        private List<ClassCountryData> _ListCountry;
        private UserControlPersonObject _SelectedCustomer;
        private ClassCustomer _FallbackCustomer;
        #endregion
        #region Constructor
        public ClassBIZ()
        {
            GetCustomerData();
            GetCountryData();
            Currency = new ClassCurrency();
            FallbackCustomer=new ClassCustomer();
        }
        #endregion
        #region Properties
       

        public UserControlPersonObject SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                if (_SelectedCustomer != value)
                {
                    _SelectedCustomer = value;
                    if (SelectedCustomer != null) {
                        if (SelectedCustomer.Customer.Id>0) {
                            SetValutaPrice();
                        }
                    }
                }
                Notify("SelectedCustomer");
            }
        }


        public List<UserControlPersonObject> StyledCustomerList
        {
            get { return _StyledCustomerList; }
            set
            {
                if (_StyledCustomerList != value)
                {
                    _StyledCustomerList = value;
                }
                Notify("StyledCustomerList");
            }
        }


        public ClassCustomer FallbackCustomer
        {
            get { return _FallbackCustomer; }
            set
            {
                if (_FallbackCustomer != value)
                {
                    _FallbackCustomer = value;
                }
                Notify("FallbackCustomer");
            }
        }


        


        public List<ClassCountryData> ListCountry
        {
            get { return _ListCountry; }
            set
            {
                if (_ListCountry != value)
                {
                    _ListCountry = value;
                }
                Notify("ListCountry");
            }
        }

       


        public ClassCurrency Currency
        {
            get { return _Currency; }
            set
            {
                if (_Currency != value)
                {
                    _Currency = value;
                }
                Notify("Currency");
            }
        }

        #endregion
        #region Methods
        /// <summary>
        /// Simpelt metode til at initialiser og tilføje data fra database til listcustomer
        /// </summary>
        public void GetCustomerData()
        {
            List<UserControlPersonObject> tempList = new List<UserControlPersonObject>();
            foreach (ClassCustomer customer in CCCDB.GetAllCustomersFromDB())
            {
                UserControlPersonObject temp = new UserControlPersonObject(customer);
                tempList.Add(temp);
            }
            StyledCustomerList = tempList;
        }
        /// <summary>
        /// Simpelt metode til at initialiser og tilføje data fra database til ListCountry
        /// </summary>
        public void GetCountryData()
        {
            ListCountry = new List<ClassCountryData>(CCCDB.GetAllCountriesFromDB());
        }
        /// <summary>
        /// Async metode til at kunne starte op og sætte Valuta kurser API op på MainNWindow.xaml.cs med async
        /// </summary>
        public async Task StartCurrencyApiCallAsync()
        {
            Currency = new ClassCurrency(await CCWA.GetURLContentsAsync());
        }
        /// <summary>
        /// Sætter valuta pricer med kurserne fra dictionarien fra Currency.Rates
        /// </summary>
        private void SetValutaPrice()
        {
            SelectedCustomer.Customer.country.PriceUSD = (Currency.rates[SelectedCustomer.Customer.country.CurrencyCode] * 100).ToString("0.##");
            SelectedCustomer.Customer.country.PriceEUR = ((Currency.rates[SelectedCustomer.Customer.country.CurrencyCode] / Currency.rates["EUR"]) * 100).ToString("0.##");
            SelectedCustomer.Customer.country.PriceDKK = ((Currency.rates[SelectedCustomer.Customer.country.CurrencyCode] / Currency.rates["DKK"]) * 100).ToString("0.##");
           
        }
        /// <summary>
        /// En metoder som gør når der er sket en ændring/tilføjelse, så skal den bevirkede række være selected i list view
        /// </summary>
        /// <param name="inId"></param>
        private void SelectCustomerInListView(int inId)
        {
            foreach(UserControlPersonObject cc in StyledCustomerList)
            {
                if(cc.Customer.Id == inId)
                {
                    SelectedCustomer = cc;
                    break;
                }
            }
        }
        /// <summary>
        /// En metode som kan tilføjer eller ændre kunder i databasen. Og ryder den gamle liste
        /// </summary>
        public void InsertOrUpdateCustomerinDB()
        {

            if (FallbackCustomer.Id == 0)
            {
                int temp = CCCDB.InsertNewCustomerInDB(FallbackCustomer);
                StyledCustomerList.Clear();
                GetCustomerData();
                SelectCustomerInListView(temp);
            }
            else
            {
                int temp = CCCDB.UpdateCustomerInDB(FallbackCustomer);
                StyledCustomerList.Clear();
                GetCustomerData();
                SelectCustomerInListView(temp);
            }
            
        }
        #endregion
    }
}
