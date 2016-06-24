<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrintReport.aspx.cs" Inherits="Sales_Reports" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=4.1.10.921, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="700px" Width="100%">
        </telerik:ReportViewer>
    </div>
</asp:Content>
