<%@ Application Language="C#" %>
<%@ Import Namespace="ProfileManagement" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Session_Start(object sender, EventArgs e)
    {
        Session["th"] = "";
    }
    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

</script>
