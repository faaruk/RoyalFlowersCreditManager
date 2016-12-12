<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditMaster.aspx.cs" Inherits="Sales_InputFields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: "dd.mm.yyyy"
            }).on('changeDate', function (e) {
                $(this).datepicker('hide');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel panel-primary space-10">
            <div class="panel-heading">
                <h3 class="panel-title">Add Credit</h3>
            </div>
            <div class="panel-body">
                <%-- <asp:UpdatePanel ID="updMain" runat="server">
                    <ContentTemplate>--%>
                <div class="row">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-10">
                        <asp:Label ID="lblresult" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="col-md-4">
                        <label class="control-label">Kundenname:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCustomerName" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4 space-4">
                        <label class="control-label">Adresse:</label>
                    </div>
                    <div class="col-md-8 space-4">
                        <textarea id="txtAddress" class="form-control" rows="3" cols="250" runat="server"></textarea>
                    </div>
                    <div class="col-md-4 space-4">
                        <label class="control-label">Comment:</label>
                    </div>
                    <div class="col-md-8 space-4">
                        <textarea id="txtComment" class="form-control" rows="3" cols="250" runat="server"></textarea>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Posted into Komet:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:CheckBox ID="chkPostedStatus" runat="server" />

                        <%--<asp:DropDownList ID="ddlKometPosted" runat="server" class="form-control input-sm">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                        </asp:DropDownList>--%>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="col-md-4">
                        <label class="control-label">Belegnummer:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtBelegunNumber" class="form-control input-sm" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Kundennummer:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtKundenNumber" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Lieferdatum:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtLieferDatum" class="form-control input-sm datepicker" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Rechnungskorrektur:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtRechnungsdatum" class="form-control input-sm datepicker" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Verkäufer:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtVarkaufer" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Ihre UID:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtIhreUID" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Seite:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="Textbox4" class="form-control input-sm" Text="1" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label">Status:</label>
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlLockStatus" runat="server" class="form-control input-sm">
                            <asp:ListItem Value="1">Locked</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">Not Locked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row space-4">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                        <div class="dataGridStyle">
                            <asp:GridView ID="gvDetails" DataKeyNames="Beschreibung" runat="server"
                                AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
                                ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                OnRowCancelingEdit="gvDetails_RowCancelingEdit"
                                OnRowDeleting="gvDetails_RowDeleting" OnRowEditing="gvDetails_RowEditing"
                                OnRowUpdating="gvDetails_RowUpdating"
                                OnRowCommand="gvDetails_RowCommand"
                                ShowHeaderWhenEmpty="True">
                                <%-- OnRowDataBound="gvDetails_OnRowDataBound" --%>
                                <AlternatingRowStyle BackColor="#6ae1f1" ForeColor="#284775"></AlternatingRowStyle>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" ForeColor="Black"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                <Columns>

                                    <asp:TemplateField HeaderText="Beschreibung">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrBeschreibung" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvBeschreibung" runat="server" ControlToValidate="txtftrBeschreibung" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lange">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLange" Width="50" runat="server" Text='<%#Eval("Lange") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLange" runat="server" Text='<%#Eval("Lange") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrLange" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvLange" runat="server" ControlToValidate="txtftrLange" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Züchter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtZüchter" Width="50" runat="server" Text='<%#Eval("Züchter") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblZüchter" runat="server" Text='<%#Eval("Züchter") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrZüchter" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvZüchter" runat="server" ControlToValidate="txtftrZüchter" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VP">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtVP" Width="50" runat="server" Text='<%#Eval("VP") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblVP" runat="server" Text='<%#Eval("VP") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrVP" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvVP" runat="server" ControlToValidate="txtftrVP" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Menge">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMenge" CssClass="Menge1" Width="50" runat="server" Text='<%#Eval("Menge") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenge" runat="server" Text='<%#Eval("Menge") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrMenge" CssClass="MengeF1" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvMenge" runat="server" ControlToValidate="txtftrMenge" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Einheit">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEinheit" CssClass="Einheit1" Width="50" runat="server" Text='<%#Eval("Einheit") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEinheit" runat="server" Text='<%#Eval("Einheit") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrEinheit" CssClass="EinheitF1" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvEinheit" runat="server" ControlToValidate="txtftrEinheit" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Preis">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPreis" CssClass="Preis1" Width="50" runat="server" Text='<%#Eval("Preis") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreis" runat="server" Text='<%#Eval("Preis") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrPreis" CssClass="PreisF1" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvPreis" runat="server" ControlToValidate="txtftrPreis" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Steuer">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSteuer" Width="50" runat="server" Text='<%#Eval("Steuer") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSteuer" runat="server" Text='<%#Eval("Steuer") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrSteuer" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvSteuer" runat="server" ControlToValidate="txtftrSteuer" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Betrag">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtBetrag" CssClass="Betrag1" Width="50" runat="server" Text='<%#Eval("Betrag") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBetrag" runat="server" Text='<%#Eval("Betrag") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtftrBetrag" CssClass="BetragF1" Width="50" runat="server" />
                                            <asp:RequiredFieldValidator ID="rfvBetrag" runat="server" ControlToValidate="txtftrBetrag" Text="*" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/Save.png" ToolTip="Update" Height="20px" Width="20px" />
                                            <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/return.jpg" ToolTip="Cancel" Height="20px" Width="20px" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/editinfo.png" ToolTip="Edit" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                            <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="imgbtnAdd1" runat="server" ImageUrl="~/Images/Add.png" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton1" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="row">
                    &nbsp;
                </div>
                <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                <div class="row">

                    <div class="col-md-12">
                        <asp:Label ID="lblMessage2" runat="server"></asp:Label>
                        <asp:GridView ID="gvDetails2" DataKeyNames="Beschreibung" runat="server"
                            AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
                            ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                            OnRowCancelingEdit="gvDetails2_RowCancelingEdit"
                            OnRowDeleting="gvDetails2_RowDeleting" OnRowEditing="gvDetails2_RowEditing"
                            OnRowUpdating="gvDetails2_RowUpdating"
                            OnRowCommand="gvDetails2_RowCommand">
                            <AlternatingRowStyle BackColor="#CBEDEF" ForeColor="#284775"></AlternatingRowStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <FooterStyle BackColor="#A8B9CC" ForeColor="Black"></FooterStyle>
                            <HeaderStyle BackColor="#7A6B74" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                            <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                            <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            <Columns>

                                <asp:TemplateField HeaderText="Beschreibung">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrBeschreibung" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvBeschreibung" runat="server" ControlToValidate="txtftrBeschreibung" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lange">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLange" Width="50" runat="server" Text='<%#Eval("Lange") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLange" runat="server" Text='<%#Eval("Lange") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrLange" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvLange" runat="server" ControlToValidate="txtftrLange" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Züchter">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtZüchter" Width="50" runat="server" Text='<%#Eval("Züchter") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblZüchter" runat="server" Text='<%#Eval("Züchter") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrZüchter" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvZüchter" runat="server" ControlToValidate="txtftrZüchter" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VP">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtVP" Width="50" runat="server" Text='<%#Eval("VP") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblVP" runat="server" Text='<%#Eval("VP") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrVP" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvVP" runat="server" ControlToValidate="txtftrVP" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Menge">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMenge" CssClass="Menge2" Width="50" runat="server" Text='<%#Eval("Menge") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMenge" runat="server" Text='<%#Eval("Menge") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrMenge" CssClass="MengeF2" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvMenge" runat="server" ControlToValidate="txtftrMenge" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Einheit">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEinheit" CssClass="Einheit2" Width="50" runat="server" Text='<%#Eval("Einheit") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEinheit" runat="server" Text='<%#Eval("Einheit") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrEinheit" CssClass="EinheitF2" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvEinheit" runat="server" ControlToValidate="txtftrEinheit" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preis">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPreis" CssClass="Preis2" Width="50" runat="server" Text='<%#Eval("Preis") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreis" runat="server" Text='<%#Eval("Preis") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrPreis" CssClass="PreisF2" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvPreis" runat="server" ControlToValidate="txtftrPreis" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Steuer">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSteuer" Width="50" runat="server" Text='<%#Eval("Steuer") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSteuer" runat="server" Text='<%#Eval("Steuer") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrSteuer" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvSteuer" runat="server" ControlToValidate="txtftrSteuer" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Betrag">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBetrag" CssClass="Betrag2" Width="50" runat="server" Text='<%#Eval("Betrag") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBetrag" runat="server" Text='<%#Eval("Betrag") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrBetrag" CssClass="BetragF2" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvBetrag" runat="server" ControlToValidate="txtftrBetrag" Text="*" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/Save.png" ToolTip="Update" Height="20px" Width="20px" />
                                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/return.jpg" ToolTip="Cancel" Height="20px" Width="20px" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/editinfo.png" ToolTip="Edit" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="imgbtnAdd2" runat="server" ImageUrl="~/Images/Add.png" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton2" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="row">
                    &nbsp;
                </div>
                <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                <div class="row">

                    <div class="col-md-12">
                        <asp:Label ID="lblMessage3" runat="server"></asp:Label>
                        <asp:GridView ID="gvDetails3" DataKeyNames="Beschreibung" runat="server"
                            AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
                            ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                            OnRowCancelingEdit="gvDetails3_RowCancelingEdit"
                            OnRowDeleting="gvDetails3_RowDeleting" OnRowEditing="gvDetails3_RowEditing"
                            OnRowUpdating="gvDetails3_RowUpdating"
                            OnRowCommand="gvDetails3_RowCommand">
                            <AlternatingRowStyle BackColor="#F7C1E7" ForeColor="#284775"></AlternatingRowStyle>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <FooterStyle BackColor="#DAE1E9" ForeColor="Black"></FooterStyle>
                            <HeaderStyle BackColor="#8199B4" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                            <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                            <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            <Columns>

                                <asp:TemplateField HeaderText="Beschreibung">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeschreibung" runat="server" Text='<%#Eval("Beschreibung") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrBeschreibung" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvBeschreibung" runat="server" ControlToValidate="txtftrBeschreibung" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lange">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLange" Width="50" runat="server" Text='<%#Eval("Lange") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLange" runat="server" Text='<%#Eval("Lange") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrLange" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvLange" runat="server" ControlToValidate="txtftrLange" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Züchter">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtZüchter" Width="50" runat="server" Text='<%#Eval("Züchter") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblZüchter" runat="server" Text='<%#Eval("Züchter") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrZüchter" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvZüchter" runat="server" ControlToValidate="txtftrZüchter" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VP">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtVP" Width="50" runat="server" Text='<%#Eval("VP") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblVP" runat="server" Text='<%#Eval("VP") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrVP" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvVP" runat="server" ControlToValidate="txtftrVP" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Menge">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMenge" CssClass="Menge3" Width="50" runat="server" Text='<%#Eval("Menge") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMenge" runat="server" Text='<%#Eval("Menge") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrMenge" CssClass="MengeF3" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvMenge" runat="server" ControlToValidate="txtftrMenge" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Einheit">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEinheit" CssClass="Einheit3" Width="50" runat="server" Text='<%#Eval("Einheit") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEinheit" runat="server" Text='<%#Eval("Einheit") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrEinheit" CssClass="EinheitF3" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvEinheit" runat="server" ControlToValidate="txtftrEinheit" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preis">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPreis" CssClass="Preis3" Width="50" runat="server" Text='<%#Eval("Preis") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreis" runat="server" Text='<%#Eval("Preis") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrPreis" CssClass="PreisF3" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvPreis" runat="server" ControlToValidate="txtftrPreis" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Steuer">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSteuer" Width="50" runat="server" Text='<%#Eval("Steuer") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSteuer" runat="server" Text='<%#Eval("Steuer") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrSteuer" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvSteuer" runat="server" ControlToValidate="txtftrSteuer" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Betrag">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBetrag" CssClass="Betrag3" Width="50" runat="server" Text='<%#Eval("Betrag") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBetrag" runat="server" Text='<%#Eval("Betrag") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtftrBetrag" CssClass="BetragF3" Width="50" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvBetrag" runat="server" ControlToValidate="txtftrBetrag" Text="*" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/Save.png" ToolTip="Update" Height="20px" Width="20px" />
                                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/return.jpg" ToolTip="Cancel" Height="20px" Width="20px" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/editinfo.png" ToolTip="Edit" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" Height="20px" Width="20px" Enabled='<%# Eval("Beschreibung") != null && !String.IsNullOrEmpty(Eval("Beschreibung").ToString()) %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="imgbtnAdd3" runat="server" ImageUrl="~/Images/Add.png" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton3" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <div class="col-md-5">
                    </div>
                    <div class="col-md-7">

                        <asp:Button ID="btnSave" CssClass="btn btn-primary" Width="100"
                            runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" CssClass="btn btn-primary" Width="100"
                            runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:HiddenField ID="hidLockStatus" runat="server" Value="0" />
                    </div>
                </div>
                <%--      </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('input.Menge1').blur(function () {
                Calculate1();
            });
            $('input.Menge2').blur(function () {
                Calculate2();
            });
            $('input.Menge3').blur(function () {
                Calculate3();
            });

            $('input.Preis1').blur(function () {
                Calculate1();
            });
            $('input.Preis2').blur(function () {
                Calculate2();
            });
            $('input.Preis3').blur(function () {
                Calculate3();
            });

            $('input.Einheit1').blur(function () {
                Calculate1();
            });
            $('input.Einheit2').blur(function () {
                Calculate2();
            });
            $('input.Einheit3').blur(function () {
                Calculate3();
            });

            $('input.PreisF1').blur(function () {
                CalculateF1();
            });
            $('input.PreisF2').blur(function () {
                CalculateF2();
            });
            $('input.PreisF3').blur(function () {
                CalculateF3();
            });

            $('input.MengeF1').blur(function () {
                CalculateF1();
            });
            $('input.MengeF2').blur(function () {
                CalculateF2();
            });
            $('input.MengeF3').blur(function () {
                CalculateF3();
            });

            $('input.EinheitF1').blur(function () {
                CalculateF1();
            });
            $('input.EinheitF2').blur(function () {
                CalculateF2();
            });
            $('input.EinheitF3').blur(function () {
                CalculateF3();
            });
        });

        function Calculate1() {
            $("#ctl00_ContentPlaceHolder1_gvDetails").find('tr').each(function () {
                var iQty = $('input.Menge1').val();
                var Qty = $('input.Einheit1').val();
                var unit = $('input.Preis1').val();
                var tot =iQty * Qty * unit;
                $('input.Betrag1').val(tot);
            });
        }

        function Calculate2() {
            $("#ctl00_ContentPlaceHolder1_gvDetails2").find('tr').each(function () {
                var iQty = $('input.Menge2').val();
                var Qty = $('input.Einheit2').val();
                var unit = $('input.Preis2').val();
                var tot = iQty * Qty * unit;
                $('input.Betrag2').val(tot);
            });
        }

        function Calculate3() {
            $("#ctl00_ContentPlaceHolder1_gvDetails3").find('tr').each(function () {
                var iQty = $('input.Menge3').val();
                var Qty = $('input.Einheit3').val();
                var unit = $('input.Preis3').val();
                var tot =iQty * Qty * unit;
                $('input.Betrag3').val(tot);
            });
        }

        function CalculateF1() {

            $("#ctl00_ContentPlaceHolder1_gvDetails").find('tr').each(function () {
                var iQty = $('input.MengeF1').val();
                var Qty = $('input.EinheitF1').val();
                var unit = $('input.PreisF1').val();
                var tot = iQty * Qty * unit;
                $('input.BetragF1').val(tot);
            });
        }

        function CalculateF2() {

            $("#ctl00_ContentPlaceHolder1_gvDetails2").find('tr').each(function () {
                var iQty = $('input.MengeF2').val();
                var Qty = $('input.EinheitF2').val();
                var unit = $('input.PreisF2').val();
                var tot =iQty * Qty * unit;
                $('input.BetragF2').val(tot);
            });
        }

        function CalculateF3() {

            $("#ctl00_ContentPlaceHolder1_gvDetails3").find('tr').each(function () {
                var iQty = $('input.MengeF3').val();
                var Qty = $('input.EinheitF3').val();
                var unit = $('input.PreisF3').val();
                var tot = iQty * Qty * unit;
                $('input.BetragF3').val(tot);
            });
        }

    </script>
</asp:Content>

