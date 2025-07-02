<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="WalletRecharge.aspx.cs" Inherits="User_WalletRecharge" %>

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
                <h4 class="mb-sm-0">Deposit Donations</h4>
            </div>
        </div>
    </div>

    <input type="text" name="link" id="myInput" runat="server" value="" style="opacity: 0;">

    <div class="card" style="box-shadow: 5px 5px 15px 0px rgba(0,0,0,0.35);">
        <div class="card-body">
            <div class="form-horizontal">
                <div class="form-group row" style="text-align: right">
                    <a id="divkyc" runat="server" visible="false" href="KYCDOC.aspx"><span class="card-title text-danger"><b>KYC Update: </b></span><b>Click</b></a>
                </div>
                <!----form start---->

                <div class="col-lg-12">
                    <div class="form-group row align-items-center mb-3">
                        <label class="control-label col-lg-2">Member ID </label>
                        <div class="col-lg-6">
                            <asp:TextBox ReadOnly="true" ID="lbusername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <div class="form-group row align-items-center mb-3">
                        <label class="control-label  col-lg-2">Amount (INR.)<span class="text-danger">*</span></label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtAmount" runat="server" placeholder="Enter Fund Amount in INR" CssClass=" form-control" required=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row align-items-center mb-3">
                        <label class="control-label  col-lg-2">Payment Mode</label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="drpPaymentMode" DataTextField="PaymentMode" DataValueField="PaymentMode" OnSelectedIndexChanged="drpbankname_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div id="divbank" runat="server" visible="false" class="form-group row align-items-center mb-3">
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

                    <div id="div1" runat="server" visible="false" class="form-group row align-items-center mb-3">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label   col-lg-2">QR CODE</asp:Label>
                        <div class="col-sm-6">
                            <img src="loo1aa.png" id="ImgQR" runat="server" style="width: 100%; border: solid 2px black;" />
                        </div>
                    </div>

                    <div id="divupi" runat="server" visible="false" class="form-group row align-items-center mb-3 ">
                        <asp:Label ID="lbpaymentmode" runat="server" CssClass="control-label  col-lg-2"></asp:Label>
                        <div class="col-lg-4" style="display: flex">
                            <asp:Label ID="UPIID" ReadOnly="true" CssClass="form-control" runat="server"></asp:Label>
                           <%-- <span class="input-group-text show-pass border-warning">
                                <i id="showpassword" onclick="script: myFunction();" >Copy</i>
                            </span>--%>
                            <%--<span class="fs-14" style="margin-top:8px"><a href="#" onclick="script: myFunction();"  class="input-group-addon" data-color-class="primary" data-animate=" animated fadeIn" data-toggle="tooltip" data-original-title="copy" data-placement="top"><i class="fa fa-copy text-danger "></i></a></span>--%>
                            
                        </div>
                    </div>

                    <asp:HiddenField runat="server" ID="hndqr" />

                    <div class="form-group row align-items-center mb-3">
                        <label class="control-label  col-lg-2">Transaction ID: </label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Transaction Number" CssClass="form-control"></asp:TextBox>
                        </div>
                    <%--    <label class="control-label  col-lg-2">Payment Date <span class="text-danger">*</span> </label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtdate" runat="server" Type="date" placeholder="Enter Payment Date" CssClass="form-control"></asp:TextBox>
                        </div>--%>
                    </div>

                    <div class="form-group row align-items-center mb-3">
                        <label class="control-label col-lg-2">Upload Transaction Reciept </label>
                        <div class="col-lg-6">
                            <asp:FileUpload ID="FileUpload1" runat="server" ClientIDMode="Static" onchange="this.form.submit()" />
                        </div>
                    </div>

                    <div class="form-group row align-items-center mb-3">
                        <div class="col-lg-8">
                            <asp:Image ID="Image1" runat="server" Height="50%" Width="50%" />
                            <input type="hidden" runat="server" id="hndurl" />
                            <input type="hidden" runat="server" id="hndID" />
                        </div>
                    </div>

                    <div class="form-group row align-items-center mb-3">
                        <div class="col-lg-12">
                            <center>
                                <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Processclick();" runat="server" Text="Request for payment" Width="300px" CssClass=" btn btn-success btn-flat btn-lg" />

                                <%--<asp:Button ID="btncencel" runat="server" OnClick="btncencel_Click" Text="Cancel" Width="200px" CssClass="btn  btn-danger btn-lg btn-flat"  />--%>  
                                
                            </center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

            <script src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
<link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css">
        <script>

            function Processclick() {
                swal({
                    title: "Processing.......!",
                    text: "Note: Do Not press back or close the app? It will close in few seconds.",
                    imageUrl: "../SoftImg/refresh.gif",
                    timer: 2000000,
                    showConfirmButton: false
                });
            }
            function Successclick() {
                swal("Successfully!", "You clicked the button!", "success")
            }
        </script>
</asp:Content>
