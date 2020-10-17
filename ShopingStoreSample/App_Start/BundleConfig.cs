using System.Web;
using System.Web.Optimization;

namespace ShopingStoreSample
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/HomeStyle").Include(
                          "~/Content/TemplateStyle/main_styles.css",
                          "~/Content/TemplateStyle/responsive.css",
                          "~/Content/TemplateStyle/bootstrap.min.css",
                           "~/Scripts/TemplateJs/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                            "~/Scripts/TemplateJs/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                            "~/Scripts/TemplateJs/plugins/OwlCarousel2-2.2.1/animate.css"


                      ));
            /*bundles.Add(new StyleBundle("~/Content/Templetcss").Include(
                     "~/Content/TemplateStyle/cart.css",
                     "~/Content/TemplateStyle/cart_responsive.css",
                      "~/Content/TemplateStyle/category.css",
                      "~/Content/TemplateStyle/category_responsive.css",
                        "~/Content/TemplateStyle/checkout.css",
                          "~/Content/TemplateStyle/checkout_responsive.css",
                          "~/Content/TemplateStyle/main_styles.css"
                      ));*/

            bundles.Add(new ScriptBundle("~/bundles/HomeJs").Include(
                    "~/Scripts/TemplateJs/jquery-3.2.1.min.js",
                    "~/Scripts/TemplateJs/popper.js",
                    "~/Scripts/TemplateJs/plugins/greensock/TweenMax.min.js",
                     "~/Scripts/TemplateJs/plugins/greensock/TimelineMax.min.js",
                      "~/Scripts/TemplateJs/plugins/scrollmagic/ScrollMagic.min.js",
                       "~/Scripts/TemplateJs/plugins/greensock/animation.gsap.min.js",
                        "~/Scripts/TemplateJs/plugins/greensock/ScrollToPlugin.min.js",
                         "~/Scripts/TemplateJs/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
                          "~/Scripts/TemplateJs/plugins/easing/easing.js",
                           "~/Scripts/TemplateJs/plugins/progressbar/progressbar.min.js",
                            "~/Scripts/TemplateJs/plugins/parallax-js-master/parallax.min.js",
                            "~/Scripts/TemplateJs/ custom.js",
                            "~/Scripts/TemplateJs/bootstrap.min.js"
                    ));
            
        }
    }
}
