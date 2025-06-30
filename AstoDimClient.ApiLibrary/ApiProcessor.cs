using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoDimClient.ApiLibrary
{
    public class ApiProcessor
    {
        public static async Task<bool> ActivateLicense(string licenseKey, string HWID)
        {
            if (!String.IsNullOrEmpty(licenseKey) || !String.IsNullOrEmpty(HWID))
            {
                string url = $"https://localhost:7025/api/licences/activatelicence?productKey={licenseKey}&HWID={HWID}";

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                    else
                    {
                        return false;
                    }
                }
            }   
            return false;
        }
    }
}
