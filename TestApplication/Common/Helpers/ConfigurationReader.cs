using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ConfigurationReader
    {
        public static T ReadAppConfig<T>(string key, T defaultValue, string seperator = "", string keySuffix = "") where T : Type
        {
            string finalKey = key;
            if (!string.IsNullOrWhiteSpace(seperator) && !string.IsNullOrWhiteSpace(keySuffix))
            {
                finalKey += seperator + keySuffix;
            }

            return ConfigurationManager.AppSettings[finalKey] != null ? ConfigurationManager.AppSettings[finalKey] as T : defaultValue;
        }
    }
}
