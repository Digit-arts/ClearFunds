<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false"
    CodeFile="Packages.aspx.vb" Inherits="_Packages" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Packages</h2>
    <div>
         <asp:Panel ID="Panel1" runat="server">
  
   
    <asp:PlaceHolder   ID="PlaceHolder1" runat="server">
     <div id="divlblgrid" runat ="server" class="pack_tab"></div>
      <asp:HiddenField ID="PressedButton" runat="server" /> 
    </asp:PlaceHolder>

       
      </asp:Panel>   
<%--<asp:GridView ID="GVPackageList"  AutoGenerateColumns="false" runat="server">
    <Columns>
   
    <asp:TemplateField  Visible="false" HeaderText="pack_id">
    <ItemTemplate>'<%# Eval("package_id")%>'
    </ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="PackageName">
    <ItemTemplate>
   <%# Eval("Package_name")%>
   <%# Eval("Packagedet_Plan")%>
  </ItemTemplate>
  </asp:TemplateField>
    <asp:TemplateField HeaderText="PlanName">
    <ItemTemplate>
     <%# Eval("Packagedet_Plan")%>
    </ItemTemplate>
    
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Deposit (US $)">
    <ItemTemplate>
      <%# Eval("deposit")%>
    
    </ItemTemplate>
    
    
    </asp:TemplateField>
    <asp:TemplateField HeaderText="	Profit (%)">
    <ItemTemplate>
      <%# Eval("Packagedet_Percent")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Actions">
    <ItemTemplate>
  <asp:ImageButton ID="ImageButton1"   OnCommand="GVPackageList_Command"  AlternateText="Edit" CommandName="Edit" ImageUrl="Images/add.jpg" CommandArgument='<%#Eval("package_id") %>'  runat="server" />--%>
  <%--  <asp:HyperLink ID="HyperLink1"  Text="Edit" runat="server" ></asp:HyperLink>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/addplans.aspx?Pid="+Eval("package_id")%>'>Edit</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField> 
    
    </Columns> 
    
</asp:GridView>--%> 
</div> 

  <div class="add_button">
    <a href="addplans.aspx" title="Add new Package!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
   
    </div>

     

    <%-- <a href='<%# String.Format("~/addplans.aspx?package_id={0}", Eval("package_id")) %>' title="Edit Package!">
    <img src="Images/add.jpg" alt="Edit" style="height:20px;" />Edit</a> --%>
</asp:Content>