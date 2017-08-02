using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FeedApp.Models;

namespace FeedApp.Parsers
{
	public class AtomFeedParser : IFeedParser
	{
		private XDocument doc;

		public AtomFeedParser(XDocument d)
		{
			doc = d;
		}

		public List<NewsItem> Create(int feedSourceId)
		{
			try
			{
				if (!doc.Elements().Any()) return null;
				XNamespace d = "http://www.w3.org/2005/Atom";

				List<NewsItem> items = (from entry in doc.Descendants(d + "entry")
										select new NewsItem
										{
											Id = (entry.Element(d + "id") != null ? entry.Element(d + "id").Value : entry.Element(d + "link").Value),
											Title = entry.Element(d + "title").Value,
											Description = (entry.Element(d + "summary").Value ?? ""),
											Timestamp = DateHelper.Parse(entry.Element(d + "updated").Value ?? DateTime.Now.ToString()),
											Url = entry.Element(d + "link").Attribute("href").Value,
                                            Category = (entry.Element(d + "category").Value ?? ""),
                                            FeedSourceId = feedSourceId,
											FetchTime = DateTime.Now.ToUniversalTime(),
											//Source = feed.Name,
											FeedType = FeedType.Atom,
										}).ToList();
				return items;
			}
			catch
			{
				return null;
			}
		}
	}
}