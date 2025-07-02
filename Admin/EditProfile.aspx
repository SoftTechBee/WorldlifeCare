<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
     #ContentPlaceHolder1_bntsubmit {  
  border-radius: 25px;    
     }
      #ContentPlaceHolder1_btncencel {  
  border-radius: 25px;    
     }
 </style>
         <!-- jQuery 3 -->

    <style>
        .TxtBoxError {
         border:1px solid red;
         width:250px;
         height:30px;
        }

    </style>
    <script type="text/javascript">
        function Validate() {
            var isChecked = false;
          var rb = document.getElementById("<%=rdSex.ClientID%>");
             var radio = rb.getElementsByTagName("input");
             
             for (var i = 0; i < radio.length; i++) {
                 if (radio[i].checked) {
                     isChecked = true;
                     break;
                 }
             }

             if (!isChecked) {
                 document.getElementById("ContentPlaceHolder1_rdSex").className = "TxtBoxError";
             }
             <%--var rb = document.getElementById("<%=rdSide.ClientID%>");
             var radio = rb.getElementsByTagName("input");
             for (var i = 0; i < radio.length; i++) {
                 if (radio[i].checked) {
                     isChecked = true;
                     break;
                 }
             }

             if (!isChecked) {
                 document.getElementById("ContentPlaceHolder1_rdSide").className = "TxtBoxError";
             }--%>
            <%-- if (document.getElementById("ContentPlaceHolder1_drpUpline").value == "Select") {
                 document.getElementById("ContentPlaceHolder1_drpUpline").className = "TxtBoxError";

             }
             else {

                 document.getElementById("ContentPlaceHolder1_drpUpline").className = "form-control";
                 
                 var rb = document.getElementById("<%=rdSide.ClientID%>");
                var radio = rb.getElementsByTagName("input");               
                for (var i = 0; i < radio.length; i++) {
                    if (radio[i].checked) {
                        isChecked = true;
                        break;
                    }


                }
                if (!isChecked) {
                    document.getElementById("ContentPlaceHolder1_rdSide").className = "TxtBoxError";
                    isChecked = false;
                }
            }--%>


             if (document.getElementById("ContentPlaceHolder1_txtName").value == "") {
                 document.getElementById("ContentPlaceHolder1_txtName").className = "TxtBoxError";
                 isChecked = false;
             }
             else {

                 document.getElementById("ContentPlaceHolder1_txtName").className = "form-control";
                 isChecked = true;
             }
             //if (document.getElementById("ContentPlaceHolder1_txtFName").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtFName").className = "TxtBoxError";
             //    isChecked = false;

             //}
             //else {

             //    document.getElementById("ContentPlaceHolder1_txtFName").className = "form-control";
             //    isChecked = true;
             //}
             //if (document.getElementById("ContentPlaceHolder1_txtDOB").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtDOB").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_txtDOB").className = "form-control";
             //}
             //if (document.getElementById("ContentPlaceHolder1_txtAddress").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtAddress").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_txtAddress").className = "form-control";
             //}
             //if (document.getElementById("ContentPlaceHolder1_txtpincode").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtpincode").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_txtpincode").className = "form-control";
             //}
             //if (document.getElementById("ContentPlaceHolder1_drpstate").value == "Select State") {
             //    document.getElementById("ContentPlaceHolder1_drpstate").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_drpstate").className = "form-control";
             //}
             //if (document.getElementById("ContentPlaceHolder1_drpCity").value == "Select City") {
             //    document.getElementById("ContentPlaceHolder1_drpCity").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_drpCity").className = "form-control";
             //}
             if (document.getElementById("ContentPlaceHolder1_txtMobile").value == "") {
                 document.getElementById("ContentPlaceHolder1_txtMobile").className = "TxtBoxError";
                 isChecked = false;
             }
             else {
                 isChecked = true;
                 document.getElementById("ContentPlaceHolder1_txtMobile").className = "form-control";
             }
             if (document.getElementById("ContentPlaceHolder1_txtEmail").value == "") {
                 document.getElementById("ContentPlaceHolder1_txtEmail").className = "TxtBoxError";
                 isChecked = false;
             }
             else {
                 isChecked = true;
                 document.getElementById("ContentPlaceHolder1_txtEmail").className = "form-control";
             }
             //if (document.getElementById("ContentPlaceHolder1_txtpan").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtpan").className = "TxtBoxError";
             //    isChecked = false;
             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_txtpan").className = "form-control";
             //}
             //if (document.getElementById("ContentPlaceHolder1_txtaadhar").value == "") {
             //    document.getElementById("ContentPlaceHolder1_txtaadhar").className = "TxtBoxError";
             //    isChecked = false;

             //}
             //else {
             //    isChecked = true;
             //    document.getElementById("ContentPlaceHolder1_txtaadhar").className = "form-control";
             //}

             return isChecked;
         }
</script>
        <!------Msgbox End---->
       <div class="page-breadcrumb mb-2">
                <div class="row">
                    <div class="col-5 align-self-center">
                        <h5 class="page-title">Edit Profile</h5>
                    </div>
                    <div class="col-7 align-self-center">
                        <div class="d-flex align-items-center justify-content-end">
                            <%--<nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item">
                                        <a href="Home.aspx">Home</a>
                                    </li>
                                    <li class=" active" aria-current="page">Edit Profile</li>
                                </ol>
                            </nav>--%>
                        </div>
                    </div>
                </div>
            </div>
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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            
            </div>

        <div class="row>">
             <div class="col-lg-12">
                <div class="input-group input-group-xlg" style="margin-bottom:10px; margin-top:-10px;"> 
                <asp:TextBox ID="txtsearchuname" CssClass="form-control" placeholder="Enter User Name" runat="server"></asp:TextBox>
                    <span class="input-group-btn" style="margin-left:10px;">                    
<asp:Button ID="btnsearch" runat="server" Text="Go!" OnClick="btnsearch_Click"   CssClass="btn btn-info btn-flat btn-lg"  />
                </span>
              </div>
                 
              
           
             </div>
             
                      </div>
        <div class="row">
             <div class="col-lg-3">
                    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                     <h3> Admission Detail</h3>
                 
              
              <div class="form-group row">
                <label class="col-lg-12">UserName</label>
                 <div class="col-lg-12">
                      <asp:Label ID="lbUserName" runat="server" Text="" CssClass="form-control"></asp:Label>   
                </div>
                  </div>
                          <div class="form-group">
                <label class="col-lg-12">Sponser</label>
                 <div class="col-lg-12">
                 <asp:Label ID="lbSponser" runat="server" Text="" CssClass="form-control"></asp:Label>          
                 </div>
                  <center> <asp:Label runat="server" ID="lbSponserName" Text="" CssClass="label label-info label-success"></asp:Label>
                </center>  

                          </div>
                           <%--<div class="form-group">
                <label class="col-lg-12">Select Upline</label>
                 <div class="col-lg-12">
                   <asp:Label ID="lbUpline" runat="server" Text="" CssClass="form-control"></asp:Label>  
                      <center> <asp:Label runat="server" ID="lbuplineName" Text="" CssClass="label label-info label-success"></asp:Label>
                </center> 


                 </div>
                  </div>--%>
                           <div class="form-group">
                <label class="col-lg-12">Select Side</label>
                 <div class="col-lg-12">
                   <asp:Label ID="lbside" runat="server" Text="" CssClass="form-control"></asp:Label>   
                   <center> <asp:Label runat="server" ID="lbmsg" Text="" CssClass="label  label-danger"></asp:Label>
                 </div>
                  </div>
                         <div class="form-group row">
                <label class="col-lg-12">Joining Date</label>
                 <div class="col-lg-12">
                   <asp:Label ID="lbDOJ" runat="server" Text="" CssClass="form-control"></asp:Label>   
                  
                 </div>
                  </div>
                          <div class="form-group row">
                <label class="col-lg-12">Account Status</label>
                 <div class="col-lg-12">
                   <asp:Label ID="lbStatus" runat="server" Text="" CssClass="form-control"></asp:Label>   
                  
                 </div>
                  </div>
                </div>
                     <div class="box-footer"></div>
                
                     </div>
                      </div>
                 
             </div>
           <div class="col-lg-9">
          <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                     <h3 >User Registration Here .....</h3>
                 
                 <!----form start---->
                 
                         <div class="form-group row">
                           
                  <label class="control-label  col-lg-2">Full Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtName" runat="server"  class="form-control" placeholder="Enter  Full Name"></asp:TextBox>              
                </div>  <label class="control-label  col-lg-2">Sex</label>
                             <div class="col-lg-4">
                   <asp:RadioButtonList ID="rdSex" runat="server" CssClass="form-control iradio_minimal-red"  RepeatDirection="Horizontal">
                     <asp:ListItem Value="0">Male</asp:ListItem>
                     <asp:ListItem Value="1">Female</asp:ListItem>
                   </asp:RadioButtonList>              
                </div>
<%--                              <label class="control-label  col-lg-2">Father Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtFName" runat="server"  class="form-control" placeholder="Enter Father Name"></asp:TextBox>              
                </div>--%>
                </div>
<%--                         <div class="form-group">
                           
                  <label class="control-label  col-lg-2">DateOFBirth</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtDOB" runat="server"  class="form-control" Type="date" placeholder="Enter  DateOFBirth"></asp:TextBox>              
                     
                                   </div>
                            
                </div>--%>
                <div class="form-group row">
                           
                  <label class="control-label  col-lg-2"> Address</label>
                             <div class="col-lg-10">
                   <asp:TextBox ID="txtAddress" runat="server"  class="form-control" placeholder="Enter Address"></asp:TextBox>              
                </div>
                    <%-- <label class="control-label  col-lg-2">Enter PanCard Number </label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtpan" runat="server"  MaxLength="10" class="form-control" placeholder="Enter PanCard Number"></asp:TextBox>              
                </div>
                              <label class="control-label  col-lg-2"> Enter PinCode</label>
                             <div class="col-lg-4">
                           <asp:TextBox ID="txtpincode" runat="server"  MaxLength="6" class="form-control" placeholder="Enter PinCode"></asp:TextBox>        
                </div>--%>
                </div>
                        <%-- <div class="form-group">
                           
                  <label class="control-label  col-lg-2">Select State </label>
                             <div class="col-lg-4">
                  <asp:DropDownList ID="drpstate" DataTextField="state" DataValueField="state" AutoPostBack="true" OnSelectedIndexChanged="drpstate_SelectedIndexChanged" runat="server" CssClass="form-control">

                                 </asp:DropDownList>
                                 
                                 
                                   </div>
                      <label class="control-label  col-lg-2">Select City </label>
                             <div class="col-lg-4">
                                 <asp:DropDownList ID="drpCity" DataTextField="City" DataValueField="City" runat="server" CssClass="form-control">

                                 </asp:DropDownList>
                </div>          
                </div>--%>
                         <div class="form-group row">
                           
                  <label class="control-label  col-lg-2">Enter Mobile </label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtMobile" runat="server"  MaxLength="10" class="form-control" placeholder="Enter Mobile"></asp:TextBox>              
                </div>
                      <label class="control-label  col-lg-2">Enter Email </label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtEmail" runat="server"   class="form-control" placeholder="Enter Email"></asp:TextBox>              
                </div>          
                </div>
                       <%--   <div class="form-group">
                           
                 
                     <label class="control-label  col-lg-2">Enter Aadhar Card Number </label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtaadhar" runat="server"   class="form-control" placeholder="Enter  Aadhar Card Numbe"></asp:TextBox>              
                </div>  --%>        
               
                       <%-- <div class="form-group">
                           
                  <label class="control-label  col-lg-2">Select Marital</label>
                             <div class="col-lg-4">
                                  <asp:RadioButtonList ID="rdMaritalStatus" runat="server" CssClass="form-control iradio_minimal-red"  RepeatDirection="Horizontal">
                     <asp:ListItem Value="0">Married</asp:ListItem>
                     <asp:ListItem Value="1">Un-Married</asp:ListItem>
                   </asp:RadioButtonList>   
                      </div>
                      <label class="control-label  col-lg-2"> Date Of Anniversary </label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtDOA" runat="server"  Type="date"  class="form-control" placeholder="Enter  Aadhar Card Numbe"></asp:TextBox>              
                </div>          
                </div>--%>
                
                          <div class="form-group row"><br /><br /><br /><br /></div>
                          <div class="form-group row">
                               <div class="col-lg-8">
                             <center>
                 <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Validate();" runat="server" Text="Save"  CssClass=" btn btn-success btn-flat btn-lg"  />  
               
                    <%--  <asp:Button ID="btncencel" runat="server" OnClick="btncencel_Click" Text="Cancel" Width="200px" CssClass="btn  btn-danger btn-lg btn-flat"  />  
               --%>
                      </center>  
                                   </div>
                </div>
                
                 </div>
             
          </div></div>
                       
            </div>

        </div>
    
         <%--<div class="row">
             
        <div class="col-lg-12">
            <div class="box  box-warning ">
                 <div class="box-header with-border">
                     <h1 class=" box-title">Nomnee Detail</h1>
                 </div>
                 <!----form start---->
                 <div class="form-horizontal">
                     <div class="box-body">
                         <div class="form-group">
                           
                  <label class="control-label  col-lg-2">Nominee Name</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtNName" runat="server"  class="form-control" placeholder="Enter Nominee Name"></asp:TextBox>              
                </div>
                              <label class="control-label  col-lg-2">Nominee Age</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtNAge" runat="server" max="2" class="form-control" placeholder="Enter Nominee Age"></asp:TextBox>              
                </div>
                </div>
                         <div class="form-group">
                           
                  <label class="control-label  col-lg-2">Nominee Mobile</label>
                             <div class="col-lg-4">
                   <asp:TextBox ID="txtNMobile" runat="server"  class="form-control"  placeholder="Enter Nominee Mobile"></asp:TextBox>              
                     
                                   </div>
                              <label class="control-label  col-lg-2">Relation With Nominee</label>
                             <div class="col-lg-4">
                                   <asp:TextBox ID="txtNRelation" runat="server"  class="form-control"  placeholder="Enter Nominee Mobile"></asp:TextBox>              
                   
                          
                </div>
                </div>
                        
                        
                 <div class="box-footer">
                                      
                </div>
                
                 </div>
             
          
                       
            </div>

        </div>
        </div>
        </div>--%>  
       <%-- </div>--%>
    
</asp:Content>