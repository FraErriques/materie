<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>
<%@ Register src="LoginSquareClient.ascx" tagname="LoginSquareClient" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Base dati di documenti, censiti per Materia e per Autore</title>
        <script language="javascript" type="text/javascript" src="codiceClient/scripts.js"></script>
        <script language="javascript" type="text/javascript" src="codiceClient/date.js"></script>
        <script language="javascript" type="text/javascript" src="codiceClient/LoginSquareClient.js"></script>
</head>
<body onload="Page_Load_OnClient('LoginSquareClient1_txtUser')">
    <form id="frmHome" runat="server" defaultbutton="LoginSquareClient1$itnLogin">
            <table id="tblImpaginazione">
                <tr align="center">
                    <td align="center">
                        
                        <uc1:Timbro ID="Timbro1" runat="server" />
                        
                    </td>
                </tr>
                <tr align="center">
                    <td align="center">

                        <uc2:LoginSquareClient ID="LoginSquareClient1" runat="server" />
                        
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
