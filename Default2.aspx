<%@ Page Title="ANA SAYFA" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>




<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sitesConnectionString %>" DeleteCommand="DELETE FROM [Siteler] WHERE [siteID] = @siteID" InsertCommand="INSERT INTO [Siteler] ([siteAd], [siteURL], [siteDurum], [controlSuresi]) VALUES (@siteAd, @siteURL, @siteDurum, @controlSuresi)" SelectCommand="SELECT * FROM [Siteler]" UpdateCommand="UPDATE [Siteler] SET [siteAd] = @siteAd, [siteURL] = @siteURL, [siteDurum] = @siteDurum, [controlSuresi] = @controlSuresi WHERE [siteID] = @siteID">

            </asp:SqlDataSource>

                <div style="margin:0 auto;">
                    
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>


                    <asp:GridView ID="KapListe" runat="server" 
        
                    AlternatingRowStyle-CssClass="str_iki" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-bordered table-striped table-hover" GridLines="None" PageSize="20"
                    Width="80%" DataSourceID="SqlDataSource1" ForeColor="#333333" HorizontalAlign="Center" Height="245px" OnSelectedIndexChanged="KapListe_SelectedIndexChanged">
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
                                Anı Güncelleme
                            </HeaderTemplate>
            <ItemTemplate>
                
                <div >
                    <asp:Button ID="guncelButton" runat="server" CausesValidation="false" 
                    Text="Güncelle" CommandArgument='<%# Eval("siteID") %>' OnClick="Button1_Click" />

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
                    
                  
</asp:Content>










