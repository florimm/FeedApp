using System.Collections.Generic;
using FeedApp.Models;

namespace FeedApp.Parsers
{
  public interface IFeedParser
  {
    List<NewsItem> Create(int feedSourceId);
  }
}