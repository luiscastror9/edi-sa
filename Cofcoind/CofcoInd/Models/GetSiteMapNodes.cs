using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CofcoInd.Models
{
    public  class GetSiteMapNodes 
    {
        public IReadOnlyCollection<SitemapItem> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapItem> nodes = new List<SitemapItem>();
            nodes.Add(
                new SitemapItem()
                {
                Url = urlHelper.RequestContext.HttpContext.Request.Url.Scheme + "://" + urlHelper.RequestContext.HttpContext.Request.Url.Authority 
+ urlHelper.Action("Index", "Home"),
                    Priority = 1
                });
          
            //foreach (int productId in productRepository.GetProductIds())
            //{
            //    nodes.Add(
            //       new SitemapNode()
            //       {
            //           Url = urlHelper.AbsoluteRouteUrl("ProductGetProduct", new { id = productId }),
            //           Frequency = SitemapFrequency.Weekly,
            //           Priority = 0.8
            //       });
            //}
            return nodes;
        }
      
        public string GetSitemapDocument(IEnumerable<SitemapItem> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapItem sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.ChangeFrequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.ChangeFrequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }


    }
    
}