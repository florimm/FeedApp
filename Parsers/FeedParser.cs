using System;
using System.Collections.Generic;
using System.Xml.Linq;
using FeedApp.Models;

namespace FeedApp.Parsers
{
    public class FeedParser
    {
        public static FeedSource ParseSource(XDocument doc)
        {
            return null;
        }
        public static List<NewsItem> Parse(int feedSourceId, XDocument doc)
        {
            try
            {
                IFeedParser parser = null;

                XElement element = doc.Element("rss");
                if (element != null) parser = new RssFeedBuilder(doc);

                XNamespace rdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
                element = doc.Element(rdf + "RDF");
                if (element != null) parser = new RdfFeedParser(doc);

                XNamespace atom = "http://www.w3.org/2005/Atom";
                element = doc.Element(atom + "feed");
                if (element != null) parser = new AtomFeedParser(doc);
                
                return parser.Create(feedSourceId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}