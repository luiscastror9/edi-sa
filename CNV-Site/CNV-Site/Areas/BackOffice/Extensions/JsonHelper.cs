using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;

namespace CNV_Site.Areas.BackOffice.Extensions
{
    public class JsonHelper
    {
        public static object Tabulate(string json)
        {
            string final = string.Empty;
            string name =(json);
            char[] arr = name.ToArray();

            bool bln = true;
            foreach (char item in arr)
            {
                if (bln)
                {
                    if (item == '}')
                    {
                        final += item.ToString();
                        break;
                    }
                    else
                    {
                        final += item.ToString();
                    }
                }
            }

            var jsonLinq = JObject.Parse(final);

            // Find the first array using Linq
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<object>(trgArray.ToString());
        }
    }
}