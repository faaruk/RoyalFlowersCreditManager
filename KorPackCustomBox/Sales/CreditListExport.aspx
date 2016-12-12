<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreditListExport.aspx.cs" MasterPageFile="~/MasterPage.master"
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: "dd.mm.yyyy"
            }).on('changeDate', function (e) {
                $(this).datepicker('hide');
            });

            $('#btnSave').click(function (e) {
                var isValid = true;
                $('input[type="text"]').each(function () {
                    if ($.trim($(this).val()) == '') {
                        isValid = false;
                        $(this).css({
                            "border": "1px solid red",
                            "background": "#FFCECE"
                        });
                    }
                    else {
                        $(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
                if (isValid == false)
                    e.preventDefault();
                else
                    alert('Thank you for submitting');
            });
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel panel-primary space-10">
            <div class="panel-heading">
                <h3 class="panel-title">Export Credit</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-10">
                        <asp:Label ID="lblresult" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="col-md-4">
                        <label class="control-label">From Date:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtFromDate" class="form-control input-sm datepicker" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="col-md-4">
                        <label class="control-label">To Date:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtToDate" class="form-control input-sm datepicker" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <div class="col-md-5">
                    </div>
                    <div class="col-md-7">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" Width="100"
                            runat="server" Text="Export" OnClick="btnSearch_Click"/>
                    </div>
                </div>
                <%--      </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
</asp:Content>
