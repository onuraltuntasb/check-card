<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OnurAltuntas._default" UnobtrusiveValidationMode="None" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server" style="background-image: linear-gradient(to top, #cfd9df 0%, #e2ebf0 100%); text-align:center; height: 2104px;" >
        <div>  
            <asp:Image ID="Image1" runat="server" ImageUrl="https://image.flaticon.com/icons/svg/196/196561.svg" Height="80px" Width="80px" />
        </div>
        <div style="width: 459px; text-align:center; display:inline-block; border:solid ;border-color:orange;border-radius:20px; box-shadow: 10px 10px 10px rgba(0,0,0,0.5">
        <asp:Label ID="lbHeader" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="24px" ForeColor="#FF700F" Height="60px" Text="Credit / Debit Card" Width="250px"></asp:Label>
        <br />
        <asp:Label ID="lbCardType" runat="server" Font-Bold="True" Font-Size="24px" ForeColor="#7B7B7B" Text="Select Credit Card :" style="text-align:center "></asp:Label>
        <asp:DropDownList ID="ddlCardType" runat="server" Height="20px" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" style="margin-left: 16px " Width="215px" text-align="center" display="inline-block" border-radius="20px">
            <asp:ListItem Selected="True">MasterCard</asp:ListItem>
            <asp:ListItem>China UnionPay</asp:ListItem>
            <asp:ListItem>Visa Electron</asp:ListItem>
            <asp:ListItem>Diners Club United States &amp; Canada</asp:ListItem>
            <asp:ListItem>Dankord</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lbCardNumber" runat="server" Font-Bold="True" Font-Size="24px" ForeColor="#7B7B7B" Text="Card Number :"></asp:Label>
            <asp:TextBox ID="txtCardNumber" runat="server" OnTextChanged="txtCardNumber_TextChanged" style="margin-left: 65px" Width="203px"  text-align="center" display="inline-block"  border-radius="20px" ></asp:TextBox>
            
         <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCardNumber"

            MaskType="Number" Mask="9999-9999-9999-9999"   MessageValidatorTip="true"

            ClearMaskOnLostFocus="False" >
        </ajaxToolkit:MaskedEditExtender>
            
            
        <br />
           
         
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCardNumber" Display="Dynamic" ErrorMessage="Not allowed empty field."></asp:RequiredFieldValidator>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        <br />
        <asp:Label ID="lbCardName" runat="server" Font-Bold="True" Font-Size="24px" ForeColor="#7B7B7B" Text="Card Owner's Name"></asp:Label>
        <asp:TextBox ID="txtCardName" runat="server" style="margin-left: 12px" Width="203px"  text-align="center" display="inline-block" border-radius="20px"></asp:TextBox>
        <br />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCardName" Display="Dynamic" ErrorMessage="Allow only character value." ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>&nbsp;

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCardName" Display="Dynamic" ErrorMessage="Not allowed empty field."></asp:RequiredFieldValidator>
            
        <br />
        <br />
        <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" style="border-radius:20px" BorderColor="#FF700F" BackColor="White" />
        <p>
            </p>

                                           

    </form>
</body>
</html>
