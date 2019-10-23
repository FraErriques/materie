<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docMultiRead.aspx.cs" Inherits="zonaRiservata_docMultiRead" %>
<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>
<%@ Register src="../tools/PageLengthManager.ascx" tagname="PageLengthManager" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consultazione dei documenti presenti nella Base Dati, senza filtri (i.e. lista integrale).</title>
        <script language="javascript" type="text/javascript" src="../codiceClient/scripts.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/date.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/LoginSquareClient.js"></script>    
</head>
<body  style="background-color:Silver">
    <form id="frmDefault" runat="server"  defaultbutton="PageLengthManager1$btnRowsInPage" >
    
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
                        <asp:Label ID="lblDeCuius" runat="server" Text="" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>


                <tr align="center">
                    <td align="center">
                        <asp:Button ID="btnPopulateGrid" runat="server" OnClick="doPopulateGrid" Text="Populate Grid"></asp:Button>
                    </td>
                </tr>

  

    <tr align="center">
        <td align="center">
    <asp:GridView ID="grdDatiPaginati" runat="server" AutoGenerateColumns="false" 
                OnRowCommand="grdDatiPaginati_RowCommand" >        
        <Columns>
            <asp:BoundField DataField="id_Documento"  HeaderText="id_Documento" HeaderStyle-Font-Bold="true" Visible="true" ></asp:BoundField>
            <asp:BoundField DataField="nome_Materia" HeaderText="nome_Materia" HeaderStyle-Font-Bold="true" Visible="true" ></asp:BoundField>
            <asp:BoundField DataField="nome_Autore" HeaderText="nome_Autore" HeaderStyle-Font-Bold="true" Visible="true" ></asp:BoundField>
            <asp:BoundField DataField="note_Documento" HeaderText="note_Documento" HeaderStyle-Font-Bold="true" Visible="true" ></asp:BoundField>
            <asp:BoundField DataField="data_Inserimento_Doc" HeaderText="data_Inserimento_Doc" HeaderStyle-Font-Bold="true" Visible="true" ></asp:BoundField>
            
		    <asp:TemplateField HeaderText="Consultazione del singolo documento"  HeaderStyle-Font-Bold="true" ItemStyle-Width="3%">
			    <ItemTemplate>
			    <table>
			        <tr align="center" valign="middle">
			            <td align="center" valign="middle">
		                    <asp:ImageButton ID="btnReadDoc" runat="server" ImageUrl="~/img/btnMailRead.bmp"  Enabled="True" Visible="True" CommandName="GeneralEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_Documento") %>'></asp:ImageButton>
		                </td>
		            </tr>
                </table>					            
			    </ItemTemplate>
		    </asp:TemplateField>					    
					    
		    <asp:TemplateField HeaderText="Update Abstract"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
			    <ItemTemplate>
			    <table>
			        <tr align="center" valign="middle">
			            <td align="center" valign="middle">
		                    <asp:ImageButton ID="btnUpdateAbstract" runat="server" ImageUrl="~/img/btnUpdateAbstract.bmp"  Enabled="True" Visible="True" CommandName="UpdateAbstract" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_Documento") %>'></asp:ImageButton>
		                </td>
		            </tr>
                </table>					            
			    </ItemTemplate>
		    </asp:TemplateField>					    
                        					    
					    
        </Columns>
    </asp:GridView>
</td>
</tr>



                <tr align="center">
                    <td align="center">
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


    </table>

    </form>
</body>
</html>
