﻿using System.Web;
using System.Web.Optimization;

namespace SimpleBusinessManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerydatatables").Include(
                "~/Scripts/Datatables/jquery.dataTables.js"));



            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Validações no padrão brasileiro
            bundles.Add(
                new ScriptBundle("~/bundles/validations_pt-br")
                    .Include(
                        "~/Scripts/jquery.validate.custom.pt-br*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryinputmask").Include(
                        "~/Scripts/jquery.inputmask/inputmask.js",
                        "~/Scripts/jquery.inputmask/inputmask.???.Extensions.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap.css",
                          "~/Content/font-awesome.css",
                          "~/Content/site.css",
                          "~/Content/DataTables/css/jquery.dataTables.css"));

        }
    }
}