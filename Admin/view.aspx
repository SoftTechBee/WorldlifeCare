<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
     <!-- Title -->


    
	<div class="row heading-bg  bg-blue">
		<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
			<h5 class="txt-light">KYC Request</h5>
		</div>		
	</div>
	<!-- /Title -->    

    <div class="row">
		<div class="col-sm-12">
         <div id="lblmsg" style="display:none;" class="alert alert-danger alert-dismissable">
			Opps! Somthing went wrong. 
		 </div>        
               <div id="sccess" runat="server" visible="false" class="alert alert-danger alert-dismissable">
			<asp:label runat="server" ID="lbsuccess"></asp:label>
		 </div>        

			<div id="lblresult" class="card ">				
				<div class="card-wrapper ">
					<div class="card-body">
                        <div class="table-wrap">
						    <div class="table-responsive">

							   <table class="table">    
                               <thead>
                                      <tr>
                                        <td colspan="4" class="f-18 fw-bold">Bank Details</td>
                                      </tr>
                                    </thead>
                                    <tbody>
                                      <tr>
                                        <td colspan="2">User Name</td>
                                        <td colspan="2" id="lblUserName" runat="server" ></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Name</td>
                                        <td colspan="2" id="lblFullName" runat="server"></td>
                                      </tr>
                                      <tr >
                                        <td colspan="2">Account Type</td>
                                        <td colspan="2" id="lblAccountType" runat="server"></td>       
                                      </tr>
                                      <tr>
                                        <td colspan="2">Account Holder Name</td>
                                        <td colspan="2" id="lblAccountHolderName" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Bank Name</td>
                                        <td colspan="2" id="lblBankName" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Branch</td>
                                        <td colspan="2" id="lblBranch" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Account Number</td>
                                        <td colspan="2" id="lblAccountNumber" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">IFSC</td>
                                        <td colspan="2" id="lblIFSC" runat="server"></td>
                                      </tr>
                                    <%--  <tr>
                                        <td colspan="2">PayTM UPI ID</td>
                                        <td colspan="2" id="lbPayTM" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Phone Pay UPI ID</td>
                                        <td colspan="2" id="lbPhonePay" runat="server"></td>
                                      </tr>
                                      <tr>
                                        <td colspan="2">Google Pay UPI ID</td>
                                        <td colspan="2" id="lbGpay" runat="server"></td>
                                      </tr>--%>
                                      <tr>
                                      <td colspan="2">Image Passbook/Check</td>                  
                                        <td colspan="2" style="text-align:left;"> 
                                            <a id="ViewPassbook" runat="server" href="../SoftImg/KYC/NoImage.jpg" target="_blank">                                          
                                                <img id="imgpasbook" runat="server" alt="" style="width:80px; height:80px;" src="../SoftImg/KYC/NoImage.jpg" />
                                            </a>
                                        </td>
                                        </tr>
                                     <tr>
                                        <td colspan="2">Status</td>
                                        <td colspan="2" id="lblBankStatus" runat="server"></td>
                                      </tr>
                                       <tr id="lblisapproved" runat="server" >
                                           <td colspan="2">Verify / REJECT</td>
                                           <td colspan="2">
                                                <asp:Button ID="btnBankApproved" runat="server" Text="Verify" style="width:100px;" CssClass="btn  btn-success btn-rounded btn-xs" OnClick="btnBankApproved_Click" />
                                                <button type="button" ID="btnBankReject" runat="server" class="btn  btn-danger btn-rounded btn-xs" style="width:100px;" onclick="rejectremarks('Bank Details');">Reject</button>
                                        </td>
                                        </tr>

                                    </tbody>
                                </table>                              
                            </div>
                        </div>                    
                    </div>
                </div>
            </div>

            <div id="Div1" class="card ">				
				<div class="card-wrapper ">
					<div class="card-body">
                        <div class="table-wrap">
						    <div class="table-responsive">
                            <table class="table">
                                    <thead>
                                      <tr>
                                        <th>Document Type</th>
                                        <th>Document No</th>
                                        <th style="text-align:center;" >Image</th>
                                        <th>Status</th>
                                        <th>Verify<br />Reject</th>
                                      </tr>
                                    </thead>
                                    <tbody>
                                      <tr>
                                        <td>Adhaar Card Front Image</td>
                                        <td id="lblAdharFront" runat="server"></td>
                                        <td style="text-align:center;">  
                                            <a id="ViewAdhaarFront" runat="server" href="../SoftImg/KYC/NoImage.jpg" target="_blank">                                          
                                            <img id="imgAdhaarFront" runat="server" alt="" style="width:80px; height:80px;" src="../SoftImg/KYC/NoImage.jpg" />
                                            </a>
                                        </td>
                                        <td id="lblAdharFrontStatus" runat="server" ></td>
                                        <td>
                                            <asp:Button ID="btnFrontApproved" runat="server" Text="Verify" style="width:100px;" CssClass="btn  btn-success btn-rounded btn-xs" OnClick="btnFrontApproved_Click" />
                                            <p style="margin:3px 3px;"></p>
                                            <button type="button" ID="btnFrontReject" runat="server" class="btn  btn-danger btn-rounded btn-xs" style="width:100px;" onclick="rejectremarks('Adhaar Card');">Reject</button>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td>Adhaar Card Back Image</td>                      
                                        <td id="lblAdharBack" runat="server"></td>                  
                                        <td style="text-align:center;">   
                                            <a id="ViewAdhaarBack" runat="server" href="../SoftImg/KYC/NoImage.jpg" target="_blank">  
                                            <img id="imgAdhaarBack" runat="server" alt="" style="width:80px; height:80px;" src="../SoftImg/KYC/NoImage.jpg" />
                                            </a>
                                        </td>
                                        <td id="lblAdharBackStatus" runat="server"></td>
                                        <td>
                                            
                                        </td>
                                      </tr>
                                      <tr>
                                        <td>Pan Card</td>                      
                                        <td id="lblPenCardNo" runat="server"></td>                  
                                        <td style="text-align:center;"> 
                                            <a id="ViewPan" runat="server" href="../SoftImg/KYC/NoImage.jpg" target="_blank">                                             
                                                <img id="imgPencard" runat="server" alt="" style="width:80px; height:80px;" src="../SoftImg/KYC/NoImage.jpg" />
                                            </a>
                                        </td>
                                        <td id="lblPanStatus" runat="server"></td>
                                        <td>
                                            <asp:Button ID="btnPanApproved" runat="server" Text="Verify" style="width:100px;" CssClass="btn  btn-success btn-rounded btn-xs" OnClick="btnPanApproved_Click" />
                                            <p style="margin:3px 3px;"></p>
                                            <button type="button" ID="btnPanReject" runat="server" class="btn  btn-danger btn-rounded btn-xs" style="width:100px;" onclick="rejectremarks('Pan Card');">Reject</button>
                                        </td>
                                      </tr>




                                      


                           
                                    </tbody>    
                                  </table>
							                                 
                            </div>
                        </div>   
                        
                        <a href="Home.aspx" class="btn btn-danger btn-sm">Back</a>                 
                    </div>
                </div>
            </div>
        </div>
    </div>   

    <div id="myNewModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;" data-backdrop="static" data-keyboard="false">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
					<h5 id="lbltitle" class="modal-title">Modal Content is Responsive</h5>
				</div>
				<div class="modal-body">
					
						
						<div class="form-group">
							<label for="message-text" class="control-label mb-10">Remarks:</label>
							<textarea id="txtremarks" runat="server" maxlength="120" class="form-control" ></textarea>
						</div>
					
				</div>
				<div class="modal-footer">
                    <asp:HiddenField ID="hndTitle" runat="server" />
					<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnReject" runat="server" Text="Submit"  CssClass="btn btn-danger" OnClick="btnReject_Click" />
				</div>
			</div>
		</div>
	</div>

    <script type="text/javascript" language="javascript">
        function rejectremarks(istype) {
            $('#ContentPlaceHolder1_hndTitle').val(istype);
            $('#lbltitle').html(istype);
            $('#myNewModal').modal('show');
        }
    </script>

    <script type="text/javascript" language="javascript" src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css">
        <script type="text/javascript" language="javascript">
            function Successclick(msg) {
                swal(msg, "", "success")
            }
        </script>
</asp:Content>

