using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web.App_Start

{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bootstrap css
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            //bootstrap js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-3.4.1.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}