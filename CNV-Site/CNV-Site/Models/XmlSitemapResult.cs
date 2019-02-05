﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CNV_Site.Models
{
    public class XmlSitemapResult : ActionResult
    {
        private static readonly XNamespace xmlns = "http://www.sitemaps.org/sch...";

        private IEnumerable<ISiteMapItem> _items;

        public XmlSitemapResult(IEnumerable<ISiteMapItem> items)
        {
            _items = items;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string encoding = context.HttpContext.Response.ContentEncoding.WebName;
            XDocument sitemap = new XDocument(new XDeclaration("1.0", encoding, "yes"),
            new XElement(xmlns + "urlset",
            from item in _items
            select CreateItemElement(item)
            )
            );

           // context.HttpContext.Response.ContentType = "application/rss+xml";
            context.HttpContext.Response.ContentType = "text/xml"; //use this; it will not download the file
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(sitemap.Declaration + sitemap.ToString());
        }

        private XElement CreateItemElement(ISiteMapItem item)
        {
            XElement itemElement = new XElement(xmlns + "url", new XElement(xmlns + "loc", item.Url.ToLower()));

            if (item.LastModified.HasValue)
                itemElement.Add(new XElement(xmlns + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));

            if (item.ChangeFrequency.HasValue)
                itemElement.Add(new XElement(xmlns + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));

            if (item.Priority.HasValue)
                itemElement.Add(new XElement(xmlns + "priority", item.Priority.Value.ToString(CultureInfo.InvariantCulture)));

            return itemElement;
        }
    }
}