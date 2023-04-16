using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace apiUploadXLS.Util
{
    public static class ConvertToJson
    {
       
        public static StringContent Tojson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        }
    }
}
