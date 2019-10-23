<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tableChecker.aspx.cs" Inherits="zonaRiservata_tableChecker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>


    <table  style="background-color:LightGreen">
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
            <td></td>
            <td>
                <asp:Button ID="btnMaterie" runat="server" OnClick="queryDocumentoByFilter" Text="Query Documento mediante filtri: Autore, Materia, Abstract" />
            </td>
        </tr>
    </table>


    
    </div>
    </form>
</body>
</html>
