using FeedApp.Models;
using FeedApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedApp.Utils
{
    public static class ViewModelExtensions
    {
        public static IEnumerable<NewsItemViewModel> ToViewModel(this List<NewsItem> source)
        {
            return source.Select(t => t.ToViewModel()).ToList();
        }
        public static NewsItemViewModel ToViewModel(this NewsItem source)
        {
            return new NewsItemViewModel()
            {
                Id = source.Id,
                FeedItemId = source.FeedItemId,
                Description = source.Description,
                FeedSourceId = source.FeedSourceId,
                Source = source.FeedSource.Name,
                Url = source.Url,
                FeedType = source.FeedType,
                FetchTime = source.FetchTime,
                Category = source.Category,
                Timestamp = source.Timestamp,
                Title = source.Title,
            };
        }

        public static IEnumerable<FeedSourceViewModel> ToViewModel(this List<FeedSource> source)
        {
            return source.Select(t => t.ToViewModel()).ToList();
        }
        public static FeedSourceViewModel ToViewModel(this FeedSource source)
        {
            return new FeedSourceViewModel()
            {
                Id = source.Id,
                Url = source.Url,
                Name = source.Name,
                CategoryName = source.CategoryName
            };
        }
    }
}
