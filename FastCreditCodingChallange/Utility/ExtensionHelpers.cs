using MimeTypes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FastCreditCodingChallange.Utility
{
    public static class ExtensionHelpers
    {
        public static string ToDescription(this Object value)
        {
            FieldInfo p1 = value.GetType().GetField(value.ToString());

           var attributes = (DescriptionAttribute[])p1.GetCustomAttributes(typeof(DescriptionAttribute), false);
                
           return attributes.Length > 0 ? attributes[0].Description : value.ToString();

        }
        public static T? Deserialize<T>(this string jsonstring) where T : new()
        {
            return !string.IsNullOrWhiteSpace(jsonstring) ? JsonConvert.DeserializeObject<T>(jsonstring) : new T();
        }
        public static string Serialize(this string value)
        {
            return value != null ? JsonConvert.SerializeObject(value) : string.Empty;
        }

        public static string GetExtension(this string base64FileString)
        {
            if (string.IsNullOrWhiteSpace(base64FileString))
                return string.Empty;

            string[] stringComponents = base64FileString.Remove(0, 5).Split(';');
            return MimeTypeMap.GetExtension(stringComponents[0]);
        }

        public static string GetBase64String(this string base64FileString)
        {
            if (string.IsNullOrWhiteSpace(base64FileString))
                return string.Empty;

            string[] stringComponents = base64FileString.Remove(0, 5).Split(';');
            return stringComponents[0].Replace("base64,", "");
        }

        public static bool IsValidBase64String(this string base64FileString)
        {
            if (string.IsNullOrWhiteSpace(base64FileString))
                return false;

            string pattern = "^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{4})$";
            return Regex.IsMatch(base64FileString, pattern);
        }
    }
}
