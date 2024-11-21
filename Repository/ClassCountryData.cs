using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// ClassCountryData holder alle data der knytter
    ///til de 248 lande som findes i databasen.
    ///Den holder ligeledes den aktuellse kur for 
	///valutaerne USD, EUR og DKK, samt URL til at
	///hente et flag og til at hente et kort over
	///det aktuelle land.
	///De tre kurser baseres på kurserne
	///fra ClassCurrency.
	/// </summary>
    public class ClassCountryData : ClassNotify
    {
        #region Private Fields
        private int _Id;
        private string _CountryCode2;
        private string _CountryName;
        private string _CountryCode3;
        private string _CountryNumeric;
        private string _Capital;
        private string _CountryDemonym;
        private string _CountryArea;
        private string _CountryPopulation;
        private string _IddCode;
        private string _CurrencyCode;
        private string _CurrencyName;
        private string _LanguageCode;
        private string _LanguageName;
        private string _PriceUSD;
        private string _PriceEUR;
        private string _PriceDKK;
        private string _flagURL;
        private string _mapURL;
        private string _secondFlagUrl;
        #endregion
        #region Constructors
        public ClassCountryData()
        {
            Id = 0;
			CountryCode2 = "";
			CountryName = "";
			CountryCode3 = "";
			CountryNumeric = "";
			Capital= "";
			CountryDemonym = "";
			CountryArea = "";
			CountryPopulation = "";
			IddCode = "";
			CurrencyCode = "";
			CurrencyName = "";
			LanguageCode = "";
			LanguageName = "";
			PriceUSD = "";
			PriceEUR = "";
			PriceDKK = "";
			flagURL = "";
			mapURL = "";
			secondFlagUrl = "";
        }
        public ClassCountryData(ClassCountryData inCountry)
        {
            Id = inCountry.Id;
			CountryCode2 = inCountry.CountryCode2;
			CountryName = inCountry.CountryName;
			CountryCode3 = inCountry.CountryCode3;
			CountryNumeric = inCountry.CountryNumeric;
			Capital = inCountry.Capital;
			CountryDemonym = inCountry.CountryDemonym;
			CountryArea = inCountry.CountryArea;
			CountryPopulation = inCountry.CountryPopulation;
			IddCode = inCountry.IddCode;
			CurrencyCode = inCountry.CurrencyCode;
			CurrencyName = inCountry.CurrencyName;
			LanguageCode = inCountry.LanguageCode;
			LanguageName = inCountry.LanguageName;
			PriceUSD = inCountry.PriceUSD;
			PriceEUR = inCountry.PriceEUR;
			PriceDKK = inCountry.PriceDKK;
			flagURL = inCountry.flagURL;
			mapURL = inCountry.mapURL;
			secondFlagUrl = inCountry.secondFlagUrl;
        }
        public ClassCountryData(int inId, string inName)
        {
            Id = inId;
			CountryCode2 = "";
			CountryName = inName;
            CountryCode3 = "";
            CountryNumeric = "";
            Capital= "";
            CountryDemonym = "";
            CountryArea = "";
            CountryPopulation = "";
            IddCode = "";
            CurrencyCode = "";
            CurrencyName = "";
            LanguageCode = "";
            LanguageName = "";
            PriceUSD = "";
            PriceEUR = "";
            PriceDKK = "";
            flagURL = "";
            mapURL = "";
        }
		#endregion
		#region Properties

		

		public string secondFlagUrl
		{
			get { return _secondFlagUrl; }
			set
			{
				if (_secondFlagUrl != value)
				{
					_secondFlagUrl = value;
				}
				Notify("secondFlagUrl");
			}
		}

		public string mapURL
		{
			get { return _mapURL; }
			set
			{
				if (_mapURL != value)
				{
					_mapURL = value;
				}
				Notify("mapURL");
			}
		}


		public string flagURL
		{
			get { return _flagURL; }
			set
			{
				if (_flagURL != value)
				{
					_flagURL = value;
				}
				Notify("flagURL");
			}
		}


		public string PriceDKK
		{
			get { return _PriceDKK; }
			set
			{
				if (_PriceDKK != value)
				{
					_PriceDKK = value;
				}
				Notify("PriceDKK");
			}
		}


		public string PriceEUR
		{
			get { return _PriceEUR; }
			set
			{
				if (_PriceEUR != value)
				{
					_PriceEUR = value;
				}
				Notify("PriceEUR");
			}
		}


		public string PriceUSD
		{
			get { return _PriceUSD; }
			set
			{
				if (_PriceUSD != value)
				{
					_PriceUSD = value;
				}
				Notify("PriceUSD");
			}
		}


		public string LanguageName
		{
			get { return _LanguageName; }
			set
			{
				if (_LanguageName != value)
				{
					_LanguageName = value;
				}
				Notify("LanguageName");
			}
		}


		public string LanguageCode
		{
			get { return _LanguageCode; }
			set
			{
				if (_LanguageCode != value)
				{
					_LanguageCode = value;
				}
				Notify("LanguageCode");
			}
		}


		public string CurrencyName
		{
			get { return _CurrencyName; }
			set
			{
				if (_CurrencyName != value)
				{
					_CurrencyName = value;
				}
				Notify("CurrencyName");
			}
		}


		public string CurrencyCode
		{
			get { return _CurrencyCode; }
			set
			{
				if (_CurrencyCode != value)
				{
					_CurrencyCode = value;
				}
				Notify("CurrencyCode");
			}
		}


		public string IddCode
		{
			get { return _IddCode; }
			set
			{
				if (_IddCode != value)
				{
					_IddCode = value;
				}
				Notify("IddCode");
			}
		}


		public string CountryPopulation
		{
			get { return _CountryPopulation; }
			set
			{
				if (_CountryPopulation != value)
				{
					_CountryPopulation = value;
				}
				Notify("CountryPopulation");
			}
		}


		public string CountryArea
		{
			get { return _CountryArea; }
			set
			{
				if (_CountryArea != value)
				{
					_CountryArea = value;
				}
				Notify("CountryArea");
			}
		}


		public string CountryDemonym
		{
			get { return _CountryDemonym; }
			set
			{
				if (_CountryDemonym != value)
				{
					_CountryDemonym = value;
				}
				Notify("CountryDemonym");
			}
		}


		public string Capital
		{
			get { return _Capital; }
			set
			{
				if (_Capital != value)
				{
					_Capital = value;
				}
				Notify("Capital");
			}
		}


		public string CountryNumeric
		{
			get { return _CountryNumeric; }
			set
			{
				if (_CountryNumeric != value)
				{
					_CountryNumeric = value;
				}
				Notify("CountryNumeric");
			}
		}


		public string CountryCode3
		{
			get { return _CountryCode3; }
			set
			{
				if (_CountryCode3 != value)
				{
					_CountryCode3 = value;
				}
				Notify("CountryCode3");
			}
		}


		public string CountryName
		{
			get { return _CountryName; }
			set
			{
				if (_CountryName != value)
				{
					_CountryName = value;
				}
				Notify("CountryName");
			}
		}


		public string CountryCode2
		{
			get { return _CountryCode2; }
			set
			{
				if (_CountryCode2 != value)
				{
					_CountryCode2 = value;
				}
				Notify("CountryCode2");
			}
		}


		public int Id
		{
			get { return _Id; }
			set
			{
				if (_Id != value)
				{
					_Id = value;
				}
				Notify("Id");
			}
		}
        #endregion

    }
}
