<%@ Page Title="Site Ekleme " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="UserKontrol/uyari.ascx" tagname="uyari" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .controls {
        height: 51px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="container">
    <div class="row">
		<div class="span12">
			     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			      <legend class="">Login</legend>
			    </div>
			    <div class="control-group">
			      <!-- Username -->
			      

			      <div class="controls">
			          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sitesConnectionString %>" DeleteCommand="DELETE FROM [Siteler] WHERE [siteID] = @siteID" InsertCommand="INSERT INTO [Siteler] ([siteAd], [siteURL], [siteDurum], [controlSuresi]) VALUES (@siteAd, @siteURL, @siteDurum, @controlSuresi)" SelectCommand="SELECT * FROM [Siteler]" UpdateCommand="UPDATE [Siteler] SET [siteAd] = @siteAd, [siteURL] = @siteURL, [siteDurum] = @siteDurum, [controlSuresi] = @controlSuresi WHERE [siteID] = @siteID">
                          <DeleteParameters>
                              <asp:Parameter Name="siteID" Type="Int32" />
                          </DeleteParameters>
                          <InsertParameters>
                              <asp:ControlParameter ControlID="username" Name="siteAd" Type="String" />
                              <asp:ControlParameter ControlID="password" Name="siteURL" Type="String" />
                              <asp:ControlParameter ControlID="sel1" Name="siteDurum" Type="Boolean" />
                              <asp:Parameter Name="controlSuresi" Type="String" />
                          </InsertParameters>
                          <UpdateParameters>
                              <asp:Parameter Name="siteAd" Type="String" />
                              <asp:Parameter Name="siteURL" Type="String" />
                              <asp:Parameter Name="siteDurum" Type="Boolean" />
                              <asp:Parameter Name="controlSuresi" Type="String" />
                              <asp:Parameter Name="siteID" Type="Int32" />
                          </UpdateParameters>
                      </asp:SqlDataSource>
			          <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Username" aria-describedby="sizing-addon3"></asp:TextBox>--%>
                      <br /><br />
                      <label class="control-label"  for="username">Site Isimi</label>
                      <div class="input-group input-group-sm">
  <span class="input-group-addon" id="sizing-addon3">@</span>
  <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Username" aria-describedby="sizing-addon3"></asp:TextBox>
</div>
&nbsp;</div>
			    </div>
			    
        <br /><br /><br /><br /><br /><br />
                    <label for="basic-url">Sitenin URL Adresi</label>
<div class="input-group">
  <span class="input-group-addon" id="basic-addon3">https://orenek.com/blabla/</span>
  <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
</div>

                    <br /><br /><br /><br />
<div class="container">
  
    <div class="form-group">
        
        <label for="basic-url">Kontrol Süresi</label> <br /> 
    <asp:DropDownList ID="DropDownList1" runat="server" Width="185px">
            <asp:ListItem Text="1 DK"></asp:ListItem>
            <asp:ListItem Text="5 DK"></asp:ListItem>
            <asp:ListItem Text="1 SAAT"></asp:ListItem>
            <asp:ListItem Text="1 GUN"></asp:ListItem>
            <asp:ListItem class="label label-danger" Text="Passiv" runat="server" ></asp:ListItem>
        </asp:DropDownList>
       
        </div>
			    </div>

			    <div class="control-group">
			      
			      <div class="controls">   
			          <br />
                      <asp:Button ID="Button1" runat="server" class="btn btn-info " OnClick="Button1_Click1" Text="Ekle" Width="74px" />

			      </div>
			    </div>
     
	</div>
</div>

<style>

    .ModalPopupBG
{
    background-color: #666699;
    filter: alpha(opacity=50);
    opacity: 0.7;
    
}

.HellowWorldPopup
{
    min-width:200px;
    min-height:150px;
    
}
</style>  
            <uc1:uyari ID="uyari1" runat="server" />


            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>

