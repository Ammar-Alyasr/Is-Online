<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

    
    </div>
        <br />
        
        <asp:Timer ID="Timer1" runat="server" Interval="8000" OnTick="Timer1_Tick"></asp:Timer>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="guncelleme"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
