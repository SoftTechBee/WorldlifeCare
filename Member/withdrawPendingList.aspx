<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="withdrawPendingList.aspx.cs" EnableEventValidation="true" Inherits="Admin_withdrawPendingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <!-- Danger Alert -->
    <div class="alert alert-danger alert-dismissible text-white bg-danger alert-label-icon fade show" id="danger" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbdanger" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <!-- Success Alert -->
    <div class="alert alert-success alert-dismissible text-white bg-success alert-label-icon fade show" id="success" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbsuccess" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <!-- Warning Alert -->
    <div class="alert alert-warning alert-dismissible text-white bg-warning alert-label-icon fade show" id="warning" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbwarning" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <!-- Info Alert -->
    <div class="alert alert-info alert-dismissible text-white bg-info alert-label-icon fade show" id="info" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbinfo" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Withdraw History</h4>
            </div>
        </div>
    </div>

    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="card-body">
            <div class="form-horizontal">
                <div class="form-group row align-items-center mb-3">
                    <div class=" col-sm-offset-4 col-sm-10">
                    </div>
                    <div class=" col-sm-2">
                        <asp:Button ID="btnExportToExcel" CssClass="btn btn-block btn-success" Text="ExportToExcel" OnClick="btnExportToExcel_Click" runat="server" />
                    </div>
                </div>


                <div class="form-group row align-items-center mb-3">
                    <div class="col-sm-12" style="overflow: auto;">
                        <table class="table table-bordered table-hover table-responsive table-striped">
                            <thead class="table-danger">
                                <tr>
                                    <th>Sn.</th>
                                    <th>Member</th>
                                    <th>Amount</th>
                                    <th>Admin Charge</th>
                                    <th>TDS</th>
                                    <th>Tour Deductions</th>
                                    <th>Purchase Deductions</th>
                                    <th>Payout Transfer</th>
                                    <th>DateRequest</th>
                                    <th>DateAction</th>
                                    <%--<th>Remark</th>--%>
                                    <th>Status</th>
                                    <%--<th>Transaction </th>--%>
                                </tr>
                            </thead>

                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Container.ItemIndex+1 %> </td>
                                        <td>
                                            <asp:Label ID="lbuname" runat="server" Text='<%#Eval("username") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lbamt" runat="server" Text='<%#Eval("Amount") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("AdminCharge") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("TDS") %>'></asp:Label></td>
                                          <td>
                                            <asp:Label ID="Label1112" runat="server" Text='<%#Eval("PurchaseDeduction") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Payout") %>'></asp:Label></td>
                                        <td><%#DataBinder.Eval(Container.DataItem, "DOR", "{0:dd/MM/yy}")%></td>
                                        <td><%#DataBinder.Eval(Container.DataItem, "DOA", "{0:dd/MM/yy}")%></td>
                                        <%--<td><%#Eval("remark") %></td>--%>
                                        <td><%#Eval("status") %></td>
                                        <%--<td><%#Eval("TransactionID") %></td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

