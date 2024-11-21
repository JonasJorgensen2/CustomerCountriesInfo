using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Data;
using System.Data.SqlClient;
namespace IO
{
    /// <summary>
    /// Denne class skal holde de metoder der skal generere 
    /// de SqlCommand der skal benyttes til at kommunikere
    /// med databasen.
    /// </summary>
    public class ClassCustomCountryDataDB : ClassDbCon
    {
        private static string sqlConStr = @"Server=(localdb)\MSSQLLocalDB;Database=CustomerCountryData;Trusted_Connection=True;";
        public ClassCustomCountryDataDB() : base(sqlConStr)
        {
            
        }
        #region Recieving Data from Database
        /// <summary>
        /// En metode til at returnere customer data fra databasen til en list i ClassBIZ as ClassCustomer
        /// </summary>
        /// <returns>List(ClassCustomer)</returns>
        public List<ClassCustomer> GetAllCustomersFromDB()
        {
            List<ClassCustomer> tempList = new List<ClassCustomer>();
            string sqlQuery = "SELECT Customers.Id, Customers.name, Customers.address, Customers.city, Customers.postalCode, " +
            "CountryData.Id AS CountryId, CountryData.CountryCode2, CountryData.CountryName, CountryData.CountryCode3, CountryData.CountryNumeric, CountryData.Capital, " +
            "CountryData.CountryDemonym, CountryData.CountryArea, CountryData.CountryPopulation, CountryData.IddCode, CountryData.CurrencyCode, CountryData.CurrencyName," +
            "CountryData.LanguageCode, CountryData.LanguageName, Customers.phone, Customers.mailAdr " +
            "FROM Customers LEFT OUTER JOIN CountryData ON Customers.country = CountryData.Id";
            using (DataTable dt = DBReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dt.Rows)
                {
                    ClassCustomer cc = new ClassCustomer();
                    cc.Id = Convert.ToInt32(row["Id"]);
                    cc.name = row["name"].ToString();
                    cc.address = row["address"].ToString();
                    cc.city = row["city"].ToString();
                    cc.postalCode = row["postalCode"].ToString();
                    cc.country.Id = Convert.ToInt32(row["CountryId"]);
                    cc.country.CountryCode2 = row["CountryCode2"].ToString();
                    cc.country.CountryName = row["CountryName"].ToString();
                    cc.country.CountryCode3 = row["CountryCode3"].ToString();
                    cc.country.CountryNumeric= row["CountryNumeric"].ToString();
                    cc.country.Capital = row["Capital"].ToString();
                    cc.country.CountryDemonym = row["CountryDemonym"].ToString();
                    cc.country.CountryArea = row["CountryArea"].ToString();
                    cc.country.CountryPopulation = row["CountryPopulation"].ToString();
                    cc.country.IddCode = row["IddCode"].ToString();
                    cc.country.CurrencyCode = row["CurrencyCode"].ToString();
                    cc.country.CurrencyName = row["CurrencyName"].ToString();
                    cc.country.LanguageCode = row["LanguageCode"].ToString();
                    cc.country.LanguageName = row["LanguageName"].ToString();
                    cc.country.flagURL = $"https://flagcdn.com/96x72/{row["CountryCode2"].ToString().ToLower()}.png";
                    cc.country.mapURL = $"https://geology.com/world/{row["CountryName"].ToString().Replace(" ", "-").ToLower()}-map.gif";
                    cc.country.secondFlagUrl= $"https://www.verdensflag.dk/data/flags/w702/{row["CountryCode2"].ToString().ToLower()}.png";
                    cc.phone= row["phone"].ToString();
                    cc.mailAdr = row["mailAdr"].ToString();
                    tempList.Add(cc);
                }
            }
            return tempList;
        }
        /// <summary>
        /// En metode til at returnere land information fra databasen til comboboxen i UserControlEditCustomer.xaml.cs
        /// </summary>
        /// <returns>List(ClassCountryData)</returns>
        public List<ClassCountryData> GetAllCountriesFromDB()
        {
            List<ClassCountryData> tempList= new List<ClassCountryData>();
            string sqlQuery = "SELECT Id, CountryName FROM CountryData";
            using(DataTable dt = DBReturnDataTable(sqlQuery))
            {
                foreach (DataRow row in dt.Rows)
                {
                    ClassCountryData cdc = new ClassCountryData();
                    cdc.Id = Convert.ToInt32(row["Id"]);
                    cdc.CountryName = row["CountryName"].ToString();
                    tempList.Add(cdc);
                }
            }
            return tempList;
        }
        #endregion
        #region Modifying/Adding data to Database
        /// <summary>
        /// En metode som tilføjer en ny kunde til database, og returner en int, som er kundens nye ID i databasen
        /// </summary>
        /// <param name="inCustomer"></param>
        /// <returns>int --> Identification number of the row added</returns>
        public int InsertNewCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;
            string sqlQuery = "INSERT INTO Customers (name, address, city, postalCode, country, phone, mailAdr) " +
                "VALUES (@name, @address, @city, @postalCode, @country, @phone, @mailAdr) " +
                "SELECT SCOPE_IDENTITY()";

            try
            {
                using(SqlCommand cmd = new SqlCommand(sqlQuery, _con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value=inCustomer.address;
                    cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value=inCustomer.city;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value=inCustomer.postalCode;
                    cmd.Parameters.Add("@country", SqlDbType.Int).Value=inCustomer.country.Id;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                    cmd.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = inCustomer.mailAdr;
                    OpenDB();
                    res= Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(SqlException ex) 
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }
        /// <summary>
        /// Opdatere den række som brugeren vil ændre på i databasen, fra det hvad brugeren har indtasted
        /// </summary>
        /// <param name="inCustomer"></param>
        /// <returns>int --> ID of the row affected </returns>
        public int UpdateCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;
            string sqlQuery = "UPDATE Customers " +
                "SET name = @name, " +
                "address = @address, "+
                "city = @city, "+
                "postalCode = @postalCode, "+
                "country = @country, " +
                "phone = @phone, " +
                "mailAdr = @mailAdr "+
                "WHERE Id = @Id";
            try
            {
                using(SqlCommand cmd = new SqlCommand(sqlQuery, _con)) 
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value=inCustomer.address;
                    cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value=inCustomer.city;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value=inCustomer.postalCode;
                    cmd.Parameters.Add("@country", SqlDbType.Int).Value=inCustomer.country.Id;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                    cmd.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = inCustomer.mailAdr;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = inCustomer.Id;
                    OpenDB();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        res = inCustomer.Id;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }
        #endregion
    }
}
