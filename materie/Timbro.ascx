<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Timbro.ascx.cs" Inherits="Timbro" %>
<asp:Panel id="tblTimbro" runat="server" style="position:relative; background-color:#99C68E" width="100%">

    <table>
    <tr align="center">
    

        <td width="16%">
            <asp:HyperLink id="hplAutoreLoad" runat="server" Text=" Consultazione Autori per Nominativo e Note ed accesso all'inserimento documenti, sulla chiave doppia Autore-Materia "
                NavigateUrl="~/zonaRiservata/autoreLoad.aspx"></asp:HyperLink>
        </td>
        <!-- -->
        <td width="16%">
            <asp:HyperLink id="hplQueryDocumento" runat="server" Text=" Consultazione Documenti, mediante scelte molteplici su Abstract-Documento, Autore, Materia "
            NavigateUrl="~/zonaRiservata/queryDocumento.aspx"></asp:HyperLink>
        </td>
        <!-- -->        
        <td width="10%"></td>
        <!-- -->
         <asp:Panel ID="pnlInsert" runat="server" Visible="false" >
            <td width="16%">
                <asp:HyperLink id="hplAutoreInsert" runat="server" Text=" Inserimento Autore "
                    NavigateUrl="~/zonaRiservata/autoreInsert.aspx"></asp:HyperLink>
            </td>
            <!-- -->      
            <td width="16%">
                <asp:HyperLink id="hplMateriaInsert" runat="server" Text=" Inserimento Materia "
                NavigateUrl="~/zonaRiservata/materiaInsert.aspx"></asp:HyperLink>
            </td>
            <!--  accesso solo da AutoreLoad, mettendo in Sessione la chiave doppia Autore-Materia
            <td width="16%">
                <asp:HyperLink id="hplDocInsert" runat="server" Text=" Inserimento Documento "
                NavigateUrl="~/zonaRiservata/docMultiInsert.aspx"></asp:HyperLink>
            </td>
            -->
            <!-- -->

         </asp:Panel>

        <td>
            <asp:Panel  ID="pnlAdminLinks" runat="server" Visible="false">
                <table>
                    <tr align="center"  >
                        <td width="16%">
                            <asp:HyperLink id="hplPrimes" runat="server" Text="Primes"
                                NavigateUrl="~/zonaRiservata/PrimeDataGrid.aspx"></asp:HyperLink>
                        </td>
                        <!-- -->
                        <td width="16%">
                            <asp:HyperLink id="hplLogViewerWeb" runat="server" Text="Log Viewer Web"
                                NavigateUrl="~/zonaRiservata/LogViewerWeb.aspx"></asp:HyperLink>
                        </td>
                        <!-- -->
                    </tr>
                </table>
            </asp:Panel >
        </td>

        <td width="16%">
            <asp:HyperLink id="hplChangePwd" runat="server" Text=" Cambio Password"
                NavigateUrl="~/zonaRiservata/changePwd.aspx" ></asp:HyperLink>
        </td>
        <!-- -->
        <td width="16%">
            <asp:Button id="btnLogout" runat="server" Text=" logout"
                 onclick="btnLogout_Click"></asp:Button>
        </td>
        <!-- -->
        <td width="16%">
            <asp:Image ID="imgLogo" runat="server" ImageAlign="Right" ImageUrl="~/img/logo.bmp" />
        </td>
        <!-- -->
    </tr>
    </table>
    
</asp:Panel>
<asp:Label ID="lblStato" runat="server" BackColor="#66FF66" Font-Bold="False" Font-Italic="True" Font-Size="Large" Width="100%" ></asp:Label>
