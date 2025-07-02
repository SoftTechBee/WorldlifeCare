<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Bank.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
     #ContentPlaceHolder1_bntsubmit {  
  border-radius: 25px;    
     }
      #ContentPlaceHolder1_btncencel {  
  border-radius: 25px;    
     }
 </style>
      
     <style>
        .TxtBoxError {
         border:1px solid red;
         width:250px;
         height:30px;
        }

    </style>
    <script type="text/javascript">
        function Validate() {

            var rb = document.getElementById("<%=rdAccType.ClientID%>");
            var radio = rb.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked) {
                document.getElementById("ContentPlaceHolder1_rdAccType").className = "TxtBoxError";
                isChecked = false;
            }
            if (document.getElementById("ContentPlaceHolder1_txtBank").value == "") {
                document.getElementById("ContentPlaceHolder1_txtBank").className = "TxtBoxError";

          }
          else {

                document.getElementById("ContentPlaceHolder1_txtBank").className = "form-control";
          }
            if (document.getElementById("ContentPlaceHolder1_txtBranch").value == "") {
                document.getElementById("ContentPlaceHolder1_txtBranch").className = "TxtBoxError";

          }
          else {

                document.getElementById("ContentPlaceHolder1_txtBranch").className = "form-control";
          }
            if (document.getElementById("ContentPlaceHolder1_txtAHName").value == "") {
                document.getElementById("ContentPlaceHolder1_txtAHName").className = "TxtBoxError";

          }
          else {

                document.getElementById("ContentPlaceHolder1_txtAHName").className = "form-control";
          }
            if (document.getElementById("ContentPlaceHolder1_txtIFSC").value == "") {
                document.getElementById("ContentPlaceHolder1_txtIFSC").className = "TxtBoxError";

          }
          else {

                document.getElementById("ContentPlaceHolder1_txtIFSC").className = "form-control";
          }
            if (document.getElementById("ContentPlaceHolder1_txtAccNo").value == "") {
                document.getElementById("ContentPlaceHolder1_txtAccNo").className = "TxtBoxError";

          }
          else {

                document.getElementById("ContentPlaceHolder1_txtAccNo").className = "form-control";
          }
     
          return isChecked;
      }
</script>
        <!------Msgbox End---->
     <div class="card-body">
             
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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            
            </div>

     
   
             
        <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title">Bank Detail </h4>
                 <!----form start---->
                            <div class=" form-group row mt-2">
             <div class="col-lg-12">
                
                <div class="input-group input-group-sm"  > 
                <asp:TextBox ID="txtsearchuname" CssClass="form-control" placeholder="Enter User Name" runat="server"></asp:TextBox>
                    <span class="input-group-btn">                    
<asp:Button ID="btnsearch" runat="server" Text="Go!" OnClick="btnsearch_Click"   CssClass="btn btn-info btn-flat "  />
                </span>
              </div> 
              
           
             </div>
             
                      </div>
                         <div class="form-group row">
                           
                  <label class="control-label  col-lg-2">Bank Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtBank" runat="server"   class="form-control" placeholder="Enter Bank Name"></asp:TextBox>              
                </div>
                              <label class="control-label  col-lg-2">Branch Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtBranch" runat="server"  class="form-control" placeholder="Enter Branch Name"></asp:TextBox>              
                </div>
                </div>
                         <div class="form-group row">
                           
                  <label class="control-label  col-lg-2">Account Holder Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtAHName" runat="server"  class="form-control"  placeholder="Enter Account Holder Name"></asp:TextBox>              
                     
                                   </div>
                              <label class="control-label  col-lg-2">IFSC Code</label>
                             <div class="col-lg-4">
                                   <asp:TextBox ID="txtIFSC"  runat="server"  class="form-control"  placeholder="Enter IFSC Code"></asp:TextBox>              
                   
                          
                </div>
                </div>
                         <div class="form-group  row">
                            <label class="control-label  col-lg-2"> Account Number</label>
                             <div class="col-lg-4">
                                   <asp:TextBox ID="txtAccNo"  runat="server"  class="form-control"  placeholder="Enter Account Number"></asp:TextBox>              
                   
                          
                </div>
                  <label class="control-label  col-lg-2">Account Type </label>
                             <div class="col-lg-4">
                  <asp:DropDownList ID="rdAccType" runat="server" CssClass="form-control iradio_minimal-red"  RepeatDirection="Horizontal">
                     <asp:ListItem Value="-1">NONE</asp:ListItem>
                     <asp:ListItem Value="0">Saving</asp:ListItem>
                     <asp:ListItem Value="1">Current</asp:ListItem>
                   </asp:DropDownList>  
                                   </div>
                             
                </div>
                            <%--<div class="form-group row">
                           
                  <label class="control-label  col-lg-2">PayTM Number</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtpaytm" runat="server"   class="form-control" placeholder="Enter PayTM Number"></asp:TextBox>              
                </div>
                              <label class="control-label  col-lg-2">PhonePay Number</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtPhonePay" runat="server"  class="form-control" placeholder="Enter PhonePay"></asp:TextBox>              
                </div>
                </div>--%>
                        <%--<div class="form-group row">
                           
                  <label class="control-label  col-lg-2">BHIM Number</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtbhim" runat="server"   class="form-control" placeholder="Enter BHIM "></asp:TextBox>              
                </div>
                              <label class="control-label  col-lg-2">GooglePay Address</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtBitcoin" runat="server"  class="form-control" placeholder="Enter GooglePay"></asp:TextBox>              
                </div>
                </div>--%>
                        
                 <div class="card-footer">
                     <center>
                 <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click"   runat="server" Text="Save" CssClass=" btn btn-success btn-flat btn-lg"  />  
               
                    <%--  <asp:Button ID="btncencel" runat="server" OnClick="btncencel_Click" Text="Cancel" Width="200px" CssClass="btn  btn-danger btn-lg btn-flat"  />  
               --%>
                      </center>                    
                </div>
                
                 </div>
             
          
                       
            </div>

        </div>
       
       
</asp:Content>

