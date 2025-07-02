<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="KYC.aspx.cs" Inherits="Member_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <style>
        .row {
            margin-top: 10px !important;
        }
    </style>
       <div class="card-body">
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Update KYC</h4>
            </div>
        </div>
    </div>

    <!-- Danger Alert -->
    <div class="alert alert-success alert-dismissible text-white bg-success alert-label-icon fade show" id="IsVerified" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbIsVerified" runat="server" Text="KYC Verified"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>


    <div class="from-wrapper">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">

                <div class="card">

                    <div class="card-content">
                        <div class="card-body">
                            <div class="mfh-machine-profile">
                                <ul class="nav nav-tabs nav-primary" id="myTab1" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="bank-tab1" data-bs-toggle="tab" href="#bank" role="tab" aria-controls="bank" aria-selected="true">Bank Details</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="adhaar-tab20" data-bs-toggle="tab" href="#adhaar" role="tab" aria-controls="kyc" aria-selected="false">Adhaar Card Details</a>
                                    </li>
                                   
                                    <li class="nav-item">
                                        <a class="nav-link" id="drivingtab" data-bs-toggle="tab" href="#pan" role="tab" aria-controls="profile" aria-selected="false">PanCard Details </a>
                                    </li> 
                                   
                                  
                                </ul>
                                <div class="tab-content ad-content2" id="myTabContent2">
                                    <div class="tab-pane fade show active" id="bank" role="tabpanel">
                                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">

                                            <div id="BankReject" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show">
                                                <strong>KYC</strong>&nbsp;Bank Detils Reject
                                            </div>

                                            <div class="form-group row">
                                                <label for="city" class="col-md-3 col-form-label">Account Type</label>
                                                <div class="col-md-9">
                                                    <select id="AccountType" runat="server" class="select2 form-control select-opt">
                                                        <option value="-1">---Select---</option>
                                                        <option value="Current Account">Current Account</option>
                                                        <option value="Savings Account">Savings Account</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Bank Name</label>
                                                <div class="col-md-9">
                                                    <input id="txtBankName" runat="server" class="form-control" type="text" maxlength="100" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Branch Name</label>
                                                <div class="col-md-9">
                                                    <input id="txtBranchName" runat="server" class="form-control" type="text" maxlength="30" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Account Holder Name</label>
                                                <div class="col-md-9">
                                                    <input id="txtAccountHolderName" runat="server" class="form-control" type="text" maxlength="100" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Account Number</label>
                                                <div class="col-md-9">
                                                    <input id="txtAccountNumber" runat="server" class="form-control" type="text" maxlength="20"
                                                        onkeypress="if ( isNaN(this.value + String.fromCharCode(event.keyCode) )) return false;" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">IFSC Code</label>
                                                <div class="col-md-9">
                                                    <input id="txtIFSC" runat="server" class="form-control" type="text" maxlength="15" style="text-transform: uppercase;" />
                                                </div>
                                            </div>

                                           <%-- <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Google Pay UPI ID</label>
                                                <div class="col-md-9">
                                                    <input id="txtGpay" runat="server" class="form-control" type="text" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Paytm UPI ID</label>
                                                <div class="col-md-9">
                                                    <input id="txtPaytm" runat="server" class="form-control" type="text" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Phone Pay UPI ID</label>
                                                <div class="col-md-9">
                                                    <input id="txtPhonePay" runat="server" class="form-control" type="text" />
                                                </div>
                                            </div>--%>

                                            <asp:FileUpload ID="FilePassbook" runat="server" Style="display: none;" onchange="showimagepreview(this,'imgPassbook')" />
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Upload Passbook Image</label>
                                                <div class="col-md-9 img-chair">
                                                    <img id="imgPassbook" runat="server"
                                                        onclick="getinputimage('FilePassbook');"
                                                        style="width: 150px; height: 150px" src="../SoftImg/NoImage.jpeg" alt="Passbook Image" />
                                                </div>
                                            </div>

                                            <center id="ActionBank" runat="server">
                                                <div class="form-group row mb-0">
                                                    <div class="col-sm-10 offset-sm-2">
                                                        <asp:Button ID="bntBank" runat="server" Text="Submit" CssClass="btn btn-success" OnClientClick="return ValidBank();" OnClick="bntBank_Click" />
                                                        <button class="btn btn-primary" type="button" onclick="BankClear();">Clear</button>
                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="adhaar" role="tabpanel">
                                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                            <div id="AdhaarReject" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show">
                                                <strong>KYC</strong>&nbsp;Adhaar Detils Reject
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Adhaar Card Number</label>
                                                <div class="col-md-9">
                                                    <input id="txtAdhaarNumber" runat="server" class="form-control" type="text"
                                                        maxlength="12" style="text-transform: uppercase;"
                                                        onkeypress="if ( isNaN(this.value + String.fromCharCode(event.keyCode) )) return false;" />
                                                </div>
                                            </div>

                                            <asp:FileUpload ID="FileFrontAdhaar" runat="server" Style="display: none;" onchange="showimagepreview(this,'imgadharfront')" />
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Upload Front Adhaar Image</label>
                                                <div class="col-md-9 img-chair">
                                                    <img id="imgadharfront" runat="server"
                                                        onclick="getinputimage('FileFrontAdhaar');"
                                                        style="width: 150px; height: 150px" src="../SoftImg/NoImage.jpeg" alt="Adhaar Front Image" />
                                                </div>
                                            </div>

                                            <asp:FileUpload ID="FileBackAdhaar" runat="server" Style="display: none;" onchange="showimagepreview(this,'imgadharback')" />
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Upload Back Adhaar Image</label>
                                                <div class="col-md-9 img-chair">
                                                    <img id="imgadharback" runat="server"
                                                        onclick="getinputimage('FileBackAdhaar');"
                                                        style="width: 150px; height: 150px" src="../SoftImg/NoImage.jpeg" alt="Adhaar Back Image" />
                                                </div>
                                            </div>

                                            <center id="ActionAdhaar" runat="server">
                                                <div class="form-group row mb-0">
                                                    <div class="col-sm-10 offset-sm-2">
                                                        <asp:Button ID="btnAdhaar" runat="server" Text="Submit" CssClass="btn btn-success" OnClientClick="return ValidAdhaar();" OnClick="bntAdhaar_Click" />
                                                        <button class="btn btn-primary" type="button" onclick="AdhaarClear();">Clear</button>
                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="pan" role="tabpanel">
                                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">

                                            <div id="PanReject" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show">
                                                <strong>KYC</strong>&nbsp;Pan Detils Reject
                                            </div>

                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Pan Id Number</label>
                                                <div class="col-md-9">
                                                    <input id="txtPanCardNumber" runat="server" class="form-control" type="text" maxlength="10" style="text-transform: uppercase;" />
                                                </div>
                                            </div>

                                            <asp:FileUpload ID="FilePanCard" runat="server" Style="display: none;" onchange="showimagepreview(this,'imgPancard')" />
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Upload Pan Card</label>
                                                <div class="col-md-9 img-chair">
                                                    <img id="imgPancard" runat="server"
                                                        onclick="getinputimage('FilePanCard');"
                                                        style="width: 150px; height: 150px" src="../SoftImg/NoImage.jpeg" alt="PanCard Image" />
                                                </div>
                                            </div>

                                            <center id="ActionPan" runat="server">
                                                <div class="form-group row mb-0">
                                                    <div class="col-sm-10 offset-sm-2">
                                                        <asp:Button ID="btnPan" runat="server" Text="Submit" CssClass="btn btn-success" OnClientClick="return ValidPan();" OnClick="bntPan_Click" />
                                                        <button class="btn btn-primary" type="button" onclick="PanClear();">Clear</button>
                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                    </div>

                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script type="text/javascript" language="javascript">
        function ValidBank() {
            var nState = $('#ContentPlaceHolder1_AccountType').val();
            var txtBankName = $("#ContentPlaceHolder1_txtBankName").val();
            var txtBranchName = $("#ContentPlaceHolder1_txtBranchName").val();
            var txtAccountHolderName = $("#ContentPlaceHolder1_txtAccountHolderName").val();
            var txtAccountNumber = $("#ContentPlaceHolder1_txtAccountNumber").val();
            var txtIFSC = $("#ContentPlaceHolder1_txtIFSC").val();

            var errCount = 0;


            if (nState == '-1') {
                errCount++;
                $('#ContentPlaceHolder1_AccountType').css('border-color', 'Red');
            } else { $('#ContentPlaceHolder1_AccountType').css('border-color', 'lightgrey'); }

            if (txtBankName.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtBankName').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtBankName').css('border-color', 'lightgrey'); }

            if (txtBranchName.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'lightgrey'); }

            if (txtAccountHolderName.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtAccountHolderName').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtAccountHolderName').css('border-color', 'lightgrey'); }

            if (txtAccountNumber.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtAccountNumber').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtAccountNumber').css('border-color', 'lightgrey'); }

            if (txtIFSC.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtIFSC').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtIFSC').css('border-color', 'lightgrey'); }

            if (errCount > 0) {
                return false;
            }
            return true;
        }

        function ValidAdhaar() {
            var txtAdhaarNumber = $("#ContentPlaceHolder1_txtAdhaarNumber").val();
            var errCount = 0;
            if (txtAdhaarNumber.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtAdhaarNumber').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtAdhaarNumber').css('border-color', 'lightgrey'); }


            if (errCount > 0) {
                return false;
            }
            return true;
        }

        function ValidPan() {
            var txtPanCardNumber = $("#ContentPlaceHolder1_txtPanCardNumber").val();
            var errCount = 0;
            if (txtPanCardNumber.length <= 0) {
                errCount++;
                $('#ContentPlaceHolder1_txtPanCardNumber').css('border-color', 'Red');
            }
            else { $('#ContentPlaceHolder1_txtPanCardNumber').css('border-color', 'lightgrey'); }


            if (errCount > 0) {
                return false;
            }
            return true;
        }

        function BankClear() {
            $("#ContentPlaceHolder1_txtBankName").val("");
            $("#ContentPlaceHolder1_txtBranchName").val("");
            $("#ContentPlaceHolder1_txtAccountHolderName").val("");
            $("#ContentPlaceHolder1_txtAccountNumber").val("");
            $("#ContentPlaceHolder1_txtIFSC").val("");
            $("#ContentPlaceHolder1_imgPassbook").src = "assets/images/NoImage.jpeg";
        }

        function AdhaarClear() {
            $("#ContentPlaceHolder1_txtAdhaarNumber").val("");

            $("#ContentPlaceHolder1_imgadharfront").src = "assets/images/NoImage.jpeg";
            $("#ContentPlaceHolder1_imgadharback").src = "assets/images/NoImage.jpeg";
        }

        function PanClear() {
            $("#ContentPlaceHolder1_txtPanCardNumber").val("");
            $("#ContentPlaceHolder1_imgPancard").src = "assets/images/NoImage.jpeg";
        }
       

        function getinputimage(id) {
            //alert(id)
            document.getElementById("ContentPlaceHolder1_" + id).click();
        }

                //function showimagepreview(input,inputimg) {
                //    if (input.files && input.files[0]) {
                //        var filerdr = new FileReader();
                //        filerdr.onload = function (e) {
                //            $('#ContentPlaceHolder1_' + inputimg).attr('src', e.target.result);
                //        }

                //        filerdr.readAsDataURL(input.files[0]);
                //        imageData = filerdr.readAsDataURL(input.files[0]).split("base64,")[1]; ;
                //    }
                //    else {
                //        $('#ContentPlaceHolder1_' + inputimg).attr('src', 'assets/images/NoImage.jpg');
                //    }
                //}


        function showimagepreview(input, inputimg) {
            var fileInput = input;
            var filePath = fileInput.value;
          
            var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
            if (!allowedExtensions.exec(filePath)) {
                alert('Please upload file having extensions .jpeg/.jpg/.png/.gif only.');
                $('#ContentPlaceHolder1_' + inputimg).attr('src', 'assets/images/NoImage.jpeg');
                return false;
            } else {

                //Image preview
                if (fileInput.files && fileInput.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        //document.getElementById('imagePreview').innerHTML = '<img src="' + e.target.result + '"/>';
                        $('#ContentPlaceHolder1_' + inputimg).attr('src', e.target.result);
                    };
                    reader.readAsDataURL(fileInput.files[0]);
                }
                else {
                    $('#ContentPlaceHolder1_' + inputimg).attr('src', 'assets/images/NoImage.jpeg');
                }
            }
        }

    </script>
    <script type="text/javascript" language="javascript" src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css">
    <script>
        function Successclick(msg) {
            swal(msg, "", "success")
        }

    </script>

</asp:Content>

