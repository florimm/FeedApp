using System.Net;
using System.Xml.Linq;

public static class StringExtensions
{
    public static XDocument LoadUrlAndParseAsXml(this string url)
    {
        string content;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		using (WebClient client = new WebClient())
		{
			content = client.DownloadString(url);
		}
        return XDocument.Parse(content);
    }
}