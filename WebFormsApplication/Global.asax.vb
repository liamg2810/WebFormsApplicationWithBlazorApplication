Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        If Not Roles.RoleExists("Admin") Then
            Roles.CreateRole("Admin")
        End If

        ' Create user if it doesn't exist
        If Membership.GetUser("admin") Is Nothing Then
            Membership.CreateUser("admin", "Password123!", "admin@example.com")
            Roles.AddUserToRole("admin", "Admin")
        End If
    End Sub
End Class