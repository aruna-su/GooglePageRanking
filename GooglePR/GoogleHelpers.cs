using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleHelper
{
    public class GoogleHelpers
    {
        public static string GetPosition(Uri url, string searchLinkText)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string html = reader.ReadToEnd();
                        return FindUrlPosition(html, searchLinkText);
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
         } 

        private static string FindUrlPosition(string html, string searchLinkText)
        {
            string lookup = "(?s)class=\"kCrYT\"><a [^>]*?>(?<text>.*?)</a>";
            MatchCollection matches = Regex.Matches(html,lookup);
            string result = string.Empty;
            for (int i = 0; i<matches.Count;i++)
            {
                string match = matches[i].Groups[0].Value;

                if (match.Contains(searchLinkText))
                {
                    result = result + string.Format("{0}, ", i + 1);
                 }
            }
            return string.IsNullOrEmpty(result) ? "0" : result.Substring(0, result.Length - 2);
         }
    }
}
