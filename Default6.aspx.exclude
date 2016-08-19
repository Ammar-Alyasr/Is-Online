<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<script runat="server">

    
</script>



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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
               DataSourceID="SqlDataSource1"  AlternatingRowStyle-CssClass="str_iki"
              ShowFooter="True" BackColor="#DEBA84" BorderColor="#DEBA84"
                CssClass="table table-bordered table-striped table-hover" GridLines="None" PageSize="20"  Height="245px"
              BorderStyle="None" BorderWidth="1px" CellPadding="3"  Width="80%"  
              CellSpacing="2" DataKeyNames="siteID">

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="pagination" HorizontalAlign="Center"
                        VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        Hiç kayıt yok...
                    </EmptyDataTemplate>

                                <AlternatingRowStyle CssClass="str_iki" />
    <Columns>
           <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        
           
            <asp:BoundField DataField="siteAd" HeaderText="Site Adi " SortExpression="siteAd" />
            <asp:BoundField DataField="siteURL" HeaderText="URL " SortExpression="siteURL" />
            
            
            <asp:BoundField DataField="siteDurum2" HeaderText="Site Son Durumu" SortExpression="siteDurum2" />
            <asp:BoundField DataField="zaman" HeaderText="Son Kontrol Tarihi" SortExpression="zaman" />
            <asp:TemplateField >
                            <HeaderTemplate>
                                Control Suresi
                            </HeaderTemplate>
                 
            <ItemTemplate>
                
                <div >
                    <asp:DropDownList runat="server" DataField="controlSuresi" HeaderText="Control Suresi" SortExpression="controlSuresi">

                         <asp:ListItem Text="1 DK"></asp:ListItem>
                         <asp:ListItem Text="5 DK"></asp:ListItem>
                         <asp:ListItem Text="1 SAAT"></asp:ListItem>
                         <asp:ListItem Text="1 GUN"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </ItemTemplate>
        </asp:TemplateField>


    </Columns>

               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

               </asp:GridView>
            
            </ContentTemplate>
            </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sitesConnectionString %>" SelectCommand="SELECT * FROM [Siteler]" DeleteCommand="DELETE FROM [Siteler] WHERE [siteID] = @siteID" InsertCommand="INSERT INTO [Siteler] ([siteAd], [siteURL], [controlSuresi], [button], [siteDurum2], [zaman], [userID]) VALUES (@siteAd, @siteURL, @controlSuresi, @button, @siteDurum2, @zaman, @userID)" UpdateCommand="UPDATE [Siteler] SET [siteAd] = @siteAd, [siteURL] = @siteURL, [controlSuresi] = @controlSuresi, [button] = @button, [siteDurum2] = @siteDurum2, [zaman] = @zaman, WHERE [siteID] = @siteID">
        <DeleteParameters>
            <asp:Parameter Name="siteID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="siteAd" Type="String" />
            <asp:Parameter Name="siteURL" Type="String" />
            <asp:Parameter Name="controlSuresi" Type="String" />
            <asp:Parameter Name="button" Type="String" />
            <asp:Parameter Name="siteDurum2" Type="String" />
            <asp:Parameter Name="zaman" Type="String" />
            <asp:Parameter Name="userID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="siteAd" Type="String" />
            <asp:Parameter Name="siteURL" Type="String" />
            <asp:Parameter Name="controlSuresi" Type="String" />
            <asp:Parameter Name="button" Type="String" />
            <asp:Parameter Name="siteDurum2" Type="String" />
            <asp:Parameter Name="zaman" Type="String" />
            <asp:Parameter Name="userID" Type="Int32" />
            <asp:Parameter Name="siteID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    </asp:Content>