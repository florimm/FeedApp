using FeedApp.Models;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace FeedApp.Utils
{
    public class FeedLoader
    {
        public static XDocument LoadUrlAndParseAsXml(string url, EncodingType encodingType)
        {
            try
            {
                string content;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (WebClient client = new WebClient())
                {
                    client.Encoding = encodingType == EncodingType.UTF8 ? Encoding.UTF8 : Encoding.GetEncoding("Windows-1252");
                    content = client.DownloadString(url);
                }
                var xdoc = XDocument.Parse(content);
                return xdoc;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
