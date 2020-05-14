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
           // bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.css", ));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/GeorgeCss").Include("~/Content/MyCssClass.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/owl").Include("~/Content/owl.carousel.min.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/slicknav").Include("~/Content/slicknav.min.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/stylecss").Include("~/Content/style.css"));
            //awesome fonts
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/awesome-fonts").Include("~/Content/font-awesome.min.css"));
            //bootstrap js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/main").Include("~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/mixitup").Include("~/Scripts/mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/owl").Include("~/Scripts/owl.carousel.min.js"));
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-3.2.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/slicknav").Include("~/Scripts/jquery.slicknav.min.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}