<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreditList.aspx.cs" MasterPageFile="~/MasterPage.master"
    Inherits="StringEncodeDecode.UserAuthentication_PrmUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--
    <style type="text/css" title="currentStyle">
        @import "../media/css/demo_page.css";
        @import "../media/css/demo_table_jui.css";
        @import "../examples_support/themes/smoothness/jquery-ui-1.8.4.custom.css";
    </style>
    <script type="text/javascript" language="javascript" src="../media/js/jquery.dataTables.js"></script> --%>
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.2/js/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.11/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.11/css/dataTables.bootstrap.min.css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#<%=grdEmpInfo.ClientID %>').DataTable({
                "scrollX": true
            });
        });

        function ShowReport(id) {
            window.open("CreditReport.aspx?id=" + id);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel panel-primary space-10">
            <div class="panel-heading">
                <h3 class="panel-title">Credit List <a class="specialLink btn btn-primary btn-xs pull-right"
                    href="CreditMaster.aspx"><i class="fa fa-plus"></i>Create New</a></h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div style="text-align: right;">
                    </div>
                </div>
                <br />
                <div class="cleardiv">
                </div>
                <div class="dataGridStyle">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdEmpInfo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-responsive" 
                                AlternatingRowStyle-CssClass="gridviewaltrow"
                                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle CssClass="gridviewaltrow" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CustomerName" SortExpression="CustomerName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BelegunNumber" SortExpression="BelegunNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBelegunNumber" runat="server" Text='<%#Eval("BelegunNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KundenNumber" SortExpression="KundenNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKundenNumber" runat="server" Text='<%#Eval("KundenNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LieferDatum" SortExpression="LieferDatum">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLieferDatum" runat="server" Text='<%#Eval("LieferDatum") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rechnungsdatum" SortExpression="Rechnungsdatum">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRechnungsdatum" runat="server" Text='<%#Eval("Rechnungsdatum") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1"
                                                CommandArgument='<%# Eval("Id") %>'
                                                CommandName="Delete" runat="server">
                                        Delete</asp:LinkButton>

                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyper" Text="Edit" NavigateUrl='<%# String.Format("{0}","CreditMaster.aspx?id=" + Eval("Id")) %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <a class="btn btn-sm btn-primary pull-right btn-xs" href="javascript:void(0);" onclick="ShowReport(<%#Eval("Id")%>);" target="_blank">Show Report</a>
                                            
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <span class="gridviewEmptyMsg">
                                        <%= Resources.Resource.GridViewEmptyDataMsg %>
                                    </span>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="space-10"></div>
                <div id="allHiddenField">
                    <asp:HiddenField ID="txtEmployeeID" runat="server" Value="0" />
                    <asp:HiddenField ID="txtUserID0" runat="server" Value="0" />
                    <asp:HiddenField ID="txtSelectedEmpID" runat="server" Value="0" />
                    <asp:HiddenField ID="hidMenuID" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
