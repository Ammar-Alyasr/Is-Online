<%@ Page Title="Haraketler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<script runat="server">

    
</script>


<%@ Register src="UserKontrol/uyari.ascx" tagname="uyari" tagprefix="uc1" %>
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



     
                    
                   
    <div class="row">
        <div class="col-md-8">
                    s<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
           
                
    
                           
                            
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
                                
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="container" style="margin-top:50px;">
                            <div class="row">
                                <div class="col-md-2"></div>
                            <div class="col-xs-8 .col-md-8" >

                            <asp:Panel ID="Panel1" runat="server">
                                
                                <div class="btn-group btn-group-justified" role="group" aria-label="...">

  <div class="btn-group" role="group">
      <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-primary" runat="server"><span class="glyphicon glyphicon-cog"> Ayarlari Degiisitir   </span></asp:LinkButton>
   
  </div>

  <div class="btn-group" role="group">
      
      <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" class="btn btn-warning" runat="server" ><span class="glyphicon glyphicon-stats"> Istatistik</span></asp:LinkButton>
  </div>

  <div class="btn-group" role="group">
      
      <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" class="btn btn-danger" runat="server"><span class="glyphicon glyphicon-remove-circle"> Sil</span></asp:LinkButton>

      <ajaxToolkit:ConfirmButtonExtender ID="LinkButton3_ConfirmButtonExtender" runat="server" ConfirmText="Slınbsın sws"  TargetControlID="LinkButton3" />

  </div>

</div>
                                    
                            </asp:Panel>
                            </div>

                            </div>

        <br /><br /> 
                            
                            
                            <asp:Panel ID="Panel2" runat="server" Visible="False" >
                            <div class="row">
        <div class="col-md-4">  <div class="form-inline">

      <div class="input-group">
    <span class="input-group-addon">Adi</span>
    <asp:TextBox ID="TextBox2" class="form-control" runat="server" aria-describedby="inputGroupSuccess3Status"></asp:TextBox> 
          </div>
  </div>
</div>
  <div class="col-md-4">
    <div class="form-inline">
    <div class="input-group">
      <span class="input-group-addon">URL</span>
      
        <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
        
    </div>
      </div>
</div>

                                    <div class="col-md-2"> <div class="from-inline">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control" Width="70px">
            <asp:ListItem Text="1 DK"></asp:ListItem>
            <asp:ListItem Text="5 DK"></asp:ListItem>
            <asp:ListItem Text="1 SAAT"></asp:ListItem>
            <asp:ListItem Text="1 GUN"></asp:ListItem>
            <asp:ListItem class="label label-danger" Text="Passiv" runat="server" ></asp:ListItem>
        </asp:DropDownList>
                                        <br /><br />

                                        

                                    </div>
                                </div>
                                 <div class="col-md-2" >
                              
                                        <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" class="btn btn-info" runat="server"><span class="glyphicon glyphicon-remove-circle"> Guncelle</span></asp:LinkButton>
                                
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

           
        </asp:Panel>
                      </div>      
                            
                           

                            </ContentTemplate>
                            
                        </asp:UpdatePanel>
        </div>
     
        
        <div class="col-md-4"><div class=""><br /><br /><br /><br /><br /> 
 
        <div id="wrap" class="iwrap">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</div>
</div></div>

    </div>
    </asp:Content>


