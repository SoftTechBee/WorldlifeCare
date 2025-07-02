<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Bankmaster.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

       <div class="content-body">
            <!-- Content -->
                       <div class="container-fluid">
    <!-- Danger Alert -->
    <div class="alert alert-danger alert-dismissible text-white bg-danger alert-label-icon fade show" id="info" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbinfo" runat="server" Text="Something went Wrong !!! Please Try Again"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h2 class="mb-sm-0">Payment Mode Detail</h2>
            </div>
        </div>
    </div>

    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="form-horizontal">
            <div class="card-body">
                <%--<div class=" form-group row">
                    <div class="col-lg-12">
                        <div class="input-group input-group-sm">
                            <asp:TextBox ID="txtsearchuname" CssClass="form-control" placeholder="Enter User Name" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnsearch" runat="server" Text="Go!" OnClick="btnsearch_Click" CssClass="btn btn-info btn-flat " />
                            </span>
                        </div>
                    </div>
                </div>--%>

                <div class="form-group row mb-5">
                    <label class="control-label col-lg-2">Payment Mode</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="drpBank" runat="server" OnSelectedIndexChanged="drpBank_SelectedIndexChanged" AutoPostBack="true" class="form-control">
                            <asp:ListItem Value="-1">---- Select ------</asp:ListItem>
                            <asp:ListItem Value="0">UPI</asp:ListItem>
                           
                            <asp:ListItem Value="1">BANK</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="divupi" runat="server" visible="false" class="form-group row">

                    <label class="control-label  col-lg-2">Payment Address</label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Enter Payment Address"></asp:TextBox>
                    </div>
                    <label class="control-label  col-lg-2">QR Code</label>

                    <div class="col-lg-4">
                        <asp:FileUpload ID="FileUploadChaque" runat="server" ClientIDMode="Static" onchange="this.form.submit()" />
                        <input type="hidden" runat="server" id="hndqr" />
                        <div class="col-lg-6">
                            <img src="../images/PhotoDemi.jpg" runat="server" id="ImgQR" style="width: 50%" />
                        </div>
                    </div>
                </div>

                <div id="divbank" runat="server" visible="false" class="form-group row">
                    <label class="control-label mb-3 col-lg-2">Bank Name</label>
                    <div class="col-lg-4 mb-3">
                        <asp:TextBox ID="txtbankname" runat="server" class="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                    </div>

                    <label class="control-label mb-3 col-lg-2">Branch Name</label>
                    <div class="col-lg-4 mb-3">
                        <asp:TextBox ID="txtbranch" runat="server" class="form-control" placeholder="Enter Branch Name"></asp:TextBox>
                    </div>

                    <label class="control-label mb-3 col-lg-2">Holder Name</label>
                    <div class="col-lg-4 mb-3">
                        <asp:TextBox ID="txtholdername" runat="server" class="form-control" placeholder="Enter Holder Name"></asp:TextBox>
                    </div>

                    <label class="control-label mb-3 col-lg-2">Account Number</label>
                    <div class="col-lg-4 mb-3">
                        <asp:TextBox ID="txtaccountnumber" runat="server" class="form-control" placeholder="Enter Account Number"></asp:TextBox>
                    </div>

                    <label class="control-label mb-3  col-lg-2">IFSC Code</label>
                    <div class="col-lg-4 mb-3">
                        <asp:TextBox ID="txtifsc" runat="server" class="form-control" placeholder="Enter IFSC Code"></asp:TextBox>
                    </div>
                </div>

                <div class="card-footer">
                    <center>
                        <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Validate();" runat="server" Text="Save" Width="200px" CssClass=" btn btn-success btn-flat btn-lg" />
                    </center>
                </div>

                <div class="  form-group row">
                    <div class="col-lg-12" style="overflow:auto">
                        <table class="table table-hover table-responsive ">
                            <thead class="table-danger">
                                <tr>
                                    <th>Sn.</th>
                                    <th>Payment Mode </th>
                                    <th>Bank Name </th>
                                    <th>Bank Branch </th>
                                    <th>Account Number</th>
                                    <th>Holder Name </th>
                                    <th>IFSC </th>
                                    <th>ID</th>
                                    <th>QR Code</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex+1 %></td>
                                        <td>
                                            <asp:Label ID="PaymentMode" runat="server" Text='<%#Eval("PaymentMode") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="bank" runat="server" Text='<%#Eval("BankName") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Branch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="AccountNumber" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="HolderName" runat="server" Text='<%#Eval("HolderName") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="IFSC" runat="server" Text='<%#Eval("IFSC") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="UPI" runat="server" Text='<%#Eval("UPI") %>'></asp:Label></td>
                                        <td>
                                            <img src='<%#Eval("QRCode") %>' height="50" width="100" /></td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="Delete" CommandArgument='<%#Eval("Bid") %>' CommandName="Delete" CssClass="btn btn-success bg-gradient" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </div>
        </div>
    </div>
</asp:Content>

