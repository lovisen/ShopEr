
Partial Class ShopErMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub btnPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPay.Click
        Response.Redirect("Order.aspx")

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Response.Redirect("Adminproduct.aspx")
    End Sub
End Class

