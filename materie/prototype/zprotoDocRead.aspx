<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zprotoDocRead.aspx.cs" Inherits="zonaRiservata_zprotoDocRead" %>
<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>
<%@ Register src="../tools/PageLengthManager.ascx" tagname="PageLengthManager" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

             <table id="tblImpaginazione">
                <tr align="center">
                    <td align="center">

                        <uc1:Timbro ID="Timbro1" runat="server" />

                    </td>
                </tr>
            </table> 

        <table align="center">
            <tr align="center">
                <td align="center">
                    <asp:GridView ID="grdDatiPaginati" runat="server" AutoGenerateColumns="true"></asp:GridView>
                </td>
            </tr>

                <tr align="center">
                    <td align="center">
                        <!--  LoginSquareClient -->
                        <uc2:PageLengthManager ID="PageLengthManager1" runat="server" />
                    </td>
                </tr>

                <tr align="center">
                    <td align="center">
                        <asp:Panel ID="pnlPageNumber" runat="server" Visible="true" align="center"  style="position:relative; left: 0px; top: 0px;" Width="" >
                        <br /><br />
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>

        </table>
    
    </div>
    </form>
</body>
</html>
