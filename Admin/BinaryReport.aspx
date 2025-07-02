<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="BinaryReport.aspx.cs" Inherits="User_rptLevelIncome" %>

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
                <h4 class="mb-sm-0">Binary Report</h4>
            </div>
        </div>
    </div>
    <hr />
    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="card-body">


      <div class=" form-group row">
                   <div class="col-lg-3 col-md-3 col-xs-6 ">

                     <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
          
                </div>
  
                 <div class="col-md-2 col-xs-6 col-lg-3">
      
            <asp:Button ID="btnSeach" runat="server" Text="Search" Height="40px" Width="150px" CssClass="btn btn-block btn-success"   OnClick="btnSeach_Click"/>

      </div>
</div>

            <div class="form-group row align-items-center mb-3">
                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow: auto;">
                    <table id="example1" class="table table-bordered table-striped table-hover ">
                       <thead class="table-success">
    <tr>
        <th>Sn.</th>
        <th>Member</th>
        <th>Remark</th>
        <th>Issue Date</th>
       <%-- <th>Nature</th>--%>
        <th>Income</th>
        <th>Paid</th>
        <%--<th>Lapse</th>--%>
        <%--<th>Carry Left</th>--%>
        <%--<th>Carry Right</th>--%>
    </tr>
</thead>
<tbody>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr>
                <td><%# Container.ItemIndex + 1 %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("Remark") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "IssueDate", "{0:dd/MM/yyyy}") %></td>
            <%--    <td><%# Eval("Nature") %></td>--%>
                <td><%# Eval("Amount") %></td>

                <td><%# Eval("Paid") %></td>
               <%-- <td><%# Eval("Lapse") %></td>
                <td><%# Eval("CarryLeft") %></td>
                <td><%# Eval("CarryRight") %></td>--%>
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

