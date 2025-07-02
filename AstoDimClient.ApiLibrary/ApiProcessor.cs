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
        public static async Task<(bool success, string status)> ActivateLicense(string licenseKey, string HWID)
        {
            if (!String.IsNullOrEmpty(licenseKey) || !String.IsNullOrEmpty(HWID))
            {
                string url = $"https://localhost:7025/api/licences/activatelicence?productKey={licenseKey}&HWID={HWID}";

                try
                {
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            bool statusResult = JsonConvert.DeserializeObject<bool>(result);
                            return statusResult ? 
                                (true, "Lisans başarıyla aktifleştirildi.") : 
                                (false, "Lisans aktifleştirme başarısız oldu. Lütfen lisans anahtarınızı kontrol ediniz.");
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            return (false, "Maalesef ki lisanslama sunucularına erişilemedi. Lütfen internet bağlantınızı kontrol ediniz.");
                        }
                        else
                        {
                            return (false, "Maalesef ki aktifleştirme işleminde bir sorun çıktı. Lütfen lisans anahtarınızın doğru olduğundan ve süresinin geçmemiş olduğundan emin olunuz.");
                        }
                    }
                }
                catch (Exception)
                {
                    return (false, "Maalesef ki lisanslama sunucularına erişilemedi, lütfen internet bağlantınız olduğundan emin olunuz.");
                }
                
            }   
            return (false, "Lütfen doğru bir lisans anahtarı girdiğinizden emin olunuz.");
        }
        public static async Task<(bool isCorrect, bool isActivated, string message)> CheckLicense(string licenseKey)
        {
            if (!String.IsNullOrEmpty(licenseKey))
            {
                string url = $"https://localhost:7025/api/licences/checklicencewithkey?productKey={licenseKey}";

                try
                {
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        // First tuple bool: isSuccess, Second tuple bool: isActivated 
                        (bool, bool) statusResult = JsonConvert.DeserializeObject<(bool, bool)>(result);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return (false, false, "Lütfen doğru bir lisans anahtarı girdiğinizden emin olunuz.");
        }
    }
}
