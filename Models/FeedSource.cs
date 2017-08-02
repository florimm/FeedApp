using System;
using System.Xml.Serialization;

namespace FeedApp.Models
{
	public class FeedSource
	{
		public int Id { get; set; }
		public string Name { get; set;}

		public DateTime? LastFetched { get; set;}

		public int Interval { get; set;}

		public string CategoryName { get; set;}

		public string Url { get; set;}
        public EncodingType EncodingType { get; set; }
    }
    public enum EncodingType
    {
        Default = 0,
        UTF8 = 1
    }
}