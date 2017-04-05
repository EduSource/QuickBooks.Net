using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace QuickBooks.Net.Utilities
{
    public class XmlHelper
    {
        public static Dictionary<string, string> ParseXmlString(string data)
        {
            var doc = XDocument.Parse(data);
            var dataDictionary = new Dictionary<string, string>();

            foreach (var element in doc.Descendants().Where(p => p.HasElements == false)) {
                var keyInt = 0;
                var keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName)) {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
            }

            return dataDictionary;
        }
    }
}