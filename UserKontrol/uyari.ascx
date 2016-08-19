<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uyari.ascx.cs" Inherits="UserKontrol_uyari" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<style type="text/css">
    .auto-style1 {
        height: 24px;
        background-color:aqua ;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:Button ID="btnShow" runat="server" Style="display: none;" />

<asp:Panel ID="pnlPopup" runat="server" Style="background-color:white; width: 420px; border-width: 2px; border-color: gray; font-size: 10pt; font-family: Tahoma; line-height: 15px; border: 1px solid #A6A6A6;"  >
  <div class="box box-info">
            <div class="box-header with-border">
                <asp:Label ID="Label1" runat="server" Text="Bilgi"></asp:Label>
            </div>
    <asp:Panel ID="Group5" runat="server" Width="100%" Visible="true">
            <div class="auto-style1">

                <asp:Label ID="lbl_uyari" runat="server" Text=""></asp:Label>

                </div>
        </asp:Panel>
      </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="KAPAT" />
    </asp:Panel>
  
        <ajaxToolkit:ModalPopupExtender  ID="messageBox1" runat="server" TargetControlID="btnShow" PopupControlID="pnlPopup" BackgroundCssClass="messageBox"></ajaxToolkit:ModalPopupExtender>

        <br />

</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

