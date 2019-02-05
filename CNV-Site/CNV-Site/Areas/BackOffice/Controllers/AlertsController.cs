using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime;
using  CNV_Site.Areas.BackOffice.Extensions;

namespace CNV_Site.Areas.BackOffice.Controllers
{
    public class AlertsController : Controller
    {
         [Authorize]
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(CNV_Site.Areas.BackOffice.Extensions.AlertHelper.AlertStyles.Success, message, dismissable);
        }
         [Authorize]
        public void Information(string message, bool dismissable = false)
        {
            AddAlert(CNV_Site.Areas.BackOffice.Extensions.AlertHelper.AlertStyles.Information, message, dismissable);
        }
         [Authorize]
        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(CNV_Site.Areas.BackOffice.Extensions.AlertHelper.AlertStyles.Warning, message, dismissable);
        }
         [Authorize]
        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(CNV_Site.Areas.BackOffice.Extensions.AlertHelper.AlertStyles.Danger, message, dismissable);
        }
         [Authorize]
        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert.TempDataKey)
                ? (List<CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert>)TempData[CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert.TempDataKey]
                : new List<CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert>();

            alerts.Add(new CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[CNV_Site.Areas.BackOffice.Extensions.AlertHelper.Alert.TempDataKey] = alerts;
        }
    }
}