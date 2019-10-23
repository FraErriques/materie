<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autoreInsert.aspx.cs" Inherits="zonaRiservata_autoreInsert" %>

<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Inserimento del profilo personale di un nuovo Autore</title>
        <script language="javascript" type="text/javascript" src="../codiceClient/scripts.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/date.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/LoginSquareClient.js"></script>    
</head>
<body  style="background-color:Green">
    <form id="frmAutoreInsert" runat="server">



            <table id="tblImpaginazione">
                <tr align="center">
                    <td align="center">
                        
                        <uc1:Timbro ID="Timbro1" runat="server" />
                        
                    </td>
                </tr>
                <tr align="center">
                    <td align="center">
                        <!--  LoginSquareClient -->
                    </td>
                </tr>
            </table>




    <table id="tblAutore" >    
        <tr>
            <td>
                <asp:Label ID="lblNominativo" BackColor="GreenYellow" Text="Nominativo dell'Autore " runat="server" ></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNote" BackColor="GreenYellow" Text="Inserire qui ogni annotazione utile riguardo all'Autore " runat="server" ></asp:Label>
            </td>
        </tr>
        <!-- -->
        <tr>
            <td>
                <asp:TextBox ID="txtNominativo" Text="" TextMode="MultiLine" Width="500px" 
                    runat="server"  Height="261px"></asp:TextBox>
            </td>        
            <td>
                <asp:TextBox ID="txtNote" Text="" TextMode="MultiLine" Width="500px" 
                    runat="server" Height="261px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <!-- <asp:DropDownList ID="ddlMaterie" runat="server" AutoPostBack="false"  Width="500px" EnableViewState="true"></asp:DropDownList> -->
            </td>
            <td>
                <asp:Button ID="btnCommint" Text=" Schreiben -/- Commit " runat="server" style="position:relative; float:right; margin-right:20px;" 
                    OnClick="btnCommit_Click" />
            </td>
        </tr>
        <!-- -->
        <tr>
            <td></td>
            <td></td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="lblResult" runat="server" Text="" ></asp:Label>
            </td>
            <td></td>
        </tr>
        
    </table>
    

</form>
</body>
</html>
