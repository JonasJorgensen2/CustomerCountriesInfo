using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repository;
namespace IO
{
    /// <summary>
    /// Skaber forbindelsen til en Web API, sender en forespørgelse,
    ///serialisere svaret via Newtonsoft.Jason til ClassCurrency
    ///som den så returnere.
    /// </summary>
    public class ClassCallWebAPI
    {
        public ClassCallWebAPI()
        {
            
        }
        /// <summary>
        /// Skaber forbindelsen til en Web API, sender en forespørgelse,
        ///serialisere svaret via Newtonsoft.Jason til ClassCurrency
        ///som den så returnere.
        /// </summary>
        /// <returns>ClassCurency</returns>
        public async Task<ClassCurrency> GetURLContentsAsync()
        {
            ClassCurrency CC = new ClassCurrency();

            MemoryStream content = new MemoryStream();
            var webReq = (HttpWebRequest)WebRequest.Create(@"https://openexchangerates.org/api/latest.json?app_id=0665765b4c624803b2cd09c5396d8b09");
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }
            string strRes = Encoding.UTF8.GetString(content.ToArray());

            CC =  JsonConvert.DeserializeObject<ClassCurrency>(strRes);

            return CC;
        }
    }
}
