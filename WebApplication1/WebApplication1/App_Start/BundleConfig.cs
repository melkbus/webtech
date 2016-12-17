﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            bundles.Add(new ScriptBundle("~/bundles/cload").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/jquery.ui.widget.js",
                "~/Scripts/jquery.iframe-transport.js",
                "~/Scripts/jquery.fileupload.js",
                "~/Scripts/jquery.cloudinary.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/bootstrap-tokenfield.js",
                "~/Scripts/typeahead.jquery.js",
                "~/Scripts/typeahead.moment.min.js",
                "~/Scripts/typeahead.daterangepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/bootstrap-theme.css",
                 "~/Content/bootstrap-theme.min.css",
                 "~/Content/Site.css",
                 "~/Content/tokenfield.css",
                 "~/Content/jquery-ui.css"));
        }
    }
}
