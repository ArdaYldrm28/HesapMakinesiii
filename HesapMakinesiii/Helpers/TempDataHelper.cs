using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace HesapMakinesiii.Helpers
  {
    public static class TempDataHelper
    {
        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            if (tempData.TryGetValue(key, out object value))
            {
                return JsonConvert.DeserializeObject<T>((string)value);
            }
            return default(T);
        }

        public static void Set<T>(this ITempDataDictionary tempData, string key, T value)
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }
    }
}

