
Partial Class ProductDetail
    Inherits System.Web.UI.Page

    Protected Sub back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles back.Click
        Response.Redirect("produkt.aspx")
    End Sub
End Class
