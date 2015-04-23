﻿using System.Web;
using System.Web.Optimization;

namespace Dejavu
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/js/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.unobtrusive*",
                        "~/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr-*", "~/Scripts/kendo/2014.3.1411/jszip.min.js",
                        "~/Scripts/kendo/2014.3.1411/kendo.all.min.js",
                        "~/Scripts/kendo/2014.3.1411/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/css/bootstrap.css", "~/css/facebook.css", "~/Content/kendo/2014.3.1411/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2014.3.1411/kendo.mobile.all.min.css",
                "~/Content/kendo/2014.3.1411/kendo.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}