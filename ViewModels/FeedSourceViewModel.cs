﻿using FeedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedApp.ViewModels
{
    public class FeedSourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Url { get; set; }
    }
}