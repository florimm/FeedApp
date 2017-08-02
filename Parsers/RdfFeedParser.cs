using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FeedApp.Models;

namespace FeedApp.Parsers
{
	public class RdfFeedParser : IFeedParser
	{
		private XDocument doc;

		public RdfFeedParser(XDocument d)
		{
			doc = d;
		}

		public List<NewsItem> Create(int feedSourceId)
		{
			try
			{
				if (!doc.Elements().Any()) return null;
				XNamespace dc = "http://purl.org/dc/elements/1.1/";
				XNamespace rdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
				XNamespace d = "http://purl.org/rss/1.0/";

				List<NewsItem> items = (from item in doc.Descendants(d + "item")
										select new NewsItem
										{
											Id = item.Element(d + "link").Value,
											Title = item.Element(d + "title").Value,
											Timestamp = DateHelper.Parse(item.Element(dc + "date").Value ?? DateTime.Now.ToString()),
											Url = item.Element(d + "link").Value,
											Description = (item.Element(d + "description").Value ?? ""),
                                            Category = (item.Element(d + "category").Value ?? ""),
                                            FeedSourceId = feedSourceId,
											FetchTime = DateTime.Now.ToUniversalTime(),
											//Source = feed.Name,
											FeedType = FeedType.Rdf,
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