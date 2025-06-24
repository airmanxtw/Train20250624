<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Train20250624.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size:20px">
            <div>
                請輸入半徑:<asp:TextBox ID="TextBox1" runat="server" Font-Size="20px" Width="256px"></asp:TextBox>
                <span style="margin-left:5px">
                    <asp:Button ID="Button1" runat="server" Text="計算" OnClick="Button1_Click" />
                </span>            
            </div>
            <div style="margin-top:5px">
                結果:
                <div>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
