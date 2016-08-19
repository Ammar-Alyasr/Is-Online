<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <br />
        <div>
            <iframe scrolling="no" style="border:none;" width="250" height="413" src="https://www.google.com/trends/hottrends/widget?pn=p1&amp;tn=10&amp;h=413"></iframe>
        </div>
    
    </div>
    </form>
</body>
</html>
