<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="FundTransfer.aspx.cs" Inherits="User_FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <!------Msgbox End---->
     <div class="box-body">
              <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
              <div class="alert alert-info alert-dismissible" id="info" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-info"></i> Alert!</h4>
               <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>  
             
              </div>
              <div class="alert alert-warning alert-dismissible" id="warning" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-warning"></i> Alert!</h4>
               <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label> 
            
              </div>
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false" >
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            </div>
       <!-- Danger Alert -->
    <div class="alert alert-success alert-dismissible text-white bg-success alert-label-icon fade show" id="IsVerified" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbIsVerified" runat="server" Text="KYC Verified"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
   <div class="alert alert-danger alert-dismissible text-white bg-danger alert-label-icon fade show" id="IsPending" runat="server" visible="false" role="alert">
        <i class="ri-error-warning-line label-icon"></i><strong>
            <asp:Label ID="lbPending" runat="server" Text="KYC Pending"></asp:Label></strong>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
    <!-----Alert End----->
<script type="text/javascript">
        function Validate() {
            // alert('');
             var isChecked = false;

           
             if (document.getElementById("ContentPlaceHolder1_drpPackage").value == "Select") {
                 document.getElementById("ContentPlaceHolder1_drpPackage").className = "TxtBoxError";
                 isChecked = false;
             }
             else {

                 document.getElementById("ContentPlaceHolder1_drpPackage").className = "form-control";
                 isChecked = true;
             }
             if (document.getElementById("ContentPlaceHolder1_txtOTP").value != "")
             {
                 document.getElementById("ContentPlaceHolder1_txtOTP").className = "form-control";   
                 isChecked = false;
             }
             else {

                 document.getElementById("ContentPlaceHolder1_txtOTP").className = "form-control";               
                 isChecked = true;
             }
             return isChecked;
             
         }
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

          <div class="row">
<div  class="col-lg-12">
           <div class="card ">
                            <div class="card-body">
              <h3>  Fund Transfer  </h3>
                                   
                       <div class="mb-3 row">
                          <label class="control-label col-sm-4">Available Fund  </label>
                          <div class="col-sm-6">
                     
              <h3> <asp:Label ID="txtbalance" runat="server" Text="0"></asp:Label></h3>

            
                          </div>
                           </div>
                        <div class="mb-3 row">
                          <label class="control-label col-sm-4"> Member </label>
                          <div class="col-sm-6">
                             
                          <asp:Label ID="lbActiveMember"  runat="server"  CssClass="control-label"></asp:Label>
                          </div>
                          </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                      <asp:AsyncPostBackTrigger ControlID="txtTransid" EventName="TextChanged" />
                                      <asp:AsyncPostBackTrigger ControlID="txtAMount" EventName="TextChanged" />
                                  <%--    <asp:AsyncPostBackTrigger ControlID="txttransPassword" EventName="TextChanged" />
                                  --%>  
                                    </Triggers>
                                    <ContentTemplate>

                     <div class="mb-3 row">
                          <label class="control-label col-sm-4">Enter Transfer Member ID </label>
                          <div class="col-sm-6">
                             
                          <asp:Textbox ID="txtTransid"  required=""  AutoPostBack="true" OnTextChanged="txtTransid_TextChanged" runat="server"  CssClass="form-control" placeholder="Enter Transfer Member"></asp:Textbox>
                            <asp:Label ID="lbTransname"  runat="server"  CssClass="control-label"></asp:Label>
                        
                          </div>
                          </div>
                          <div class="mb-3 row">
                          <label class="control-label col-sm-4">Enter Transfer Fund amount </label>
                          <div class="col-sm-6">
                             
                          <asp:Textbox ID="txtAMount"   required="" runat="server"  CssClass="form-control" placeholder="Enter Transfer amount"></asp:Textbox>
                    </div>
                              </div>
                                          <%--<div class="form-group row">
                                              
                         <label class="control-label col-lg-4 ">Admin Fee(10%) </label>     

                        <div class="col-lg-6">
                         <asp:TextBox ID="txtadmincharge" Text="" required="" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                         </div>
                               <div class="form-group row">
                           <label class="control-label col-lg-4">Final Fund Transfer  </label>     

                        <div class="col-lg-6">
                         <asp:TextBox ID="txtfinal" Text="" required=""  placeholder="Enter Transfer amount" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                            
                          </div>--%>
                                              
                       <div class=" mb-3 row">
                           
                  <label class="control-label  col-lg-4">Enter  Transaction Password<span  class="text text-danger ">*</span></label>
                             <div class="col-lg-6">
                   <asp:TextBox ID="txttransPassword" runat="server" required="" TextMode="Password"   class="form-control" placeholder="Enter  Transaction Password"></asp:TextBox>              
                </div>
                          
                </div>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                     <div class="mb-3 row">
                       
                   <div class=" col-sm-4">

</div>                  <div class=" col-sm-4">

   <asp:Button ID="btnaction" runat="server" Text="Transfer"  OnClick="butsubmit_Click" Width="200px" CssClass=" btn bg-success btn-flat btn-lg" />
               
        </div>
                  </div>
                   
          </div>
          <!-- /.box -->
                    
                      </div>

              
              
                 </div>         
            
             
             
   </div>


   <%--</ContentTemplate>
         </asp:UpdatePanel>--%>



</asp:Content>

