<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreditReport.aspx.cs" Inherits="Sales_CreditReport" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=4.1.10.921, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="950px" Width="100%">
        </telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
