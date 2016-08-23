<%@ Page Title="Haraketler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>


<script runat="server">

    
</script>



<asp:Content ID="Content4" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .controls {
        height: 51px;
    }
    .iwrap { overflow:hidden; width:100%;  max-height:100%; max-height:100%;}
   #frame {
        -ms-zoom: 0.50;
        -moz-transform: scale(0.50);
        -moz-transform-origin: 0 0;
        -o-transform: scale(0.50);
        -o-transform-origin: 0 0;
        -webkit-transform: scale(0.50);
        -webkit-transform-origin: 0 0;
        overflow:hidden;
    }
</style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">



     <div style="margin:0 auto;">
                    
                    </div>
    <div class="row"><div class="col-md-8">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                    <asp:GridView ID="KapListe" runat="server" 
        
                    AlternatingRowStyle-CssClass="str_iki" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-bordered table-striped table-hover" GridLines="None" PageSize="20"
                    Width="80%" ForeColor="#333333" HorizontalAlign="Center" Height="245px" OnSelectedIndexChanged="KapListe_SelectedIndexChanged" >
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
                   <asp:TemplateField>
                            <HeaderTemplate>
                                Site Ad
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("sad") %>
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>
                     <asp:TemplateField>
                            <HeaderTemplate>
                                Açıklama
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("Aciklama") %>
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                               Tarih
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("tarih") %>
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

        
    </div><div class="col-md-4"><div class=""><br /><br /><br /><br /><br />
 
        <div id="wrap" class="iwrap">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</div>
</div></div></div>
  
 

    </asp:Content>


