using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class skal holde svaret fra kaldet til
	///	openexchangerates.org Web API.
	/// </summary>
    public class ClassCurrency : ClassNotify
    {
        #region Private Fields
        private string _disclaimer;
        private string _license;
        private long _timestamp;
        private string _Base;
        private Dictionary<string, double> _rates;
        #endregion
        #region Constructors
        public ClassCurrency()
        {
			disclaimer = "";
			license = "";
			timestamp = 0L;
			Base = "";
			rates = new Dictionary<string, double>();
        }
        public ClassCurrency(ClassCurrency inCurrency)
        {
			disclaimer = inCurrency.disclaimer;
			license = inCurrency.license;
			timestamp = inCurrency.timestamp;
			Base = inCurrency.Base;
			rates = new Dictionary<string, double>(inCurrency.rates);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Rates er et Dictionary der holder alle nøgler 
        ///og kurser i forhold til USD.
        /// </summary>

        public Dictionary<string,double> rates
		{
			get { return _rates; }
			set
			{
				if (_rates != value)
				{
					_rates = value;
				}
				Notify("rates");
			}
		}

		[JsonProperty("base")]
		public string Base
		{
			get { return _Base; }
			set
			{
				if (_Base != value)
				{
					_Base = value;
				}
				Notify("Base");
			}
		}


		public long timestamp
		{
			get { return _timestamp; }
			set
			{
				if (_timestamp != value)
				{
					_timestamp = value;
				}
				Notify("timestamp");
			}
		}


		public string license
		{
			get { return _license; }
			set
			{
				if (_license != value)
				{
					_license = value;
				}
				Notify("license");
			}
		}


		public string disclaimer
		{
			get { return _disclaimer; }
			set
			{
				if (_disclaimer != value)
				{
					_disclaimer = value;
				}
				Notify("disclaimer");
			}
		}
        #endregion

    }
}
