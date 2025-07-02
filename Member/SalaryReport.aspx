<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="SalaryReport.aspx.cs" Inherits="User_rptLevelIncome" %>

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

    <div class="row">
        <div class="col-12">
            <div class="card-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Salary Report</h4>
            </div>
        </div>
    </div>
    <hr />
    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="card-body">


            <div class="form-group row align-items-center mb-3">
                <label class="col-lg-2 col-md-2 col-xs-6 ">Select Form  Date </label>
                <div class="col-lg-3 col-md-3 col-xs-6">
                    <asp:TextBox ID="txtfromdate" class="form-control small" required="" type="date" runat="server" placeholder="DD-MM-YYYY"></asp:TextBox>
                </div>

                <label class="col-lg-2 col-md-2 col-xs-6 ">Select TO  Date </label>
                <div class="col-lg-3 col-md-3 col-xs-6 ">
                    <asp:TextBox ID="txttodate" class="form-control small" required="" type="date" runat="server" placeholder="DD-MM-YYYY"></asp:TextBox>
                </div>

                <div class="col-lg-2 col-md-2 col-xs-6 ">
                    <asp:Button ID="btnSeach" runat="server" Text="Search" CssClass="btn btn-primary w-lg small" OnClick="btnSeach_Click" />

                </div>
            </div>

            <div class="form-group row align-items-center mb-3">
                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow: auto;">
                    <table id="example1" class="table table-bordered table-striped table-hover ">
                       <thead class="table-success">
    <tr>
        <th>Sn.</th>
        <th>Member</th>
        <th>Salary</th>
        <th>Amount</th>
        <th>Recognition Remark</th>
        <th>Date</th>
     <%--   <th>Reward</th>
        
        <th>Start Date</th>--%>
        <th>MonthsLeft</th>
        <th>Status</th>
    </tr>
</thead>
<tbody>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr>
                <td><%# Container.ItemIndex + 1 %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("Salary") %></td>
                <td><%# Eval("Amount") %></td>
                <td><%# Eval("Remark") %></td>

                <td><%# DataBinder.Eval(Container.DataItem, "DOA", "{0:dd/MM/yyyy}") %></td>
                <%--<td><%# Eval("Reward") %></td>--%>
                <%--<td><%# DataBinder.Eval(Container.DataItem, "startDate", "{0:dd/MM/yyyy}") %></td>--%>
                
                <td><%# Eval("Term") %></td>
                <td><%# remark(Eval("status")) %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</tbody>

                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

