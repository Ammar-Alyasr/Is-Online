<%@ Page Title="Haraketler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>


<script runat="server">

    
</script>



<asp:Content ID="Content4" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .controls {
        height: 51px;
    }
</style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">



     <div style="margin:0 auto;">
                    
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>


                    <asp:GridView ID="KapListe" runat="server" 
        
                    AlternatingRowStyle-CssClass="str_iki" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-bordered table-striped table-hover" GridLines="None" PageSize="20"
                    Width="80%" ForeColor="#333333" HorizontalAlign="Center" Height="245px" >
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="pagination" HorizontalAlign="Center"
                        VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        Her hangi bir degisiklik gosterilmemistir...
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="str_iki" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                  <Columns>
                      <asp:BoundField DataField="siteAd" HeaderText="Site Adi" SortExpression="siteAd" />
                      
                      
                      <asp:BoundField DataField="GosterilenDegisiklik" HeaderText="Yaptigi Degisik" SortExpression="GosterilenDegisiklik" />
                     <asp:BoundField DataField="zaman" HeaderText="Degisiklik Tarihi" SortExpression="zaman" />
                     <asp:BoundField DataField="siteDurum2" HeaderText="Simdiki Durum" SortExpression="siteDurum2" />
                   
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

    
    </asp:Content>


