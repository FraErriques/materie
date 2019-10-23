<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autoreLoad.aspx.cs" Inherits="zonaRiservata_autoreLoad" %>
<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>
<%@ Register src="../tools/PageLengthManager.ascx" tagname="PageLengthManager" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Selezione fra gli Autori e le Materie censiti, per selezione della chiave doppia di inserimento Documento</title>
        <script language="javascript" type="text/javascript" src="../codiceClient/scripts.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/date.js"></script>
        <script language="javascript" type="text/javascript" src="../codiceClient/LoginSquareClient.js"></script>    
</head>
<body  style="background-color:Aqua">
    <form id="frmDefault" runat="server" defaultbutton="PageLengthManager1$btnRowsInPage">

            <table id="tblImpaginazione">
                <tr align="center">
                    <td align="center">
                        <uc1:Timbro ID="Timbro1" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table id="tblChooseChiaveDoppia"  align="left">
                <tr  align="left">
                    <td  align="left">
                        <asp:Label ID="lblNominativoAutore" runat="server" Text="Nominativo Autore: elementi da utilizzare nella ricerca"></asp:Label>
                        <asp:TextBox ID="txtNominativoAutore" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>   
                    </td>
                    <td  align="left">
                        <asp:DropDownList ID="ddlMaterie" runat="server" AutoPostBack="false" ItemStyle-HorizontalAlign="Left" ></asp:DropDownList>
                        <asp:Button ID="btnPublishMateriaFromCombo" runat="server" OnClick="doPublishMateriaFromCombo" Text="Selezione Materia da Combo" />
                        <asp:Button ID="btnAutoriByName" runat="server" OnClick="queryAutoriWithArticoliSuMateria" Text="Query: Autori che hanno articoli sulla Materia selezionata" />
                        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                            OnRowCommand="grdAutorePerMateria_RowCommand" >
                            <Columns>

                                    <asp:BoundField DataField="idAutore"   HeaderText="Id Autore" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" >
                                        <HeaderStyle Font-Bold="True"></HeaderStyle>
                                        <ItemStyle Width="6%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="nomeAutore"  HeaderText="Nominativo Autore" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" >
                                        <HeaderStyle Font-Bold="True"></HeaderStyle>
                                        <ItemStyle Width="6%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="idMateria"   HeaderText="Id Materia" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" >
                                        <HeaderStyle Font-Bold="True"></HeaderStyle>
                                        <ItemStyle Width="6%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="nomeMateria"  HeaderText="Nome Materia" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" >
                                        <HeaderStyle Font-Bold="True"></HeaderStyle>
                                        <ItemStyle Width="6%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Selezione della Materia"   HeaderStyle-Font-Bold="true" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <table>
                                            <tr align="center" valign="middle">
                                                <td align="center" valign="middle">
                                                    <asp:ImageButton ID="btnAddCv" runat="server" ImageUrl="~/img/btnAddDoc.bmp"  Enabled="True" Visible="True" CommandName="AddDocuments" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idMateria") %>'></asp:ImageButton>
                                                </td>
                                            </tr>
                                            </table>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True"></HeaderStyle>
                                        <ItemStyle Width="3%"></ItemStyle>
                                    </asp:TemplateField>

                            </Columns>

                        </asp:GridView>

                    </td><!-- end of column which contains the gridView of AutoreByMateria -->
                </tr>
                <tr  align="left">
                    <td align="left"><!-- in left column: Autore_Abstract -->
                        <asp:Label ID="lblNoteAutore" runat="server" Text="Note sull' Autore: elementi da utilizzare nella ricerca"></asp:Label>
                        <asp:TextBox ID="txtNoteAutore" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnMaterie" runat="server" OnClick="queryAutoriByNominativoNote" Text="Query: Autori by Nominativo & Note" />
                    </td>
                    <td  align="left"><!-- right column empty -->
                    </td>
                </tr>

                <tr  align="left" id="terzaRiga">
                    <td  align="left">

                    


        <asp:GridView ID="grdDatiPaginati" runat="server" AutoGenerateColumns="false" 
        OnRowCommand="grdDatiPaginati_RowCommand" >
            <Columns>
            
            <asp:BoundField DataField="id"   HeaderText="Id Autore" Visible="true" ></asp:BoundField>
            
            <asp:BoundField DataField="nominativo"  HeaderText="Nominativo Autore" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="6%" >
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="6%"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="note" Visible="true"  HeaderText="Considerazioni generali sull' Autore" HeaderStyle-Font-Bold="true"  ItemStyle-Width="60%">
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="60%"></ItemStyle>
            </asp:BoundField>

            <asp:TemplateField HeaderText="Selezione dell' Autore"   HeaderStyle-Font-Bold="true" ItemStyle-Width="3%">
                <ItemTemplate>
                    <table>
                    <tr align="center" valign="middle">
                        <td align="center" valign="middle">
                            <asp:ImageButton ID="btnAddCv" runat="server" ImageUrl="~/img/btnAddDoc.bmp"  Enabled="True" Visible="True" CommandName="AddDocuments" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:ImageButton>
                        </td>
                    </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="3%"></ItemStyle>
            </asp:TemplateField>					    

		    <asp:TemplateField HeaderText="Aggiornamento Note dell'Autore"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
			    <ItemTemplate>
			    <table>
			        <tr align="center" valign="middle">
			            <td align="center" valign="middle">
		                    <asp:ImageButton ID="btnUpdateAbstract" runat="server" ImageUrl="~/img/btnUpdateAbstract.bmp"  Enabled="True" Visible="True" CommandName="UpdateAbstract" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:ImageButton>
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

                <tr>
                    <td>
                            <asp:TextBox ID="txtChiaveMateria" Text="" runat="server" Width="100"></asp:TextBox>
                            <asp:Label ID="lblChiaveMateria" Text=" ID Materia per la chiave doppia" runat="server" Width="200"></asp:Label>
                        <br />
                            <asp:TextBox ID="txtChiaveAutore" Text="" runat="server" Width="100"></asp:TextBox>
                            <asp:Label ID="lblChiaveAutore"  Text=" ID Autore per la chiave doppia " runat="server" Width="200"></asp:Label>
                        <br />
                        <asp:Label ID="lblErroreChiave" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmitDoubleKey" Text="Verifica Chiave Doppia e Inserimento" runat="server" OnClick="verifyDoubleKey"></asp:Button>
                    </td>
                </tr>

                </table> <!-- fine terza ed ultima riga della tabella -->

    </form>
</body>
</html>
