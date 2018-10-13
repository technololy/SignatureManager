<%@ Application Language="C#" %>
<%@ Import Namespace="SignatureManager" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    protected void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs   
        Exception Ex = Server.GetLastError();
        Server.ClearError();
        // ExceptionLogging.LogErrorToEventViewer(Ex);   
        //ExceptionLogging.LogErrorToDB(Ex);
        Server.Transfer("Error.aspx");
    }

</script>
