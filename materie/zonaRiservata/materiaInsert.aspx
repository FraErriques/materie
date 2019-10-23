<%@ Page Language="C#" AutoEventWireup="true" CodeFile="materiaInsert.aspx.cs" Inherits="zonaRiservata_materiaInsert" %>

<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inserimento di una nuova Materia</title>
</head>
<body style="background-color:Silver">
    <form id="frmInsertMateria" runat="server">
    

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


            <asp:GridView ID="grdMaterie" runat="server" AutoGenerateColumns="false" Width="60%" HeaderStyle-BackColor="Bisque" HeaderStyle-Font-Bold="true">
                <Columns>
                    <asp:BoundField DataField="id" Visible="false"  />
                    <asp:BoundField DataField="nomeMateria"  HeaderText=" Elenco delle Materie attualmente censite" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="Beige" ItemStyle-BorderColor="AntiqueWhite"  ></asp:BoundField>
                </Columns>
            </asp:GridView>



        <asp:TextBox ID="txtMateriaInsert" runat="server" TextMode="SingleLine" Width="717px" Text=""></asp:TextBox>
        <asp:Button ID="btnMateriaInsert" runat="server" Text="Insert" OnClick="btnMateriaInsert_Click" />
        <asp:Label ID="lblMateriaInsert" runat="server" Text=""></asp:Label>


    </form>
</body>
</html>
