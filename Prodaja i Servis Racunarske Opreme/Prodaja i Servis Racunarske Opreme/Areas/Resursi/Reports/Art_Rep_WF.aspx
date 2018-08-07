<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Art_Rep_WF.aspx.cs" Inherits="Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Reports.Art_Rep_WF" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="498px" Width="798px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
