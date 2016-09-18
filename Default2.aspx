<%@ Page Title="ANA SAYFA" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>




<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    

                <div style="margin:0 auto;">
                    
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="col-md-2"></div>

                            <div class="col-md-9" >
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
  <div class="btn-group" role="group">
    
      <asp:LinkButton ID="LinkButton1" class="btn btn-primary" OnClick="LinkButton1_Click" runat="server" data-placement="bottom" title="Hatali Olan Siteleri Filtere">Hata Gösteren</asp:LinkButton>
  </div>
  <div class="btn-group" role="group">
      <asp:LinkButton ID="LinkButton2" class="btn btn-warning " OnClick="LinkButton2_Click" runat="server" data-placement="top" title="Guncelleme Tarihine Gore Filtere">Güncellemeyen</asp:LinkButton>
    
  </div>
  <div class="btn-group" role="group">
      <asp:LinkButton ID="LinkButton3" class="btn btn-info" OnClick="LinkButton3_Click" runat="server" data-placement="bottom" title="Isme Gore Sirala">Isme Göre</asp:LinkButton>
   
  </div>
        </div>
</div>
    

                            
                    <asp:GridView ID="KapListe" runat="server" 
        
                    AlternatingRowStyle-CssClass="str_iki" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-bordered table-striped table-hover" GridLines="None" PageSize="20"
                    Width="80%"  ForeColor="#333333" HorizontalAlign="Center" Height="245px" OnSelectedIndexChanged="KapListe_SelectedIndexChanged">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="pagination" HorizontalAlign="Center"
                        VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        Hiç kayıt yok...
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="str_iki" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Site Ad
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("siteAd") %>
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                URL
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                  <a href='<%# Eval("siteURL") %>'>   <%# Eval("siteURL") %></a>
                                    
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Site durumu
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("siteDurum2") %>
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Son Ktrl Saati
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("zaman") %>
                                </div>

                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField >
                            <HeaderTemplate>
                                AnLık Güncelleme
                            </HeaderTemplate>
            <ItemTemplate>
                
                <div >
                    <asp:Button ID="guncelButton" class="btn btn-info btn-sm" runat="server"
                    Text="Güncelle" CommandArgument='<%# Eval("siteID") %>' OnClick="Button1_Click" />

                </div>
            </ItemTemplate>
        </asp:TemplateField>

                        <asp:TemplateField >
                            <HeaderTemplate>
                                Son Haraketler
                            </HeaderTemplate>
            <ItemTemplate>
                    
                <div >
                    <asp:Button ID="Button2" class="btn btn-warning btn-sm" runat="server" 
                    Text="Detay" CommandArgument='<%# Eval("siteID") %>' OnClick="Button2_Click" />

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
                            
                    
                  
</asp:Content>










