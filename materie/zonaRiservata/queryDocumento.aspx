<%@ Page Language="C#" AutoEventWireup="true" CodeFile="queryDocumento.aspx.cs" Inherits="zonaRiservata_queryDocumento" %>
<%@ Register src="../Timbro.ascx" tagname="Timbro" tagprefix="uc1" %>
<%@ Register src="../tools/PageLengthManager.ascx" tagname="PageLengthManager" tagprefix="uc2" %>
<%@ Register src="../tools/Pager.ascx" tagname="Pager" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>select Documento</title>
</head>
<body style="background-color:LightGreen">
    <form id="frmQueryDocumento" runat="server" defaultbutton="PageLengthManager1$btnRowsInPage">
            <table id="tblImpaginazione">
                <tr align="center">
                    <td align="center"> 
                        <uc1:timbro ID="Timbro1" runat="server" />
                    </td>
                </tr>
                <tr align="center">
                    <td align="center">
                        <!--  LoginSquareClient -->
                        <uc2:PageLengthManager ID="PageLengthManager1" runat="server" />
                    </td>
                </tr>
            </table>

            

    <table  style="background-color:LightGreen"><!-- table predisposizione filtro query -->
        <tr>
            <td  align="left" valign="top">
            <asp:Label ID="lblNominativoAutore" runat="server" Text="Nominativo Autore: elementi da utilizzare nella ricerca"></asp:Label>
            <br />
            <asp:TextBox ID="txtNominativoAutore" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>   
            <br />
            <asp:Label ID="lblNoteOnQuery" runat="server" 
                Text="NB. le condizioni di query, ovvero il filtro che si costruisce in questa pagina <br/> vengono collegate obbligatoriamente in AND con la query-tail presente nella stored, <br/> in quanto essa necessita del connettore AND per evitare il prodotto <br/> cartesiano fra candidati e categorie."></asp:Label>
            </td>
            <td  align="left" valign="top">
                <asp:Label ID="lblDocumentoAbstract" runat="server" Text="Note sul Documento: elementi da utilizzare nella ricerca"></asp:Label>
                <br />
                <asp:TextBox ID="txtDocumentoAbstract" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
            </td>
        </tr>
        <tr  align="left">
            <td  align="left" valign="top"><!-- in left column: Autore_Abstract -->
                <asp:Label ID="lblNoteAutore" runat="server" Text="Note sull' Autore: elementi da utilizzare nella ricerca"></asp:Label>
                <br />
                <asp:TextBox ID="txtNoteAutore" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
            </td>
            <td  align="left" valign="top">
                <asp:Label ID="lblMaterie" runat="server" Text="selezione Materia" Visible="true"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlMaterie" runat="server" AutoPostBack="false" ItemStyle-HorizontalAlign="Left" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblErroreChiave" runat="server" Text="" Visible="true"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnMaterie" runat="server" OnClick="queryDocumentoByFilter" Text="Query Documento mediante filtri: Autore, Materia, Abstract" />
            </td>
        </tr>
    </table>

            

        <asp:GridView ID="grdDatiPaginati" runat="server" AutoGenerateColumns="false" 
        OnRowCommand="grdDatiPaginati_RowCommand" >
            <Columns>
            
            <asp:BoundField DataField="id_Documento" HeaderText="ID Documento" Visible="true"   ItemStyle-Width="3%"  ></asp:BoundField>
            
            <asp:BoundField DataField="nome_Materia"  HeaderText="Materia" HeaderStyle-Font-Bold="true"  Visible="true"  ItemStyle-Width="3%" >
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="3%"></ItemStyle>
            </asp:BoundField>
            
            <asp:BoundField DataField="nome_Autore" Visible="true"  HeaderText="Autore" HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="3%"></ItemStyle>
            </asp:BoundField>
            
            <asp:BoundField DataField="note_Documento" Visible="true"  HeaderText="Considerazioni generali sul Documento" HeaderStyle-Font-Bold="true"  ItemStyle-Width="6%">
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="6%"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="data_Inserimento_Doc" Visible="true"  HeaderText="data inserimento Documento nel db" HeaderStyle-Font-Bold="true"  ItemStyle-Width="6%">
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="6%"></ItemStyle>
            </asp:BoundField>

            <asp:TemplateField HeaderText="Inserimento documento sulla chiave doppia(Materia-Autore) della riga corrente"   HeaderStyle-Font-Bold="true" ItemStyle-Width="6%">
                <ItemTemplate>
                    <table>
                    <tr align="center" valign="middle">
                        <td align="center" valign="middle">
                            <asp:ImageButton ID="btnAddCv" runat="server" ImageUrl="~/img/btnAddDoc.bmp"  Enabled="True" Visible="True" CommandName="AddDocuments" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_Documento") %>'></asp:ImageButton>
                        </td>
                    </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="6%"></ItemStyle>
            </asp:TemplateField>					    

            <asp:TemplateField HeaderText="Consultazione documento"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
                <ItemTemplate>
                    <table>
                        <tr align="center" valign="middle">
                            <td align="center" valign="middle">
                                <asp:ImageButton ID="btnReadCv" runat="server" ImageUrl="~/img/btnMailRead.bmp"  Enabled="True" Visible="True" CommandName="GeneralEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_Documento") %>'></asp:ImageButton>
                            </td>
                        </tr>
                    </table>					            
                </ItemTemplate>
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="3%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Aggiornamento Note del Documento"  HeaderStyle-Font-Bold="true"  ItemStyle-Width="3%">
                <ItemTemplate>
                    <table>
                        <tr align="center" valign="middle">
                            <td align="center" valign="middle">
                                <asp:ImageButton ID="btnUpdateAbstract" runat="server" ImageUrl="~/img/btnUpdateAbstract.bmp"  Enabled="True" Visible="True" CommandName="UpdateAbstract" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_Documento") %>'></asp:ImageButton>
                            </td>
                        </tr>
                    </table>					            
                </ItemTemplate>
                <HeaderStyle Font-Bold="True"></HeaderStyle>
                <ItemStyle Width="3%"></ItemStyle>
            </asp:TemplateField>

            </Columns>
        </asp:GridView>


<asp:Panel ID="pnlPageNumber" runat="server" Visible="true" align="center"  style="position:relative; left: 0px; top: 0px;" Width="" >
<br /><br />
</asp:Panel>



    </form>
</body>
</html>
