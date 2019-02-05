using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CofcoInd.Models
{
    public class SitemapItem 
    {
        public SitemapItem(string url)
        {
            Url = url;
        }

        public SitemapItem()
        {
            // TODO: Complete member initialization
        }

        public string Url { get; set; }

        public DateTime? LastModified { get; set; }

        public ChangeFrequency? ChangeFrequency { get; set; }

        public double? Priority { get; set; }
    }
}