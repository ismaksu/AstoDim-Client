using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoDimClient.ApiLibrary
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();
    }
}
