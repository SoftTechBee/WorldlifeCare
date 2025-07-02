<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="rptmemberProfileAccess.aspx.cs" Inherits="Admin_rptmemberProfileAccess" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="page-content">
                <!-- start page title -->
                <div class="row">
                    <div class="col-12">
                        <div class="page-title-box d-flex align-items-center justify-content-between">
                            <h4 class="mb-0">Total Member</h4>

                            <%--<div class="page-title-right">
                                <ol class="breadcrumb m-0">
                                    <%-- <li class="breadcrumb-item">
                                        <a href="javascript: void(0);">Minible</a>
                                        </li>
                                        
                                        <li class="breadcrumb-item active">
                                            <a href="Home.aspx">Home</a>/ Total Member
                                        </li>
                                </ol>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <!-- end page title -->

                <!-- Alret-->

                <div class="alert alert-success alert-dismissible fade show" role="alert" id="sccess" runat="server"
                    visible="false">
                    <i class="uil uil-check me-2"></i>
                    <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <div class="alert alert-danger alert-dismissible fade show" role="alert" id="danger" runat="server"
                    visible="false">
                    <i class="uil uil-exclamation-octagon me-2"></i>
                    <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <div class="alert alert-warning alert-dismissible fade show" role="alert" id="warning" runat="server"
                    visible="false">
                    <i class="uil uil-exclamation-triangle me-2"></i>
                    <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <div class="alert alert-info alert-dismissible fade show mb-0" role="alert" id="info" runat="server"
                    visible="false">
                    <i class="uil uil-question-circle me-2"></i>
                    <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

                <!-- end Alert title -->

                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="col-lg-12"></div>

                                       <asp:DropDownList ID="drpstatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpstatus_SelectedIndexChanged" AutoPostBack="true">
                                           <asp:ListItem>All User</asp:ListItem>
                                           <asp:ListItem>Active</asp:ListItem>
                                           <asp:ListItem>Not Active</asp:ListItem>
                                       </asp:DropDownList>
                                           
                                </div>
                                <div class="form-group row"></div>
                                <!----form start---->
                                <div class="form-group row">
                                    <label class="control-label col-lg-3 col-md-3 col-xs-6">Enter UserName</label>
                                    <label class="control-label col-lg-3 col-md-3 col-xs-6">Select FromDate</label>
                                    <label class="control-label col-lg-3 col-md-3 col-xs-6">Select ToDate</label>
                                </div>
                                <br />
                                <div class="form-group row">
                                    <div class="col-lg-3 col-md-3 col-xs-6">
                                        <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server"
                                            placeholder="Enter UserName"></asp:TextBox>
                                    </div>
                                    <div class="ccol-lg-3 col-md-3 col-xs-6">
                                        <div class="input-group date" id="datetimepicker6">
                                            <asp:TextBox ID="txtfromdate" class="form-control" type="date"
                                                runat="server" placeholder="Select Form  Date "></asp:TextBox>
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-xs-6">
                                        <div class="input-group date" id="datetimepicker7">
                                            <asp:TextBox ID="txttodate" class="form-control" type="date" runat="server"
                                                placeholder="Select TO  Date "></asp:TextBox>
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-2 col-xs-6 col-lg-3">
                                        <asp:Button ID="btnSeach" runat="server" Text="Search" Height="60px"
                                            Width="150px" CssClass="btn btn-block btn-success"
                                            OnClick="btnsearch_Click" />
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row">
                                    <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow: auto">
                                        <table id="example1" class="table table-bordered table-striped table-hover">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                     <%--<th>Investment</th>--%>
                                                     <%--<th>Withdraw</th>--%>
                                                    <th>Go to His Panel</th>
                                                    <th>Login-Status</th>
                                                    <th>UserName</th>
                                                    <th>Name</th>
                                                    <th>Sponser</th>
                                                    <th>Status</th>
                                                    <th>Daily ROI(%)</th>
                                                    <th>Mobile</th>
                                                    <th>Email</th>
                                                    <th>Password</th>
                                                    <th>DateOfJoining</th>

                                                   
                                                    <th>Change Password</th>
                                                    <%--<th>Change Tran Password</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server"
                                                    OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%# Container.ItemIndex+1 %>
                                                            </td>

                                                         <%--   <td>
                                                                <asp:Button ID="btnactive" runat="server" Text="Investment!"
                                                                    CssClass="btn  btn-block  btn-success"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="Investment" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnwithdraw" runat="server" Text='<%#Eval("Withdrawstatus") %>'
                                                                    CssClass="btn  btn-block  btn-info"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="Withdraw" />
                                                            </td>
                                                         --%>   <td>
                                                                <asp:Button ID="Button1" runat="server" Text="Go!"
                                                                    CssClass="btn  btn-block  btn-warning"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="View" />
                                                            </td>
                                                              <td>
                                                                <asp:Button ID="Button21" runat="server" Text='<%# remark(Eval("Loginstatus")) %>'
                                                                    CssClass="btn  btn-block  btn-warning"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="Block" />
                                                            </td>
                                                            <td>
                                                                <%#Eval("username") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("name") %>
                                                            </td> 
                                                            <td>
                                                                <%#Eval("reffid") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("status") %>
                                                            </td> 
                                                            <td>
                                                                <%#Eval("ROI") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("MObile") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("email") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Password") %>
                                                            </td>
                                                            <td>
                                                                <%#DataBinder.Eval(Container.DataItem, "dateofjoining"
                                                                    , "{0:dd/MM/yyyy}" )%>
                                                            </td>

                                                           
                                                            <td>
                                                                <asp:Button ID="Button11" runat="server" Height="50px"
                                                                    Width="140px" Text="Password!"
                                                                    CssClass="btn  btn-block  btn-success"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="Pass" />
                                                            </td>
                                                           <%-- <td>
                                                                <asp:Button ID="Button111" runat="server" Height="50px"
                                                                    Width="170px" Text="Tran-Password!"
                                                                    CssClass="btn  btn-block  btn-danger"
                                                                    CommandArgument='<%#Eval("username") %>'
                                                                    CommandName="Transpass" />
                                                            </td>--%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                            <%-- <tfoot>
                                                <tr>
                                                    <th>#</th>
                                                    <th></th>

                                                    <th>Total</th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                                </tfoot>
                                                --%>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>

        <!-- page script -->
    </asp:Content>