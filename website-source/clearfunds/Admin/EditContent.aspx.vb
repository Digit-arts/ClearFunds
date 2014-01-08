Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Partial Class Admin_EditContent
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim obj As New ClassFunctions()
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString())
    Dim cmd As New SqlCommand()
    Dim SelectedIndexId As String = ""
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim con As New SqlConnection(obj.ConnectionString())
            Dim cmd As New SqlCommand("select  * from CF_contents where contents_status<>2 ", con)
            cmd.Connection.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            cmbpagelevel.DataSource = dr
            cmbpagelevel.DataValueField = "contents_id"
            cmbpagelevel.DataTextField = "contents_title"
            cmbpagelevel.DataBind()
            cmd.Connection.Close()
            cmd.Connection.Dispose()
            If Not (Request.QueryString("cmbid") Is Nothing) Then

                'cmbpagelevel.SelectedValue = obj.Returnsinglevalue("select [contents_id] from [CBC_contents] where [contents_id]='" + cmbpagelevel.SelectedItem.Text + "'");

                cmbpagelevel.SelectedValue = Request.QueryString("cmbid")
            End If




            If Request.QueryString("id") IsNot Nothing Then




                'Label1.Text = "Edit Content Management System";
                'Label1.CssClass = "head_top";


                Dim Header As New HtmlGenericControl("h2")
                Header.ID = "NewControl"
                Header.InnerText = "Edit Content Management System"
                Header.Attributes.Add("class", "head_top")
                Label1.Controls.Add(Header)






                btnsave.Text = "Update"
                SelectedIndexId = Request.QueryString("id").ToString()
                dt = obj.returndatatable("select * from CF_contents where contents_id='" & SelectedIndexId & "'", dt)
                'int count = dt.Rows.Count - 1;
                'for (int i = 0; i <= count; i++)
                '{
                If dt.Rows.Count > 0 Then
                    btnsave.Text = "Update"
                    Dim con1 As New SqlConnection(obj.ConnectionString())
                    Dim cmd1 As New SqlCommand("select  * from  CF_contents where contents_status<>2 ", con1)
                    cmd1.Connection.Open()
                    Dim dr1 As SqlDataReader
                    dr1 = cmd1.ExecuteReader()
                    cmbpagelevel.DataSource = dr1
                    cmbpagelevel.DataValueField = "contents_id"
                    cmbpagelevel.DataTextField = "contents_title"
                    cmbpagelevel.DataBind()
                    cmd1.Connection.Close()
                    cmd1.Connection.Dispose()
                    'cmbpagelevel.SelectedValue = dt.Rows[0]["contents_header_title"].ToString();


                    cmbpagelevel.SelectedValue = dt.Rows(0)("contents_fid").ToString()
                    cmbpagelevel.SelectedValue = dt.Rows(0)("contents_header_title").ToString()
                    txtheadertitleEN.Text = dt.Rows(0)("contents_title").ToString()


                    If dt.Rows(0)("contents_publish").ToString() = "1" Then
                        chkheadertitle.Checked = True
                    Else
                        chkheadertitle.Checked = False
                    End If


                    'if (dt.Rows[0]["contents_external_link"].ToString() == "True")
                    '{
                    '    //chkexternallink.Checked = true;
                    '}
                    'else
                    '{
                    '    //chkexternallink.Checked = false;
                    '}


                    txtmetatitle.Text = dt.Rows(0)("contents_metatitle").ToString()
                    txtmetakeyword.Text = dt.Rows(0)("contents_metakey").ToString()
                    txtmetadescription.Text = dt.Rows(0)("contents_metadesc").ToString()

                    'txtexternalimage.Text = dt.Rows[0]["contents_banner_image_ext"].ToString();
                    'txtimagetitle.Text = dt.Rows[0]["contents_banner_image_title"].ToString();
                    mce_editor_0.Text = dt.Rows(0)("contents_content").ToString()


                    RadioButtonList1.SelectedValue = dt.Rows(0)("contents_status").ToString()


                End If

            End If
        End If

    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs)




        If Request.QueryString("id") Is Nothing Then

            Dim dt3 As New DataTable()



            dt3 = obj.returndatatable("select contents_title from CF_contents where contents_title='" + txtheadertitleEN.Text & "' and contents_status<>2 and contents_title <>''", dt3)
            If dt3.Rows.Count > 0 Then




                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Menu Already Exist!please try with Some other Name');", True)
            Else

                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_contents"
                cmd.Connection = con


                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "add"
                cmd.Parameters.Add("@contents_fid", SqlDbType.VarChar).Value = cmbpagelevel.SelectedValue
                cmd.Parameters.Add("@contents_header_title", SqlDbType.VarChar).Value = cmbpagelevel.SelectedItem.Text
                cmd.Parameters.Add("@contents_title", SqlDbType.VarChar).Value = txtheadertitleEN.Text

                cmd.Parameters.Add("@contents_publish", SqlDbType.TinyInt).Value = chkheadertitle.Checked


                'cmd.Parameters.Add("@contents_external_link", SqlDbType.VarChar).Value = chkexternallink.Checked;
                cmd.Parameters.Add("@contents_metatitle", SqlDbType.VarChar).Value = txtmetatitle.Text
                cmd.Parameters.Add("@contents_metakey", SqlDbType.VarChar).Value = txtmetakeyword.Text
                cmd.Parameters.Add("@contents_metadesc", SqlDbType.VarChar).Value = txtmetadescription.Text

                cmd.Parameters.Add("@contents_content", SqlDbType.VarChar).Value = mce_editor_0.Text

                cmd.Parameters.Add("@contents_status", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.Add("@contents_ordering", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@contents_custom_view", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@contents_testimonial", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@contents_created", SqlDbType.DateTime).Value = System.DateTime.Now
                Dim dt5 As New DataTable()
                dt5 = obj.returndatatable("select * from CF_contents where   contents_fid='" + cmbpagelevel.SelectedValue & "'", dt5)

                If cmbpagelevel.SelectedValue = "1" Then
                    Dim orderno As String = obj.Returnsinglevalue("select max(contents_orderno) from CF_contents where contents_header_title='" + cmbpagelevel.SelectedItem.Text & "'")
                    Dim ord As Integer = Convert.ToInt32(orderno)
                    Dim ordnew As Integer = ord + 1

                    cmd.Parameters.Add("@contents_orderno", SqlDbType.Int).Value = ordnew

                ElseIf Not (dt5.Rows.Count > 0) Then
                    Dim ordno2 As String = obj.Returnsinglevalue("select  max(contents_orderno) from CF_contents where contents_header_title='" + cmbpagelevel.SelectedItem.Text & "'")
                    Dim ord As Integer = Convert.ToInt32(ordno2)
                    Dim ordnew As Integer = ord + 1

                    cmd.Parameters.Add("@contents_orderno", SqlDbType.Int).Value = ordnew
                Else

                    Dim orderno1 As String = obj.Returnsinglevalue("select contents_orderno from CF_contents where contents_title='" + cmbpagelevel.SelectedItem.Text & "'")
                    'int ord1 = Convert.ToInt32(orderno1+ 1);

                    Lblrow.Text = orderno1 & 1
                    cmd.Parameters.Add("@contents_orderno", SqlDbType.Int).Value = Lblrow.Text
                End If

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                'lblmsg.Text = "content added successfully"
                'Response.Redirect("contentmanage.aspx")                                                                                                                                                                                  
                Dim message As String = "content Added succssfully"
                Dim url As String = "contentmanage.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
               

            End If
        Else
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_contents"
            cmd.Connection = con
            con.Open()
            cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "MODIFY"
            cmd.Parameters.Add("@contents_id", SqlDbType.VarChar).Value = Request.QueryString("id").ToString()
            cmd.Parameters.Add("@contents_fid", SqlDbType.VarChar).Value = cmbpagelevel.SelectedValue
            cmd.Parameters.Add("@contents_header_title", SqlDbType.VarChar).Value = cmbpagelevel.SelectedItem.Text
            cmd.Parameters.Add("@contents_title", SqlDbType.VarChar).Value = txtheadertitleEN.Text

            cmd.Parameters.Add("@contents_publish", SqlDbType.TinyInt).Value = chkheadertitle.Checked



            'cmd.Parameters.Add("@contents_external_link", SqlDbType.VarChar).Value = chkexternallink.Checked;
            cmd.Parameters.Add("@contents_metatitle", SqlDbType.VarChar).Value = txtmetatitle.Text
            cmd.Parameters.Add("@contents_metakey", SqlDbType.VarChar).Value = txtmetakeyword.Text
            cmd.Parameters.Add("@contents_metadesc", SqlDbType.VarChar).Value = txtmetadescription.Text

            cmd.Parameters.Add("@contents_content", SqlDbType.VarChar).Value = mce_editor_0.Text

            cmd.Parameters.Add("@contents_status", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
            cmd.Parameters.Add("@contents_ordering", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@contents_custom_view", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@contents_testimonial", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@contents_created", SqlDbType.DateTime).Value = System.DateTime.Now
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            con.Close()
            'lblmsg.Text = "content updated succssfully"
            Dim message As String = "content updated succssfully"
            Dim url As String = "contentmanage.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            'Response.Redirect("contentmanage.aspx")
        End If
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        If FileUpload1.HasFile Then
            Dim FileName As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim FilePath As String = "~/img_upload/" & FileName

            FileUpload1.SaveAs(Server.MapPath(FilePath))
            Dim fp1 As String = "http://clearfunds.acopies.com/img_upload/" & FileName
            Dim h1 As String = txtheight.Text
            Dim h2 As String = txtwidth.Text
            mce_editor_0.Text += String.Format("<img src = '{0}' width='{1}'   height='{2}'  alt = '{3}' />", fp1, h1, h2, FileName)
        End If
    End Sub
End Class
