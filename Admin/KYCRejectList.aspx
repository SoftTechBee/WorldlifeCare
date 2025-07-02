<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="KYCRejectList.aspx.cs" Inherits="Admin_KYCRejectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Danger Alert -->
    <div class="alert alert-danger alert-dismissible text-white bg-danger alert-label-icon fade show" id="danger" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbdanger" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Rejected KYC List</h4>
            </div>
        </div>
    </div>

    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="form-horizontal">
            <div class="card-body">
                <div class="form-group row row align-items-center mb-3 ">
                    <div class="col-lg-8 col-md-3 col-xs-6 ">
                        <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
                    </div>

                    <div class="col-md-2 col-xs-6 col-lg-3">
                        <asp:Button ID="btnSeach" runat="server" Text="Search" Height="40px" Width="150px" CssClass="btn btn-block btn-success" OnClick="btnSeach_Click" />
                    </div>
                </div>

                <div class=" form-group row row align-items-center mb-3">
                    <div class="col-lg-12" style="overflow: auto;">
                        <table class="table table-bordered table-responsive table-hover" style="display: none!important;">
                            <thead class="table-danger">
                                <tr>
                                    <th>Sn.</th>
                                    <th>User Name</th>
                                    <th>Full Name</th>
                                    <th>Date</th>
                                    <th>KYCStatus</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Container.ItemIndex+1 %> </td>
                                            <td><%#Eval("username") %></td>
                                            <td><%#Eval("fullname") %></td>
                                            <td><%#Eval("requestdate") %></td>
                                            <td><%#Eval("status") %></td>
                                            <td><a href="view.aspx?id=<%#Eval("username") %>">View</a> </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


