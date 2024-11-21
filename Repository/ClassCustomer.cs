using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class skal holde de data der knytter
    /// sig til en kunde.
	/// </summary>
    public class ClassCustomer : ClassNotify
    {
        #region Private Fields
        private int _Id;
        private string _address;
        private string _city;
        private string _mailAdr;
        private string _name;
        private string _phone;
        private string _postalCode;
        private ClassCountryData _country;
        #endregion
        #region Constructors
        public ClassCustomer()
        {
			Id = 0;
			address = "";
			city = "";
			mailAdr = "";
			name = "";
			phone = "";
			postalCode = "";
			country = new ClassCountryData();
        }
        public ClassCustomer(ClassCustomer inCustomer)
        {
            Id = inCustomer.Id;
			address = inCustomer.address;
			city = inCustomer.city;
			mailAdr = inCustomer.mailAdr;
			name = inCustomer.name;
			phone = inCustomer.phone;
			postalCode = inCustomer.postalCode;
			country = new ClassCountryData(inCustomer.country);
        }
		#endregion
		#region Properties
		

		public ClassCountryData country
		{
			get { return _country; }
			set
			{
				if (_country != value)
				{
					_country = value;
				}
				Notify("country");
			}
		}

		public string postalCode
		{
			get { return _postalCode; }
			set
			{
				if (_postalCode != value)
				{
					_postalCode = value;
				}
				Notify("postalCode");
			}
		}

		public string phone
		{
			get { return _phone; }
			set
			{
				if (_phone != value)
				{
					_phone = value;
				}
				Notify("phone");
			}
		}


		public string name
		{
			get { return _name; }
			set
			{
				if (_name != value)
				{
					_name = value;
				}
				Notify("name");
			}
		}


		public string mailAdr
		{
			get { return _mailAdr; }
			set
			{
				if (_mailAdr != value)
				{
					_mailAdr = value;
				}
				Notify("mailAdr");
			}
		}


		public string city
		{
			get { return _city; }
			set
			{
				if (_city != value)
				{
					_city = value;
				}
				Notify("city");
			}
		}


		public string address
		{
			get { return _address; }
			set
			{
				if (_address != value)
				{
					_address = value;
				}
				Notify("address");
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
