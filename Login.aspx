<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Train20250624.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            帳號:<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        </div>
        <div style="margin-top:5px">
            密碼:<asp:TextBox ID="PassWord" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div style="margin-top:5px">
            <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" />
        </div>
        <div style="margin-top:5px">
            結果:<br />
            <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
