<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Train20250624.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>帳號:</span>
            <span>
                <asp:TextBox ID="UserIdTextBox" runat="server"></asp:TextBox>
            </span>
        </div>
        <div style="margin-top:5px">
            <span>密碼:</span>
            <span>
                <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
            </span>
        </div>
        <div style="margin-top:10px">
            <asp:Button ID="SubmitButton" runat="server" Text="登入" OnClick="SubmitButton_Click" />
        </div>
        <div style="margin-top:5px">
            <asp:Label ID="MsgLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
